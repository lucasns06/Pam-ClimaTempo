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
        private double min;
        [ObservableProperty]
        private double max;
        [ObservableProperty]
        private double indiceuv;
        [ObservableProperty]
        private DateTime atualizado_em;
        [ObservableProperty]
        private string condicao_desc;

        private Previsao previsao;

        public ICommand BuscarPrevisaoCommand {  get; }
        public PrevisaoViewModel() 
        {
            BuscarPrevisaoCommand = new Command(BuscarPrevisao);
        }

        public async void BuscarPrevisao()
        {
            previsao = await new PrevisaoService().GetPrevisaoById(244);
            Cidade = previsao.Cidade;
            Estado = previsao.Estado;
            Condicao = previsao.clima[0].Condicao;
            Max = previsao.clima[0].Max;
            Min = previsao.clima[0].Min;
            Indiceuv = previsao.clima[0].Indice_uv;
            Condicao_desc = previsao.clima[0].Condicao_desc.Trim();
            Atualizado_em = previsao.Atualizado_em; 
        }
    
    }
}
