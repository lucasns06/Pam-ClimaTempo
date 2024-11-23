using ClimaTempo.ViewModels;

namespace ClimaTempo.Views;

public partial class CidadeView : ContentPage
{
	public CidadeView()
	{
		InitializeComponent();

        BindingContext = new CidadeViewModel();
    }
}