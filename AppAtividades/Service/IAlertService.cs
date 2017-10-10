using System;
using System.Threading.Tasks;

namespace AppAtividades.Service
{
	public interface IAlertService
	{
		Task ShowAsync(string title, string message, string buttonOk);
		Task<bool> ShowAsyncConfirm(string title, string message, string buttonOk, string buttonCancel);
	}
}
