﻿#pragma checksum "..\..\..\Windows\AddEditOrderPositionWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CC51E0A6B5C752E48024E43202AB822AE53392748F43D44729C1AF3362BC3B50"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CarService.Windows;
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


namespace CarService.Windows {
    
    
    /// <summary>
    /// AddEditOrderPositionWindow
    /// </summary>
    public partial class AddEditOrderPositionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitleTb;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DetailOrServiceTxt;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChooseDetailOrServiceBtn;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox amountTxt;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox availabilityTxt;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceTxt;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sumTxt;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/CarService;component/windows/addeditorderpositionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
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
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
            this.btnMinimize.Click += new System.Windows.RoutedEventHandler(this.btnMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 14 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TitleTb = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.DetailOrServiceTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ChooseDetailOrServiceBtn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
            this.ChooseDetailOrServiceBtn.Click += new System.Windows.RoutedEventHandler(this.ChooseDetailOrServiceBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.amountTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
            this.amountTxt.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.amountTxt_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.availabilityTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.priceTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.sumTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.SaveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
            this.SaveBtn.Click += new System.Windows.RoutedEventHandler(this.SaveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.CancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\Windows\AddEditOrderPositionWindow.xaml"
            this.CancelBtn.Click += new System.Windows.RoutedEventHandler(this.CancelBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

