﻿#pragma checksum "..\..\..\..\Box\Authorization.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3F8D5B4E7AA3F2500018FBCAF2E57F8E3F2EF272"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using EconSense.Box;
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


namespace EconSense.Box {
    
    
    /// <summary>
    /// Authorization
    /// </summary>
    public partial class Authorization : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\Box\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Minimized;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Box\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Box\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Box\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PasswordBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Box\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBoxHide;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Box\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox View;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Box\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Enter;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Box\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EconSense;component/box/authorization.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Box\Authorization.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Minimized = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Box\Authorization.xaml"
            this.Minimized.Click += new System.Windows.RoutedEventHandler(this.Minimized_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Close = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Box\Authorization.xaml"
            this.Close.Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LoginBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.PasswordBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\..\Box\Authorization.xaml"
            this.PasswordBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PasswordBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PasswordBoxHide = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.View = ((System.Windows.Controls.CheckBox)(target));
            
            #line 39 "..\..\..\..\Box\Authorization.xaml"
            this.View.Checked += new System.Windows.RoutedEventHandler(this.View_Checked);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\..\Box\Authorization.xaml"
            this.View.Unchecked += new System.Windows.RoutedEventHandler(this.View_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Enter = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\Box\Authorization.xaml"
            this.Enter.Click += new System.Windows.RoutedEventHandler(this.Enter_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Exit = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\Box\Authorization.xaml"
            this.Exit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

