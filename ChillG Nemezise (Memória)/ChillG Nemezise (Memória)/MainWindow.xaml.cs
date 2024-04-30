using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace ChillG_Nemezise__Memória_
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		private void RacsMeretListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (RacsMeretListBox.SelectedItem != null)
			{
				string selectedSize = ((ListBoxItem)RacsMeretListBox.SelectedItem).Content.ToString();
				int size = int.Parse(selectedSize.Split('x')[0]);

				Game game = new Game(size);
				game.Show();
				this.Close();
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var selectedItem = (ListBoxItem)RacsMeretListBox.SelectedItem;
			var num_str = selectedItem.Content.ToString();
			int number = Int32.Parse(num_str);
			Game game = new Game(number);
			this.Hide();
			game.Show();
		}
		 
		
	}
}
