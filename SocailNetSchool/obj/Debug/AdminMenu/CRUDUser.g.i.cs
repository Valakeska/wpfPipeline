﻿#pragma checksum "..\..\..\AdminMenu\CRUDUser.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7A9B2C886BB0A7D227F8D8C60B7669776A24C843CF04D13C6D79B1CAED634206"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SocailNetSchool.AdminMenu;
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


namespace SocailNetSchool.AdminMenu {
    
    
    /// <summary>
    /// CRUDUser
    /// </summary>
    public partial class CRUDUser : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\AdminMenu\CRUDUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGadmin;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\AdminMenu\CRUDUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneTB;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\AdminMenu\CRUDUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MailTB;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\AdminMenu\CRUDUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SurnameTB;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\AdminMenu\CRUDUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTB;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\AdminMenu\CRUDUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MidnameTB;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\AdminMenu\CRUDUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBRole;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\AdminMenu\CRUDUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginTB;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\AdminMenu\CRUDUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PasswordTB;
        
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
            System.Uri resourceLocater = new System.Uri("/SocailNetSchool;component/adminmenu/cruduser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AdminMenu\CRUDUser.xaml"
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
            this.DGadmin = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            
            #line 11 "..\..\..\AdminMenu\CRUDUser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddDataDGbtn);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 12 "..\..\..\AdminMenu\CRUDUser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateDataDGbtn);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 13 "..\..\..\AdminMenu\CRUDUser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteDataDGbtn);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 14 "..\..\..\AdminMenu\CRUDUser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitBTN);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PhoneTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.MailTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.SurnameTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.NameTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.MidnameTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.CBRole = ((System.Windows.Controls.ComboBox)(target));
            
            #line 27 "..\..\..\AdminMenu\CRUDUser.xaml"
            this.CBRole.Loaded += new System.Windows.RoutedEventHandler(this.CBRole_Loaded);
            
            #line default
            #line hidden
            return;
            case 12:
            this.LoginTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.PasswordTB = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
