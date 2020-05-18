using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Project_Three_GUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//Initializes window at program start
		public MainWindow()
		{
			InitializeComponent();
		}

		//Window exits when the exit button is pressed
		private void exit_btn(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		//Username and password logic that allows entry if they are correct
		private void sbmt_btn(object sender, RoutedEventArgs e)
		{
			if (usernameBox.Text == "home")
			{
				if (passwordBox.Text == "1234")
				{
					SecondWindow ResidentWin = new SecondWindow();
					ResidentWin.Show();
					this.Close();
				}
			}
		}
	}
}
