﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Tracage.DAL;
using Tracage.Models;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class ProductDetailViewModel : INotifyPropertyChanged
    {

        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Product Product { get; set; }

        public ProductDetailViewModel(Product p)
        {
            this.Product = p;
        }

        
    }
}
