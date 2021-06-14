﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Interfaces.Vistas
{
	/// <summary>
	/// Interaction logic for LoginPage.xaml
	/// </summary>
	public partial class LoginPage : Page
	{
		public static WindowsIdentity CurrentUser = WindowsIdentity.GetCurrent();
		public LoginPage()
		{
			InitializeComponent();
			txtBoxUser.Text = CurrentUser.Name.Substring(CurrentUser.Name.IndexOf("\\") + 1);
		}

		Funciones fn = new Funciones();

		
	
		private void btnIngresar_Click(object sender, RoutedEventArgs e)
		{
			fn.Login(txtBoxUser.Text,pwdBox.Password);
		}
	}
}
