﻿using GalaSoft.MvvmLight.Command;
using GreatSnooper.Helpers;
using GreatSnooper.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Xml;

namespace GreatSnooper.Settings
{
    class ExportImportSettings : AbstractSetting
    {
        private IMetroDialogService dialogService;

        public ExportImportSettings(IMetroDialogService dialogService)
            : base("", "")
        {
            this.dialogService = dialogService;
        }

        #region ExportSettingsCommand
        public ICommand ExportSettingsCommand
        {
            get { return new RelayCommand(ExportSettings); }
        }

        private void ExportSettings()
        {
            try
            {
                var dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.DefaultExt = "config";
                dlg.FileName = "Great Snooper";
                dlg.Filter = "Config Files (*.config)|*.config";

                // Display OpenFileDialog by calling ShowDialog method 
                var result = dlg.ShowDialog();

                // Get the selected file name and display in a TextBox 
                if (result.HasValue && result.Value)
                {
                    using (StreamWriter sw = new StreamWriter(dlg.OpenFile()))
                    {
                        var settingsPath = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
                        sw.Write(File.ReadAllText(settingsPath));
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
            }
        }
        #endregion

        #region ResetSettingsCommand
        public ICommand ResetSettingsCommand
        {
            get { return new RelayCommand(ResetSettings); }
        }

        private void ResetSettings()
        {
            this.dialogService.ShowDialog(Localizations.GSLocalization.Instance.QuestionText, Localizations.GSLocalization.Instance.ResetSettingsConfirm, MahApps.Metro.Controls.Dialogs.MessageDialogStyle.AffirmativeAndNegative, GlobalManager.YesNoDialogSetting, (tt) =>
            {
                if (tt.Result == MahApps.Metro.Controls.Dialogs.MessageDialogResult.Affirmative)
                {
                    try
                    {
                        Properties.Settings.Default.Reset();
                        this.dialogService.ShowDialog(Localizations.GSLocalization.Instance.InformationText, Localizations.GSLocalization.Instance.RestartToApplyChanges);
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.Log(ex);
                    }
                }
            });
        }
        #endregion

        #region ImportSettingsCommand
        public ICommand ImportSettingsCommand
        {
            get { return new RelayCommand(ImportSettings); }
        }

        private void ImportSettings()
        {
            try
            {
                var dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.Filter = "Config Files (*.config)|*.config";

                // Display OpenFileDialog by calling ShowDialog method 
                Nullable<bool> result = dlg.ShowDialog();

                // Get the selected file name
                if (result.HasValue && result.Value)
                {
                    Dictionary<string, string> settings = new Dictionary<string, string>();

                    using (XmlReader reader = XmlReader.Create(dlg.FileName))
                    {
                        while (reader.ReadToFollowing("setting"))
                        {
                            reader.MoveToFirstAttribute();
                            string settingName = reader.Value;
                            reader.ReadToFollowing("value");
                            settings.Add(settingName, reader.ReadElementContentAsString());
                        }
                    }

                    foreach (var setting in settings)
                    {
                        try
                        {
                            if (SettingsHelper.Exists(setting.Key))
                            {
                                var value = SettingsHelper.Load(setting.Key);
                                if (value.ToString() != setting.Value)
                                    SettingsHelper.Save(setting.Key, Convert.ChangeType(setting.Value, value.GetType()), false);
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.Log(ex);
                        }
                    }

                    Properties.Settings.Default.Save();
                    this.dialogService.ShowDialog(Localizations.GSLocalization.Instance.InformationText, Localizations.GSLocalization.Instance.RestartToApplyChanges);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
            }
        }
        #endregion
    }
}
