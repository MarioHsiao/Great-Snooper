﻿#pragma checksum "..\..\Settings.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "765108C7E32E3873CE47C94ED0317595"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace MySnooper {
    
    
    /// <summary>
    /// UserSettings
    /// </summary>
    public partial class UserSettings : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorPicker UserMessageColor;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorPicker ChannelMessageColor;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorPicker JoinMessageColor;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorPicker PartMessageColor;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorPicker QuitMessageColor;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorPicker ActionMessageColor;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorPicker NoticeMessageColor;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorPicker OfflineMessageColor;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorPicker BuddyJoinMessageColor;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MySnooper;component/settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Settings.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UserMessageColor = ((Xceed.Wpf.Toolkit.ColorPicker)(target));
            
            #line 36 "..\..\Settings.xaml"
            this.UserMessageColor.SelectedColorChanged += new System.Windows.RoutedPropertyChangedEventHandler<System.Windows.Media.Color>(this.ColorChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ChannelMessageColor = ((Xceed.Wpf.Toolkit.ColorPicker)(target));
            
            #line 39 "..\..\Settings.xaml"
            this.ChannelMessageColor.SelectedColorChanged += new System.Windows.RoutedPropertyChangedEventHandler<System.Windows.Media.Color>(this.ColorChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.JoinMessageColor = ((Xceed.Wpf.Toolkit.ColorPicker)(target));
            
            #line 42 "..\..\Settings.xaml"
            this.JoinMessageColor.SelectedColorChanged += new System.Windows.RoutedPropertyChangedEventHandler<System.Windows.Media.Color>(this.ColorChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PartMessageColor = ((Xceed.Wpf.Toolkit.ColorPicker)(target));
            
            #line 45 "..\..\Settings.xaml"
            this.PartMessageColor.SelectedColorChanged += new System.Windows.RoutedPropertyChangedEventHandler<System.Windows.Media.Color>(this.ColorChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.QuitMessageColor = ((Xceed.Wpf.Toolkit.ColorPicker)(target));
            
            #line 48 "..\..\Settings.xaml"
            this.QuitMessageColor.SelectedColorChanged += new System.Windows.RoutedPropertyChangedEventHandler<System.Windows.Media.Color>(this.ColorChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ActionMessageColor = ((Xceed.Wpf.Toolkit.ColorPicker)(target));
            
            #line 51 "..\..\Settings.xaml"
            this.ActionMessageColor.SelectedColorChanged += new System.Windows.RoutedPropertyChangedEventHandler<System.Windows.Media.Color>(this.ColorChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.NoticeMessageColor = ((Xceed.Wpf.Toolkit.ColorPicker)(target));
            
            #line 54 "..\..\Settings.xaml"
            this.NoticeMessageColor.SelectedColorChanged += new System.Windows.RoutedPropertyChangedEventHandler<System.Windows.Media.Color>(this.ColorChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.OfflineMessageColor = ((Xceed.Wpf.Toolkit.ColorPicker)(target));
            
            #line 57 "..\..\Settings.xaml"
            this.OfflineMessageColor.SelectedColorChanged += new System.Windows.RoutedPropertyChangedEventHandler<System.Windows.Media.Color>(this.ColorChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BuddyJoinMessageColor = ((Xceed.Wpf.Toolkit.ColorPicker)(target));
            
            #line 60 "..\..\Settings.xaml"
            this.BuddyJoinMessageColor.SelectedColorChanged += new System.Windows.RoutedPropertyChangedEventHandler<System.Windows.Media.Color>(this.ColorChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

