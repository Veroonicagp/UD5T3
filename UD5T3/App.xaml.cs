namespace UD5T3;
using UD5T3.MVVM.Repositories;
using UD5T3.MVVM.Views;

public partial class App : Application
{
    public static AlumnoRepository AlumnoRepository { get; private set; }
    public App(AlumnoRepository alumnoRepository)
    {
        InitializeComponent();

        AlumnoRepository = alumnoRepository;

        MainPage = new AlumnoView();
    }
}
