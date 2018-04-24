﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;
using TracageAlimentaireXamarin.ViewModels;

namespace TracageAlimentaireXamarin.Views
{
    public partial class StepInfoPage : PopupPage
	{
		public StepInfoPage (StepInfoViewModel vm)
		{
            BindingContext = vm;
            vm.Navigation = Navigation;
            InitializeComponent ();
		}


	}
}