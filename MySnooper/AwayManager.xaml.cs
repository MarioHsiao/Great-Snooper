﻿using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Input;

namespace MySnooper
{
    public delegate void AwayChangedDelegate(bool Away);
    /// <summary>
    /// Interaction logic for AwayManager.xaml
    /// </summary>
    public partial class AwayManager : MetroWindow
    {
        public event AwayChangedDelegate AwayChanged;

        private bool _Away;
        private bool Away {
            get
            {
                return _Away;
            }
            set
            {
                _Away = value;

                if (value)
                {
                    AwayButton.Content = "Set back";
                    AwayText.IsEnabled = false;
                }
                else
                {
                    AwayButton.Content = "Set away";
                    AwayText.IsEnabled = true;
                }
            }
        }


        public AwayManager() { } // Never used, but visual stdio throws an error if not exists
        public AwayManager(string text)
        {
            InitializeComponent();

            Away = text != string.Empty;
            if (Away)
                AwayText.Text = text;
            else
                AwayText.Text = Properties.Settings.Default.AwayMessage;
        }

        private void AwayClick(object sender, RoutedEventArgs e)
        {
            e.Handled = true;

            if (Away)
            {
                Away = false;
                AwayChanged(Away);
                this.Close();
            }
            else
            {
                string text = WormNetCharTable.RemoveNonWormNetChars(AwayText.Text.Trim());
                if (text.Length > 0)
                {
                    Away = true;
                    Properties.Settings.Default.AwayMessage = text;
                    Properties.Settings.Default.Save();
                    AwayChanged(Away);
                    this.Close();
                }
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
            e.Handled = true;
        }
    }
}
