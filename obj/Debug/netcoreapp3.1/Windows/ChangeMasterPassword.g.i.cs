// Updated by XamlIntelliSenseFileGenerator 18.01.2020 18:49:18
#pragma checksum "..\..\..\..\Windows\ChangeMasterPassword.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A52A2B6A01E7FA5AFF03FA3C04CBB0DD54823489"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using OlibPasswordManager.Windows;
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


namespace OlibPasswordManager.Windows
{


    /// <summary>
    /// ChangeMasterPassword
    /// </summary>
    public partial class ChangeMasterPassword : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/OlibPasswordManager;V1.1.0.110;component/windows/changemasterpassword.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\Windows\ChangeMasterPassword.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.txtOldPassword = ((System.Windows.Controls.PasswordBox)(target));
                    return;
                case 2:
                    this.txtOldPasswordCollapsed = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.cbOldHide = ((System.Windows.Controls.CheckBox)(target));

#line 24 "..\..\..\..\Windows\ChangeMasterPassword.xaml"
                    this.cbOldHide.Checked += new System.Windows.RoutedEventHandler(this.CollapsedPassword);

#line default
#line hidden

#line 24 "..\..\..\..\Windows\ChangeMasterPassword.xaml"
                    this.cbOldHide.Unchecked += new System.Windows.RoutedEventHandler(this.CollapsedPassword);

#line default
#line hidden
                    return;
                case 4:
                    this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));

#line 30 "..\..\..\..\Windows\ChangeMasterPassword.xaml"
                    this.txtPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.txtPassword_PasswordChanged);

#line default
#line hidden
                    return;
                case 5:
                    this.txtPasswordCollapsed = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.cbHide = ((System.Windows.Controls.CheckBox)(target));

#line 32 "..\..\..\..\Windows\ChangeMasterPassword.xaml"
                    this.cbHide.Checked += new System.Windows.RoutedEventHandler(this.CollapsedPassword);

#line default
#line hidden

#line 32 "..\..\..\..\Windows\ChangeMasterPassword.xaml"
                    this.cbHide.Unchecked += new System.Windows.RoutedEventHandler(this.CollapsedPassword);

#line default
#line hidden
                    return;
                case 7:
                    this.pbHard = ((System.Windows.Controls.ProgressBar)(target));

#line 35 "..\..\..\..\Windows\ChangeMasterPassword.xaml"
                    this.pbHard.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.pbHard_ValueChanged);

#line default
#line hidden
                    return;
                case 8:

#line 43 "..\..\..\..\Windows\ChangeMasterPassword.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.PasswordBox TxtOldPassword;
        internal System.Windows.Controls.TextBox TxtOldPasswordCollapsed;
        internal System.Windows.Controls.PasswordBox TxtPassword;
        internal System.Windows.Controls.TextBox TxtPasswordCollapsed;
        internal System.Windows.Controls.CheckBox CbHide;
        internal System.Windows.Controls.ProgressBar PbHard;
        internal System.Windows.Controls.CheckBox CbOldHide;
    }
}

