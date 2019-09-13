using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using RandomWord.Models;
using RandomWord.Views;
using System.ComponentModel;
using RandomWord.Services;

namespace RandomWord.ViewModels
{
    public class RandomViewModel : INotifyPropertyChanged
    {
        public string Item { get; set; }
        public Command LoadItemsCommand { get; set; }

        public RandomViewModel()
        {
            Item = "random";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        async Task ExecuteLoadItemsCommand()
        {
            try
            {
                var item = await new WordDataStore().GetItemsAsync(true);
                Random rnd = new Random();
                int randomIndex = rnd.Next(item.Items.Count);
                Item = item.Items[randomIndex];
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Item"));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {

            }
        }
    }
}