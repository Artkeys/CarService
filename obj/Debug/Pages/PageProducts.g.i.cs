﻿#pragma checksum "..\..\..\Pages\PageProducts.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "54B333405E161ED90D457BDF63BEDECFF66467CADBC9801023DB7221C664EAAA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CarService.Pages;
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


namespace CarService.Pages {
    
    
    /// <summary>
    /// PageProducts
    /// </summary>
    public partial class PageProducts : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 20 "..\..\..\Pages\PageProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTxt;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\PageProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox AvailabilityCheckBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\PageProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button resetBtn;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Pages\PageProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddProductBtn;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Pages\PageProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView productListView;
        
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
            System.Uri resourceLocater = new System.Uri("/CarService;component/pages/pageproducts.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PageProducts.xaml"
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
            this.searchTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\..\Pages\PageProducts.xaml"
            this.searchTxt.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.searchTxt_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AvailabilityCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 22 "..\..\..\Pages\PageProducts.xaml"
            this.AvailabilityCheckBox.Checked += new System.Windows.RoutedEventHandler(this.AvailabilityCheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\Pages\PageProducts.xaml"
            this.AvailabilityCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.AvailabilityCheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.resetBtn = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Pages\PageProducts.xaml"
            this.resetBtn.Click += new System.Windows.RoutedEventHandler(this.resetBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddProductBtn = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Pages\PageProducts.xaml"
            this.AddProductBtn.Click += new System.Windows.RoutedEventHandler(this.AddProductBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.productListView = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 6:
            
            #line 62 "..\..\..\Pages\PageProducts.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditBtn_Click);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 63 "..\..\..\Pages\PageProducts.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteBtn_Click);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 65 "..\..\..\Pages\PageProducts.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addAmountBtn_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
