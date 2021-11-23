using AppFlyout.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFlyout.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string nome;
        private string sinopse;
        private string ano;
        private Int32 qtdOscars;
        private string atores;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(nome)
                && !String.IsNullOrWhiteSpace(sinopse)
                && !String.IsNullOrWhiteSpace(ano)
                && !String.IsNullOrWhiteSpace(atores);
        }

        public string Nome
        {
            get => nome;
            set => SetProperty(ref nome, value);
        }

        public string Sinopse
        {
            get => sinopse;
            set => SetProperty(ref sinopse, value);
        }

        public string Ano
        {
            get => ano;
            set => SetProperty(ref ano, value);
        }

        public Int32 QtdOscars
        {
            get => qtdOscars;
            set => SetProperty(ref qtdOscars, value);
        }

        public string Atores
        {
            get => atores;
            set => SetProperty(ref atores, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Nome = Nome,
                Sinopse = Sinopse,
                Ano = Ano,
                QtdOscars = QtdOscars,
                Atores = Atores
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
