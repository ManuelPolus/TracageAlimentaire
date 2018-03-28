using App2.DAL;
using App2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class MainViewModel
    {
        public INavigation Navigation { get; set; }

        public async void Jefedechos()
        {
            RestClient<Utilisateur> client = new RestClient<Utilisateur>("/utilisateurs");
            Utilisateur bob =  new Utilisateur();
           await client.SaveItemAsync(bob);
        }

    }
}
