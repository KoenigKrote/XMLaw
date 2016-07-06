using System;
using System.ComponentModel;
using System.Windows.Input;
using XMLaw.Model;

namespace XMLaw.ViewModel
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        private ClientModel client;
        private string displayMessage;
        private ICommand btnSave;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ClientViewModel()
        {
            client = new ClientModel();
        }

        public ClientModel ClientModel
        {
            get { return client; }
        }

        public string DisplayMessage
        {
            get { return displayMessage; }
            set
            {
                if( displayMessage != value)
                {
                    displayMessage = value;
                    OnPropertyChanged("DisplayMessage");
                }
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (btnSave == null)
                    btnSave = new Save();
                return btnSave;
            }
            set { btnSave = value; }
        }

        protected class Save : ICommand
        {
            public bool CanExecute(object param) { return true; }
            public event EventHandler CanExecuteChanged; //Compiler yells at you if you don't implement this from inhereted ICommand
            public void Execute(object param)
            {
                ClientViewModel viewModel = (ClientViewModel)param;
                //TODO: Insert XML serialization and save to a file

                //Placeholder to make sure the button works
                viewModel.DisplayMessage = "You clicked the button at " + DateTime.Now;
            }
        }


    }
}
