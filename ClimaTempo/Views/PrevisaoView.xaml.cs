using ClimaTempo.ViewModels;

namespace ClimaTempo.Views;

public partial class PrevisaoView : ContentPage
{
	public PrevisaoView()
	{
		InitializeComponent();
		BindingContext = new PrevisaoViewModel();
	}
}