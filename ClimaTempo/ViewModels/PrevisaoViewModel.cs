using ClimaTempo.Models;
using ClimaTempo.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClimaTempo.ViewModels
{ //parcial porque precisa de outro arquivo para funcionar
    public partial class PrevisaoViewModel : ObservableObject
    {
        [ObservableProperty]
        private string cidade;
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
        }
    
    }
}
