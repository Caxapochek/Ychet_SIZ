﻿#pragma checksum "..\..\ItemCard.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7888EB1F722E723D489427391F17ECAC65B8703C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using Учет_СИЗ;


namespace Учет_СИЗ {
    
    
    /// <summary>
    /// ItemCard
    /// </summary>
    public partial class ItemCard : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\ItemCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBTitle;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\ItemCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBItem_number;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\ItemCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBQuantity;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\ItemCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBDate_Of_Commissioning;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\ItemCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBService_Life;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\ItemCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBDate_Of_Decommissioning;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\ItemCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSaveItem;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\ItemCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDeleteItem;
        
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
            System.Uri resourceLocater = new System.Uri("/Учет СИЗ;component/itemcard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ItemCard.xaml"
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
            this.TBTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TBItem_number = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TBQuantity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TBDate_Of_Commissioning = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TBService_Life = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TBDate_Of_Decommissioning = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.BtnSaveItem = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\ItemCard.xaml"
            this.BtnSaveItem.Click += new System.Windows.RoutedEventHandler(this.BtnSaveItem_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnDeleteItem = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\ItemCard.xaml"
            this.BtnDeleteItem.Click += new System.Windows.RoutedEventHandler(this.BtnDeleteItem_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

