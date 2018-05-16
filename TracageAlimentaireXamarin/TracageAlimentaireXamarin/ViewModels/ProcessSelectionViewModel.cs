using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Tracage.DAL;
using Tracage.Models;
using TracageAlimentaireXamarin.BL.Components;
using TracageAlimentaireXamarin.Views;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class ProcessSelectionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Product product;
        private User loginUser;
        private Process selectedProcess;
        private ObservableCollection<Process> processes;
        private int index;

        public INavigation Navigation { get; set; }

        public ICommand ProcessValidationCommand { get; set; }

        public ProcessSelectionViewModel()
        {

        }

        public ProcessSelectionViewModel(Product p, User loginUser)
        {
            ProcessValidationCommand = new Command(ValidateProcessSelection);
            product = p;
            this.loginUser = loginUser;
            RestAccessor<Process> rap = new RestAccessor<Process>(new Process());
            List<Process> pList = new List<Process>();
            pList = rap.GetAsList().ToList();
            this.processes = new ObservableCollection<Process>(pList);
        }

        public ObservableCollection<Process> Processes
        {
            get { return processes; }

            set
            {
                if (processes != value)
                {
                    processes = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ObservableProcesses"));
                }
            }
        }

        public Process SelectedProcess
        {
            get
            {
                return selectedProcess;
            }

            set
            {
                if (selectedProcess != value)
                {
                    selectedProcess = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedProcess"));
                }
            }
        }


        public int Index
        {
            get
            {
                return index;
            }

            private set
            {
                if (index != value)
                {
                    index = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Index"));
                }
            }
        }

        private void ValidateProcessSelection()
        {
            RestAccessor<Process>crap = new RestAccessor<Process>(new Process());
            product.Process = crap.GetByIdentifier(selectedProcess.Id);
            product.ProcessId = product.Process.Id;
            RestAccessor<Product> rap = new RestAccessor<Product>(new Product());
            rap.Update(product, product.QRCode);
            Navigation.PushModalAsync(new NextTreatmentValidationPage(new NextTreatmentValidationViewModel(product, loginUser)));
        }

    }
}
