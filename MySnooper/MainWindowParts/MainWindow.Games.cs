﻿using MahApps.Metro.Controls;
using System;
using System.ComponentModel;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;


namespace MySnooper
{
    public partial class MainWindow : MetroWindow
    {
        private enum StartedGameTypes { Join, Host };
        private System.Diagnostics.Process gameProcess;
        private StartedGameTypes startedGameType = StartedGameTypes.Join;

        // Joining a game
        //private Game StartedGame;
        //private Channel StartedGameChannel;
        private bool SilentJoined;
        private bool ExitSnooper;

        // Hosting a game
        private Hosting HostingWindow;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Check if WA.exe is set correctly
        private bool CheckWAExe()
        {
            if (Properties.Settings.Default.WaExe.Length == 0)
            {
                MessageBox.Show(this, "Please set your WA.exe in the Settings!", "WA.exe missing", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

            if (!System.IO.File.Exists(Properties.Settings.Default.WaExe))
            {
                MessageBox.Show(this, "WA.exe doesn't exist!", "WA.exe missing", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

            return true;
        }

        // The method that will start the thread which will open the game
        private void JoinGame(Game game, bool silent = false, bool exit = false)
        {
            if (gameProcess != null)
            {
                MessageBox.Show(this, "You are already in a game!", "Fail", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!CheckWAExe())
                return;

            if (searchHere != null && Properties.Settings.Default.AskLeagueSearcherOff)
            {
                MessageBoxResult res = MessageBox.Show("Would you like to turn off league searcher?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                    ClearSpamming();
            }

            if (Notifications.Count != 0 && Properties.Settings.Default.AskNotificatorOff)
            {
                MessageBoxResult res = MessageBox.Show("Would you like to turn off notificator?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    Notifications.Clear();
                    NotificatorImage.Source = NotificatorOff;
                }
            }

            if (gameListChannel != null && !snooperClosing)
            {
                SilentJoined = silent;
                ExitSnooper = exit;

                startedGameType = StartedGameTypes.Join;
                gameProcess = new System.Diagnostics.Process();
                gameProcess.StartInfo.UseShellExecute = false;
                gameProcess.StartInfo.FileName = Properties.Settings.Default.WaExe;
                gameProcess.StartInfo.Arguments = "wa://" + game.Address + "?gameid=" + game.ID + "&scheme=" + gameListChannel.Scheme;
                if (gameProcess.Start())
                {
                    if (Properties.Settings.Default.MessageJoinedGame && !SilentJoined)
                    {
                        SendMessageToChannel(">is joining a game: " + game.Name, gameListChannel);
                    }
                    if (Properties.Settings.Default.MarkAway)
                        SendMessageToChannel("/away", null);
                }
                else
                {
                    gameProcess.Dispose();
                    gameProcess = null;
                }
            }
        }

        private void GameProcess()
        {
            if (gameProcess.HasExited)
            {
                SendMessageToChannel("/back", null);
                gameProcess.Dispose();
                gameProcess = null;
            }
            else if (startedGameType == StartedGameTypes.Join && ExitSnooper)
            {
                IntPtr hwnd = FindWindow("Worms2D", null);
                if (hwnd != IntPtr.Zero)
                {
                    snooperClosing = true;
                    this.Close();
                    return;
                }
            }
        }

        // If we'd like to join a game (double click)
        private void GameDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            if (lb.SelectedItem != null)
            {
                JoinGame((Game)lb.SelectedItem);
            }
            lb.SelectedIndex = -1;
            e.Handled = true;
        }

        // If we'd like to join a game (context menu click)
        private void JoinGameClick(object sender, RoutedEventArgs e)
        {
            ListBox lb = (ListBox)((MenuItem)sender).Tag;
            if (lb.SelectedItem != null)
            {
                JoinGame((Game)lb.SelectedItem);
            }
            lb.SelectedIndex = -1;
            e.Handled = true;
        }

        private void JoinAndClose(object sender, RoutedEventArgs e)
        {
            ListBox lb = (ListBox)((MenuItem)sender).Tag;
            if (lb.SelectedItem != null)
            {
                JoinGame((Game)lb.SelectedItem, false, true);
            }
            lb.SelectedIndex = -1;
            e.Handled = true;
        }

        // Silent join
        private void SilentJoin(object sender, RoutedEventArgs e)
        {
            ListBox lb = (ListBox)((MenuItem)sender).Tag;
            if (lb.SelectedItem != null)
            {
                JoinGame((Game)lb.SelectedItem, true);
            }
            lb.SelectedIndex = -1;
            e.Handled = true;
        }

        // Silent join and close
        private void SilentJoinAndClose(object sender, RoutedEventArgs e)
        {
            ListBox lb = (ListBox)((MenuItem)sender).Tag;
            if (lb.SelectedItem != null)
            {
                JoinGame((Game)lb.SelectedItem, true, true);
            }
            lb.SelectedIndex = -1;
            e.Handled = true;
        }

        // When we want to refresh the game list
        // GameListForce is checked in MainWindow.xaml.cs : ClockTick()
        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            gameListForce = true;
            e.Handled = true;
        }

        public void NotificatorFound(string str, Channel ch)
        {
            if (!isWindowFocused)
                this.FlashWindow();
            myNotifyIcon.ShowBalloonTip(null, str, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Info);

            SoundPlayer sp;
            if (Properties.Settings.Default.NotificatorSoundEnabled && SoundEnabled && soundPlayers.TryGetValue("NotificatorSound", out sp))
            {
                try
                {
                    sp.Play();
                }
                catch (Exception ex)
                {
                    ErrorLog.Log(ex);
                }
            }
        }
    }
}
