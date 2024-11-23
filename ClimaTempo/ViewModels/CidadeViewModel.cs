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
{
    public partial class CidadeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string nome;
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        private string estado;

        [ObservableProperty] //se quer exibir ela, entao é uma observableProperty
        private List<Cidade> cidades;

        public Cidade Cidade { get; set; }

        public ICommand BuscarCidadeCommand { get; }

        public CidadeViewModel()
        {
            BuscarCidadeCommand = new Command(BuscarCidade);
        }
        public async void BuscarCidade() 
        {
            cidades = await new CidadeService().GetCidadesByName("São Paulo");
            Nome = Cidade.Nome;
            Id = Cidade.Id;
            Estado = Cidade.Estado;

        }
    }
}
