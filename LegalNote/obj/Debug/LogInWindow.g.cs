﻿#pragma checksum "..\..\LogInWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4232BA129DBBEC8F235C36E4FA943BD0232E6996"
//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

using LegalNote;
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


namespace LegalNote {
    
    
    /// <summary>
    /// LogInWindowxaml
    /// </summary>
    public partial class LogInWindowxaml : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\LogInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserName;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\LogInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Login;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\LogInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\LogInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Alert;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\LogInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Registrati;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\LogInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DbChange;
        
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
            System.Uri resourceLocater = new System.Uri("/LegalNote;component/loginwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LogInWindow.xaml"
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
            
            #line 10 "..\..\LogInWindow.xaml"
            ((LegalNote.LogInWindowxaml)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Entra);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UserName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Login = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\LogInWindow.xaml"
            this.Login.Click += new System.Windows.RoutedEventHandler(this.Login_click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 20 "..\..\LogInWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.Alert = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Registrati = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\LogInWindow.xaml"
            this.Registrati.Click += new System.Windows.RoutedEventHandler(this.Registrati_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DbChange = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\LogInWindow.xaml"
            this.DbChange.Click += new System.Windows.RoutedEventHandler(this.CambiaDB_Click);
            
            #line default
            #line hidden
            
            #line 38 "..\..\LogInWindow.xaml"
            this.DbChange.Loaded += new System.Windows.RoutedEventHandler(this.DbChange_Loaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
