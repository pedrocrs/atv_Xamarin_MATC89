using AppFlyout.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFlyout.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel 
    {
        private string itemId;
        private string nome;
        private string sipnose;
        private string ano;
        private Int32 qtdOscars;
        private string atores;
        public string Id { get; set; }

        public string Nome
        {
            get => nome;
            set => SetProperty(ref nome, value);
        }

        public string Sinopse
        {
            get => sipnose;
            set => SetProperty(ref sipnose, value);
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

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Nome = item.Nome;
                Sinopse = item.Sinopse;
                Ano = item.Ano;
                QtdOscars = item.QtdOscars;
                Atores = item.Atores;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
