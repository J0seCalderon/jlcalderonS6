using jlcalderonS6.Tablas;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Net.Http;
using System.Text;



namespace jlcalderonS6.Ventanas;

public partial class vActElim : ContentPage
{
    private Estudiante datos;

    public vActElim(Estudiante datos)
	{
		InitializeComponent();
        this.datos = datos;
        txtCodigo.Text= datos.codigo.ToString();
        txtNombre.Text = datos.nombre; 
        txtApellido.Text = datos.apellido; 
        txtEdad.Text = datos.edad.ToString();
	}

    private async void bntActualizar_Clicked(object sender, EventArgs e)
    {

        try
        {
            HttpClient cliente = new HttpClient();
            var url = "http://localhost/appmovil/post.php";
            var parametros = new
            {
                codigo = txtCodigo.Text,
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                edad = txtEdad.Text
            };
            var json = JsonConvert.SerializeObject(parametros);
            var contenido = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var respuesta = await cliente.PutAsync(url, contenido);

            if (respuesta.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Registro actualizado correctamente", "Cerrar");
                await Navigation.PushAsync(new vPrincipal());
            }
            else
            {
                await DisplayAlert("Error", "No se pudo actualizar el registro", "Cerrar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
    }

    private async void bntEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            HttpClient cliente = new HttpClient();
            var url = $"http://localhost/appmovil/post.php?codigo={datos.codigo}";
            var respuesta = await cliente.DeleteAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Registro eliminado correctamente", "Cerrar");
                await Navigation.PushAsync(new vPrincipal());
            }
            else
            {
                await DisplayAlert("Error", "No se pudo eliminar el registro", "Cerrar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
    }
}