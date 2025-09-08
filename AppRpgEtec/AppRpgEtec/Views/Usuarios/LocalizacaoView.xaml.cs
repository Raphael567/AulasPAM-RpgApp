using AppRpgEtec.ViewModels.Usuarios;

namespace AppRpgEtec.Views.Usuarios;

public partial class LocalizacaoView : ContentPage
{
    LocalizacaoViewModel viewModels;

    public LocalizacaoView()
	{
		InitializeComponent();

		viewModels = new LocalizacaoViewModel();
		viewModels.InicializarMapa();

		BindingContext = viewModels;
	}
}