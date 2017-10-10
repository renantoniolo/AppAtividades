using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using AppAtividades.Model;
using AppAtividades.Service;
using Realms;
using Xamarin.Forms;

namespace AppAtividades.ViewModel
{
    public class ListAtividadesViewModel : ViewModelBase
    {

        private List<Atividade> myList;
        private static IAlertService _alertService;

        public ListAtividadesViewModel()
        {
            // instancia servico de alert
            _alertService = DependencyService.Get<IAlertService>();

            // instancia a lista a ser exibida
            ListaAtividades = new ObservableCollection<Atividade>();

            // comand
            this.InformacoesCommand = new Command(this.Informacoes);
            this.AdicionarCommand = new Command(this.Adicionar);

          
        }


		internal void ThisOnAppearing()
		{
			// carrega jSOn
			CarregaAtividades();

		}

        private void CarregaAtividades(){

            // exibe carregando
            Load = true;

            myList = new List<Atividade>();

            Atividade atividade = new Atividade();
            atividade.codigoatividade = 1;
            atividade.nomeatividade = "Volei";
            atividade.local = "Quadra 1";
            atividade.horarioinicio = "11:00";
            atividade.horariofim = "11:30";
            atividade.cor = "#000";
            myList.Add(atividade);

			Atividade atividade1 = new Atividade();
			atividade1.codigoatividade = 2;
			atividade1.nomeatividade = "Basquete";
			atividade1.local = "Quadra 2";
            atividade1.horarioinicio = "11:30";
            atividade1.horariofim = "12:00";
            atividade1.cor = "#000";
            myList.Add(atividade1);

			Atividade atividade2 = new Atividade();
			atividade2.codigoatividade = 3;
			atividade2.nomeatividade = "Futebol";
			atividade2.local = "Quadra 3";
            atividade2.horarioinicio = "13:00";
            atividade2.horariofim = "14:00";
            atividade2.cor = "#000";
            myList.Add(atividade2);

            var realm = Realm.GetInstance();

            var myAtividadesCount = realm.All<Atividade>();

            if(myAtividadesCount.Count() > 0){

                foreach(Atividade at in myAtividadesCount){

                    if(at.registrado){
                        // marco como resgistardo
                        myList[at.codigoatividade - 1].registrado = true; 
                        myList[at.codigoatividade - 1].cor = "#FF0000";
                    }

                }
            }

            // alimenta a lista
            ListaAtividades = new ObservableCollection<Atividade>(myList);

			// inibe carregando
			Load = false;

		}

		private bool load;
		public bool Load
		{

			get { return load; }
			set
			{
				load = value;
				this.Notify(nameof(Load));
			}
		}

		private ObservableCollection<Atividade> listaAtividades;
        public ObservableCollection<Atividade> ListaAtividades
		{
			get { return listaAtividades; }
			set
			{
				listaAtividades = value;
				this.Notify(nameof(ListaAtividades));
			}
		}

		private Atividade selectedAtividade;
		public Atividade SelectedAtividade
		{
			get { return selectedAtividade; }
			set
			{
                if (value != null)
                {
                    selectedAtividade = value;
                    AtividadeSelecionada(selectedAtividade);
                }
			}
		}

        private async void AtividadeSelecionada(Atividade selectedAtividade){

			// exibe o alerta
			bool retorno = await _alertService.ShowAsyncConfirm("Deseja se registar nesta Atividade (" + selectedAtividade.nomeatividade + ")?",
									"Nome Atividade: " + selectedAtividade.nomeatividade + "\n" +
									"Local: " + selectedAtividade.local + "\n" +
									"Hora Inicio: " + selectedAtividade.horarioinicio + "\n" +
									"Hora Inicio: " + selectedAtividade.horarioinicio,
									"Sim", "Não");

            if(retorno){ // vamos gravar no base de dados

				// instancio o realm
				var realm = Realm.GetInstance();

                if (selectedAtividade.registrado) selectedAtividade.registrado = false;
                else selectedAtividade.registrado = true;

				realm.Write(() =>
				{
					realm.Add(selectedAtividade,true);
				});

                // carrega novamente
                this.CarregaAtividades();
            }


		}

		public ICommand InformacoesCommand
		{
			get;
			set;
		}

		private async void Informacoes()
		{
			Debug.WriteLine("Abre informacoes");
            await _alertService.ShowAsync("Informativo", "App Atividades - versão 1.0", "Ok");
		}

		public ICommand AdicionarCommand
		{
			get;
			set;
		}

		private async void Adicionar()
		{
			Debug.WriteLine("Em desenvolviemnto.");

            await _alertService.ShowAsync("Atenção","Em Desenvolvimento.","Ok");

		}

	}
}
