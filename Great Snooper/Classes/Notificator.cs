﻿using GreatSnooper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GreatSnooper.Classes
{
    class Notificator
    {
        #region Static
        private static Notificator instance;
        #endregion

        #region Members
        private Regex _senderNamesRegex;
        private Regex _gameNamesRegex;
        private Regex _hosterNamesRegex;
        private Regex _joinMessagesRegex;

        private MySortedList<string> searchInSenderNames;
        private MySortedList<string> searchInMessages;
        private MySortedList<string> searchInGameNames;
        private MySortedList<string> searchInHosterNames;
        private MySortedList<string> searchInJoinMessages;

        public bool _searchInMessagesEnabled;
        public bool _searchInSenderNamesEnabled;
        public bool _searchInGameNamesEnabled;
        public bool _searchInHosterNamesEnabled;
        public bool _searchInJoinMessagesEnabled;
        public volatile bool _isEnabled;
        #endregion

        #region Properties
        public static Notificator Instance
        {
            get
            {
                if (instance == null)
                    instance = new Notificator();
                return instance;
            }
        }

        public MySortedList<string> SearchInMessages
        {
            get { return searchInMessages; }
        }
        public Regex GameNamesRegex
        {
            get
            {
                if (_gameNamesRegex == null)
                    _gameNamesRegex = GenerateRegex(searchInGameNames);
                return _gameNamesRegex;
            }
        }

        public Regex HosterNamesRegex
        {
            get
            {
                if (_hosterNamesRegex == null)
                    _hosterNamesRegex = GenerateRegex(searchInHosterNames);
                return _hosterNamesRegex;
            }
        }

        public Regex JoinMessagesRegex
        {
            get
            {
                if (_joinMessagesRegex == null)
                    _joinMessagesRegex = GenerateRegex(searchInJoinMessages);
                return _joinMessagesRegex;
            }
        }

        public Regex SenderNamesRegex
        {
            get
            {
                if (_senderNamesRegex == null)
                    _senderNamesRegex = GenerateRegex(searchInSenderNames);
                return _senderNamesRegex;
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                }
            }
        }
        public bool SearchInMessagesEnabled
        { 
            get { return this.IsEnabled && _searchInMessagesEnabled; }
        }
        public bool SearchInSenderNamesEnabled
        {
            get { return this.IsEnabled && _searchInSenderNamesEnabled; }
        }
        public bool SearchInGameNamesEnabled
        {
            get { return this.IsEnabled && _searchInGameNamesEnabled; }
        }
        public bool SearchInHosterNamesEnabled
        {
            get { return this.IsEnabled && _searchInHosterNamesEnabled; }
        }
        public bool SearchInJoinMessagesEnabled
        {
            get { return this.IsEnabled && _searchInJoinMessagesEnabled; }
        }
        #endregion

        #region Events
        public event MessageRegexChangedDelegate MessageRegexChange;
        #endregion

        private Notificator()
        {
            this._isEnabled = Properties.Settings.Default.NotificatorStartWithSnooper;
            LoadList(Properties.Settings.Default.NotificatorInGameNames, ref this.searchInGameNames, ref this._searchInGameNamesEnabled);
            LoadList(Properties.Settings.Default.NotificatorInHosterNames, ref this.searchInHosterNames, ref this._searchInHosterNamesEnabled);
            LoadList(Properties.Settings.Default.NotificatorInJoinMessages, ref this.searchInJoinMessages, ref this._searchInJoinMessagesEnabled);
            LoadList(Properties.Settings.Default.NotificatorInMessages, ref this.searchInMessages, ref this._searchInMessagesEnabled);
            LoadList(Properties.Settings.Default.NotificatorInSenderNames, ref this.searchInSenderNames, ref this._searchInSenderNamesEnabled);

            Properties.Settings.Default.PropertyChanged += Default_PropertyChanged;
        }

        private void Default_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "NotificatorInGameNames":
                    LoadList(Properties.Settings.Default.NotificatorInGameNames, ref this.searchInGameNames, ref this._searchInGameNamesEnabled);
                    break;

                case "NotificatorInHosterNames":
                    LoadList(Properties.Settings.Default.NotificatorInHosterNames, ref this.searchInHosterNames, ref this._searchInHosterNamesEnabled);
                    break;

                case "NotificatorInJoinMessages":
                    LoadList(Properties.Settings.Default.NotificatorInJoinMessages, ref this.searchInJoinMessages, ref this._searchInJoinMessagesEnabled);
                    break;

                case "NotificatorInMessages":
                    LoadList(Properties.Settings.Default.NotificatorInMessages, ref this.searchInMessages, ref this._searchInHosterNamesEnabled);
                    break;

                case "NotificatorInSenderNames":
                    LoadList(Properties.Settings.Default.NotificatorInSenderNames, ref this.searchInSenderNames, ref this._searchInSenderNamesEnabled);
                    break;
            }
        }

        private void LoadList(string value, ref MySortedList<string> list, ref bool enabled)
        {
            list = new MySortedList<string>();
            var words = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            enabled = false;
            foreach (string word in words)
            {
                if (!list.Contains(word))
                {
                    list.Add(word);
                    if (enabled == false && !word.StartsWith("#"))
                        enabled = true;
                }
            }
        }

        public string GetRegexStr(string str)
        {
            return Regex.Escape(str)
                .Replace(@"\.", @".")
                .Replace(@"\\.", @"\.")
                .Replace(@"\*", @".*")
                .Replace(@"\\.*", @"\*")
                .Replace(@"\+", @".+")
                .Replace(@"\\.+", @"\+")
                .Replace(@"\\\\", @"\\");
        }

        private Regex GenerateRegex(IEnumerable<string> collection)
        {
            var regex = string.Join("|", collection.Where(x => x.StartsWith("#") == false));
            return new Regex(@"\b(" + GetRegexStr(regex) + @")\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        #region Dispose
        private bool isDisposed;
        public void Dispose()
        {
            if (!isDisposed)
            {
                isDisposed = true;
                Properties.Settings.Default.PropertyChanged -= Default_PropertyChanged;
            }
        }
        #endregion
    }
}
