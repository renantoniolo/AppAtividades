using System;
using System.Collections.Generic;
using AppAtividades.ViewModel;
using Xamarin.Forms;

namespace AppAtividades.View
{
    public partial class ListAtividadesViewPage : ContentPage
    {
        public ListAtividadesViewPage()
        {
            InitializeComponent();

            this.BindingContext = new ListAtividadesViewModel();
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			((ListAtividadesViewModel)this.BindingContext).ThisOnAppearing();
		}
    }
}
