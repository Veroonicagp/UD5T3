namespace UD5T3.MVVM.Views;
using UD5T3.MVVM.ViewModel;

public partial class AlumnoView : ContentPage
{
	public AlumnoView()
	{
		InitializeComponent();

        BindingContext = new AlumnoViewModel();
    }

    private void Detalle_cliked(object sender, EventArgs e)
    {
        var detalleViewModel = (AlumnoViewModel)BindingContext;
        Navigation.PushAsync(new DetalleView

        {
            BindingContext = new DetalleViewModel
            {
                Nombre = detalleViewModel.AlumnoActual.Name,
                NIF = detalleViewModel.AlumnoActual.NIF,
                Empresa = detalleViewModel.AlumnoActual.Empresa,
            }
        });
    }
}