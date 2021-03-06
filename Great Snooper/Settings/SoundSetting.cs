﻿namespace GreatSnooper.Settings
{
    using System.IO;
    using System.Windows.Input;

    using GalaSoft.MvvmLight.Command;

    using GreatSnooper.Helpers;

    class SoundSetting : AbstractSetting
    {
        private bool? _enabled;
        private string _path;

        public SoundSetting(string settingName, string text)
        : base(settingName, text)
        {
            this._path = SettingsHelper.Load<string>(settingName);
            this._enabled = SettingsHelper.Load<bool>(settingName + "Enabled");
        }

        public bool? Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    SettingsHelper.Save(this.SettingName + "Enabled", value.Value);
                }
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                if (_path != value)
                {
                    _path = value;
                    SettingsHelper.Save(this.SettingName, value);
                }
            }
        }

        public ICommand SoundBrowseCommand
        {
            get
            {
                return new RelayCommand(BrowseSound);
            }
        }

        private void BrowseSound()
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "WAV Files (*.wav)|*.wav";
            if (File.Exists(Path))
            {
                dlg.InitialDirectory = new FileInfo(Path).Directory.FullName;
            }

            // Display OpenFileDialog by calling ShowDialog method
            var result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result.HasValue && result.Value)
            {
                this.Path = dlg.FileName;
                RaisePropertyChanged("Path");
            }
        }
    }
}