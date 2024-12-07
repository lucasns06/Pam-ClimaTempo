using ClimaTempo.Models;
using ClimaTempo.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClimaTempo.ViewModels
{ //parcial porque precisa de outro arquivo para funcionar
    public partial class PrevisaoViewModel : ObservableObject
    {
        [ObservableProperty]
        private string cidade; //nome que vai colocar no Binding da label
        [ObservableProperty]
        private string estado;
        [ObservableProperty]
        private string condicao;
        [ObservableProperty]
        private string data;
        [ObservableProperty]
        private string min;
        [ObservableProperty]
        private string max;
        [ObservableProperty]
        private double indiceuv;
        [ObservableProperty]
        private DateTime atualizado_em;
        [ObservableProperty]
        private string condicao_desc;
        [ObservableProperty] //se quer exibir ela, entao é uma observableProperty
        private List<Clima> proximosDias;

        private Previsao previsao;
        private Previsao proxPrevisao;

        //Dados da pesquisa
        [ObservableProperty]
        private string cidade_pesquisada;

        //Dados da lista de cidades
        [ObservableProperty]
        private List<Cidade> cidade_list;

        public ICommand BuscarPrevisaoCommand {  get; }
        public ICommand BuscarCidadesCommand { get; }
        public PrevisaoViewModel() 
        {
            BuscarPrevisaoCommand = new Command<int>(BuscarPrevisao);
            BuscarCidadesCommand = new Command(BuscarCidades);
        }

        public async void BuscarPrevisao(int Id)
        {
            previsao = await new PrevisaoService().GetPrevisaoById(Id);
            //Estado = previsao.Estado;
            //Condicao = previsao.clima[0].Condicao;
            Max = previsao.clima[0].Max.ToString();
            Min = previsao.clima[0].Min.ToString();
            //Indiceuv = previsao.clima[0].Indice_uv;
            //Condicao_desc = previsao.clima[0].Condicao_desc.Trim();
            //Atualizado_em = previsao.Atualizado_em;

            //Busca dados de uma previsão para os proximos dias
         /* proxPrevisao = await new PrevisaoService().GetPrevisaoForDaysById(244, 3);
            ProximosDias = proxPrevisao.clima; */
        }
       
        public async void BuscarCidades() 
        {
            Cidade_list = new List<Cidade>();
            Cidade_list = await new CidadeService().GetCidadesByName(Cidade_pesquisada);
        }
    }
}
