﻿using gamevault.Helper;
using gamevault.Models;
using gamevault.UserControls;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace gamevault.ViewModels
{
    public enum MainControl
    {
        Library = 0,
        Downloads = 1,
        Installs = 2,
        Community = 3,
        Settings = 4,
        AdminConsole = 5
    }
    internal class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            m_Library = new LibraryUserControl();
            m_Settings = new SettingsUserControl();
            m_Downloads = new DownloadsUserControl();
            m_Installs = new InstallUserControl();
            m_Community = new CommunityUserControl();
            m_AdminConsole = new AdminConsoleUserControl();
        }
        #region Singleton
        private static MainWindowViewModel instance = null;
        private static readonly object padlock = new object();

        public static MainWindowViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MainWindowViewModel();
                    }
                    return instance;
                }
            }
        }
        #endregion
        #region AppBarProperties 
        private bool m_IsAppBarOpen { get; set; }
        public bool IsAppBarOpen
        {
            get { return m_IsAppBarOpen; }
            set { m_IsAppBarOpen = value; OnPropertyChanged(); }
        }
        private string m_AppBarText { get; set; }
        public string AppBarText
        {
            get { return m_AppBarText; }
            set { m_AppBarText = value; OnPropertyChanged(); IsAppBarOpen = true; }
        }
        private User? m_UserIcon { get; set; }
        public User? UserIcon
        {
            get { return m_UserIcon; }
            set { m_UserIcon = value; OnPropertyChanged(); }
        }       
        #endregion
        #region PrivateMembers        
        private int m_ActiveControlIndex = -1;
        private UserControl m_ActiveControl { get; set; }
        private LibraryUserControl m_Library { get; set; }

        private SettingsUserControl m_Settings { get; set; }
        private DownloadsUserControl m_Downloads { get; set; }
        private InstallUserControl m_Installs { get; set; }
        private CommunityUserControl m_Community { get; set; }
        private AdminConsoleUserControl m_AdminConsole { get; set; }
        #endregion
        public MainControl LastMainControl { get; set; }
        public int ActiveControlIndex
        {
            get { return m_ActiveControlIndex; }
            set { m_ActiveControlIndex = value; OnPropertyChanged(); }
        }
        public UserControl ActiveControl
        {
            get { return m_ActiveControl; }
            set { m_ActiveControl = value; OnPropertyChanged(); }
        }
        internal LibraryUserControl Library
        {
            get { return m_Library; }
            private set { m_Library = value; }
        }
        internal SettingsUserControl Settings
        {
            get { return m_Settings; }
            private set { m_Settings = value; }
        }
        internal DownloadsUserControl Downloads
        {
            get { return m_Downloads; }
            private set { m_Downloads = value; }
        }
        internal InstallUserControl Installs
        {
            get { return m_Installs; }
            private set { m_Installs = value; }
        }
        internal CommunityUserControl Community
        {
            get { return m_Community; }
            private set { m_Community = value; }
        }
        internal AdminConsoleUserControl AdminConsole
        {
            get { return m_AdminConsole; }
            private set { m_AdminConsole = value; }
        }
        public void SetActiveControl(MainControl mainControl)
        {
            ActiveControlIndex = (int)mainControl;
        }
        public void SetActiveControl(UserControl userControl)
        {
            ActiveControl = userControl;
            ActiveControlIndex = -1;
        }
        public void UndoActiveControl()
        {
            ActiveControlIndex = (int)LastMainControl;
        }
    }
}
