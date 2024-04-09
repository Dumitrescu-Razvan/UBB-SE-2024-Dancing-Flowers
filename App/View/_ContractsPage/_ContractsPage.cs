using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ISSProject
{
    public partial class ContractsPage : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<Contract> Contracts { get; set; }
        private Contract _selectedContract = null!;
        public Contract SelectedContract
        {
            get { return _selectedContract; }
            set
            {
                if (_selectedContract != value)
                {
                    _selectedContract = value;
                    RaisePropertyChanged(nameof(SelectedContract));
                    RaisePropertyChanged(nameof(IsContractSelected));
                }
            }
        }

        public bool IsContractSelected => SelectedContract != null;

        public new event PropertyChangedEventHandler? PropertyChanged;

        public ContractsPage()
        {
            InitializeComponent();
            Contracts = new ObservableCollection<Contract>()
            {
                new Contract { Artist = new Artist { Name = "Artist 1" }, ExpDate = DateTime.Now.AddMonths(1) },
                new Contract { Artist = new Artist { Name = "Artist 2" }, ExpDate = DateTime.Now.AddMonths(2) },
                new Contract { Artist = new Artist { Name = "Artist 3" }, ExpDate = DateTime.Now.AddMonths(3) }
            };
            BindingContext = this;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddContract_Clicked(object sender, EventArgs e)
        {
            // Add your logic for adding a new contract here
            Contracts.Add(new Contract { Artist = new Artist { Name = "New Artist" }, ExpDate = DateTime.Now.AddMonths(1) });
        }

        private void CancelContract_Clicked(object sender, EventArgs e)
        {
            // Add your logic for canceling a contract here
            if (SelectedContract != null)
                Contracts.Remove(SelectedContract);
        }

        private void RenewContract_Clicked(object sender, EventArgs e)
        {
            // Add your logic for renewing a contract here
            if (SelectedContract != null)
                SelectedContract.ExpDate = SelectedContract.ExpDate.AddMonths(1);
        }
    }

    public class Contract
    {
        public Artist? Artist { get; set; }
        public DateTime ExpDate { get; set; }
    }

    public class Artist
    {
        public string? Name { get; set; }
    }
}
