﻿#pragma checksum "..\..\ExecutorWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6DC89A6888A8A8BA56198DD56161857110EB1D3BDE299AE3AB539167FBDCD311"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DEMOEKZ;
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


namespace DEMOEKZ {
    
    
    /// <summary>
    /// ExecutorWindow
    /// </summary>
    public partial class ExecutorWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ExecutorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid EnterAsExecutor_Grid;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ExecutorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Login_Text;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ExecutorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Password_Text;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ExecutorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Executor_Grid;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ExecutorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ApplicationsTable;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\ExecutorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search_Text;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\ExecutorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Description_Text;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ExecutorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Status_ComboBox;
        
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
            System.Uri resourceLocater = new System.Uri("/DEMOEKZ;component/executorwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ExecutorWindow.xaml"
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
            this.EnterAsExecutor_Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Login_Text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Password_Text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 14 "..\..\ExecutorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Input_Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Executor_Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.ApplicationsTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.Search_Text = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\ExecutorWindow.xaml"
            this.Search_Text.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_Text_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Description_Text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Status_ComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            
            #line 37 "..\..\ExecutorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Change_App_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 38 "..\..\ExecutorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Change_Description_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

