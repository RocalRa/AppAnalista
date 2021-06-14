using System.Windows;

namespace WPF_Interfaces
{
	public class Funciones
	{
		public void Login(string txtLogonId, string txtPswrd)
		{
			string UserLoged = txtLogonId;
			Clases_y_Funciones_VB.Funciones_VB vb = new Clases_y_Funciones_VB.Funciones_VB();
			if (vb.AuthenticateUser("APTIV", txtLogonId, txtPswrd))
			{
				// Cambio a Pagina Principal
				MessageBox.Show("Sesion Iniciada");
				//MainWindow mw  = new MainWindow();
				//mw.Show();
				//this.Close();
			}
			else
			{
				txtPswrd = "";
				MessageBox.Show("Contrasena Incorrecta");
			}
		}




	}
}
