﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00DFDC8F7138B77F8779C10FC51774C3F4CE852A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Record_Manager;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Record_Manager {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox search_box;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox boolean_combo;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox search_box2;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox search_type_combobox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox search_by_combo;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label author_textbox;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock title_textbox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock abstract_textbox;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label journal_textbox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label year_textbox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox gotoBox;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label open_file_button;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox search_result_textbox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Record Manager;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 14 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Label_MouseEnter);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Label_MouseLeave);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.BeginSearch);
            
            #line default
            #line hidden
            return;
            case 2:
            this.search_box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.boolean_combo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.search_box2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.search_type_combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\..\MainWindow.xaml"
            this.search_type_combobox.DropDownClosed += new System.EventHandler(this.search_type_combobox_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 6:
            this.search_by_combo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.author_textbox = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.title_textbox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.abstract_textbox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.journal_textbox = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.year_textbox = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            
            #line 57 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Label_MouseEnter);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Label_MouseLeave);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Back);
            
            #line default
            #line hidden
            return;
            case 13:
            this.gotoBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 58 "..\..\..\MainWindow.xaml"
            this.gotoBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ClearTextBox);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 59 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Label_MouseEnter);
            
            #line default
            #line hidden
            
            #line 59 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Label_MouseLeave);
            
            #line default
            #line hidden
            
            #line 59 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Next);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 61 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Label_MouseEnter);
            
            #line default
            #line hidden
            
            #line 61 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Label_MouseLeave);
            
            #line default
            #line hidden
            
            #line 61 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.GoTo);
            
            #line default
            #line hidden
            return;
            case 16:
            this.open_file_button = ((System.Windows.Controls.Label)(target));
            
            #line 62 "..\..\..\MainWindow.xaml"
            this.open_file_button.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Label_MouseEnter);
            
            #line default
            #line hidden
            
            #line 62 "..\..\..\MainWindow.xaml"
            this.open_file_button.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Label_MouseLeave);
            
            #line default
            #line hidden
            
            #line 62 "..\..\..\MainWindow.xaml"
            this.open_file_button.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OpenFile);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 64 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Label_MouseEnter);
            
            #line default
            #line hidden
            
            #line 64 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Label_MouseLeave);
            
            #line default
            #line hidden
            
            #line 64 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Back);
            
            #line default
            #line hidden
            return;
            case 18:
            this.search_result_textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 19:
            
            #line 66 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Label_MouseEnter);
            
            #line default
            #line hidden
            
            #line 66 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Label_MouseLeave);
            
            #line default
            #line hidden
            
            #line 66 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Next);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

