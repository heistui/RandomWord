using RandomWord.Models;
using RandomWord.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RandomWord.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RandomWordPage : ContentPage
    {
        RandomViewModel viewModel;
        public RandomWordPage()
        {
            InitializeComponent();
            viewModel = new RandomViewModel();
            BindingContext = viewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}