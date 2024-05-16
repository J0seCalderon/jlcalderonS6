using jlcalderonS6.Tablas;

namespace jlcalderonS6.Ventanas;

public partial class vActElim : ContentPage
{

	public vActElim(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text= datos.codigo.ToString();
        txtNombre.Text = datos.nombre; 
        txtApellido.Text = datos.apellido; 
        txtEdad.Text = datos.edad.ToString();
	}

    private void bntActualizar_Clicked(object sender, EventArgs e)
    {

    }

    private void bntEliminar_Clicked(object sender, EventArgs e)
    {

    }
}