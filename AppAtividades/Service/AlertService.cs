﻿using System;
using System.Threading.Tasks;

namespace AppAtividades.Service
{
    public class AlertService : IAlertService
    {

        public async Task ShowAsync(string title, string message, string buttonOk)
        {
            await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(title, message, buttonOk);
        }

        public async Task<bool> ShowAsyncConfirm(string title, string message, string buttonOk, string buttonCancel)
        {
            bool retorno = await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(title, message, buttonOk, buttonCancel);

            return retorno;
        }
    }
}
