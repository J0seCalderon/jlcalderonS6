using jlcalderonS6.Tablas;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
//using System.Runtime.CompilerServices;

namespace jlcalderonS6.Ventanas;

public partial class vPrincipal : ContentPage
{
	private const string Url = "http://localhost/appmovil/post.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estud;
	public vPrincipal()
	{
		InitializeComponent();
		Obtener();
	}

	public async void Obtener()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud = new ObservableCollection<Estudiante>(mostrarEst);
		listaEstudiantes.ItemsSource = estud;
	}


    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objestudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new vActElim(objestudiante));
    }

    private void bntAgregar_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new vAgregar());
    }
}