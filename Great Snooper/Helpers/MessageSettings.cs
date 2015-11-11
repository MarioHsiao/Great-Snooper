﻿using GreatSnooper.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace GreatSnooper.Helpers
{
    public static class MessageSettings
    {
        #region Properties
        public static MessageSetting ChannelMessage { get; private set; }
        public static MessageSetting JoinMessage { get; private set; }
        public static MessageSetting QuitMessage { get; private set; }
        public static MessageSetting PartMessage { get; private set; }
        public static MessageSetting SystemMessage { get; private set; }
        public static MessageSetting ActionMessage { get; private set; }
        public static MessageSetting UserMessage { get; private set; }
        public static MessageSetting NoticeMessage { get; private set; }
        public static MessageSetting MessageTimeStyle { get; private set; }
        public static MessageSetting HyperLinkStyle { get; private set; }
        public static MessageSetting LeagueFoundMessage { get; private set; }
        #endregion


        // This method ensures that the initialization will be made from the appropriate thread
        public static void Initialize()
        {
            ChannelMessage = SettingToObj(Properties.Settings.Default.ChannelMessageStyle, Message.MessageTypes.Channel, false, false);
            JoinMessage = SettingToObj(Properties.Settings.Default.JoinMessageStyle, Message.MessageTypes.Join, true, false);
            QuitMessage = SettingToObj(Properties.Settings.Default.QuitMessageStyle, Message.MessageTypes.Quit, false, false);
            PartMessage = SettingToObj(Properties.Settings.Default.PartMessageStyle, Message.MessageTypes.Part, true, false);
            SystemMessage = SettingToObj(Properties.Settings.Default.SystemMessageStyle, Message.MessageTypes.Offline, true, false);
            ActionMessage = SettingToObj(Properties.Settings.Default.ActionMessageStyle, Message.MessageTypes.Action, false, false);
            UserMessage = SettingToObj(Properties.Settings.Default.UserMessageStyle, Message.MessageTypes.User, false, false);
            NoticeMessage = SettingToObj(Properties.Settings.Default.NoticeMessageStyle, Message.MessageTypes.Notice, false, false);
            MessageTimeStyle = SettingToObj(Properties.Settings.Default.MessageTimeStyle, Message.MessageTypes.Time, true, true);
            HyperLinkStyle = SettingToObj(Properties.Settings.Default.HyperLinkStyle, Message.MessageTypes.Hyperlink, true, true);
            LeagueFoundMessage = SettingToObj(Properties.Settings.Default.LeagueFoundMessageStyle, Message.MessageTypes.League, true, true);
        }

        public static MessageSetting SettingToObj(string setting, Message.MessageTypes type, bool isFixedText, bool oneColorOnly)
        {
            var things = setting.Split('|');

            var nickColor = Color.FromRgb(
                byte.Parse(things[0].Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                byte.Parse(things[0].Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                byte.Parse(things[0].Substring(4, 2), System.Globalization.NumberStyles.HexNumber)
            );

            if (oneColorOnly == false)
            {
                if (things.Length == 7) // Old style messsage settings
                {
                    var help = new List<string>(things);
                    help.Insert(0, help[0]);
                    things = help.ToArray();
                }

                var messageColor = Color.FromRgb(
                    byte.Parse(things[1].Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                    byte.Parse(things[1].Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                    byte.Parse(things[1].Substring(4, 2), System.Globalization.NumberStyles.HexNumber)
                );

                return new MessageSetting(nickColor, messageColor, double.Parse(things[2]), things[3], things[4], things[5], things[6], things[7], type, isFixedText);
            }
            else
                return new MessageSetting(nickColor, double.Parse(things[1]), things[2], things[3], things[4], things[5], things[6], type, isFixedText);
        }


        public static string ObjToSetting(MessageSetting obj)
        {
            var sb = new System.Text.StringBuilder();
            // NickColor
            sb.Append(string.Format("{0:X2}{1:X2}{2:X2}", obj.NickColor.Color.R, obj.NickColor.Color.G, obj.NickColor.Color.B));
            sb.Append('|');
            if (obj.OneColorOnly == false)
            {
                // MessageColor
                sb.Append(string.Format("{0:X2}{1:X2}{2:X2}", obj.MessageColor.Color.R, obj.MessageColor.Color.G, obj.MessageColor.Color.B));
                sb.Append('|');
            }
            // Size
            sb.Append(obj.Size);
            sb.Append('|');
            // Bold
            sb.Append(obj.Bold == FontWeights.Bold ? 1 : 0);
            sb.Append('|');
            // Italic
            sb.Append(obj.Italic == FontStyles.Italic ? 1 : 0);
            sb.Append('|');
            // Strikethrough
            sb.Append((obj.Strikethrough.HasValue && obj.Strikethrough.Value) ? 1 : 0);
            sb.Append('|');
            // Underline
            sb.Append((obj.Underline.HasValue && obj.Underline.Value) ? 1 : 0);
            sb.Append('|');
            // Font family
            sb.Append(obj.FontFamily.ToString());

            return sb.ToString();
        }

        public static void LoadSettingsFor(System.Windows.Documents.TextElement element, MessageSetting setting)
        {
            element.FontFamily = setting.FontFamily;
            element.FontWeight = setting.Bold;
            element.FontStyle = setting.Italic;
            element.FontSize = setting.Size;
            element.FontWeight = setting.Bold;
            if (element is Inline)
            {
                Inline inline = (Inline)element;
                inline.TextDecorations = setting.Textdecorations;
            }
            else if (element is Paragraph)
            {
                Paragraph p = (Paragraph)element;
                p.TextDecorations = setting.Textdecorations;
            }
        }
    }
}