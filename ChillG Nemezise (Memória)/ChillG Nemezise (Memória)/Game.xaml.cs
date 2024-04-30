using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ChillG_Nemezise__Memória_
{
	public partial class Game : Window
	{
		public List<Button> buttons = new List<Button>();
		public List<int> szamok = new List<int>();
		public Game(int number)
		{
			InitializeComponent();
			GridBeallitas(number);
			SzamGeneralas(number);
			SzamokKeverese();
			SzamokMegjelenitese();
		}

		public void GridBeallitas(int szam)
		{
			for (int i = 0; i < szam; i++)
			{
				Racsni.RowDefinitions.Add(new RowDefinition());
			}
			for (int i = 0; i < szam; i++)
			{
				Racsni.ColumnDefinitions.Add(new ColumnDefinition());
			}
			Gombok(szam);
		}

		public void Gombok(int szam)
		{
			for (int sor = 0; sor < szam; sor++)
			{
				for (int oszlop = 0; oszlop < szam; oszlop++)
				{
					Button button = new Button();
					button.FontSize = 30;
					button.Content = "";
					button.Click += Card_Click;
					Grid.SetRow(button, sor);
					Grid.SetColumn(button, oszlop);
					Racsni.Children.Add(button);
					buttons.Add(button);
				}
			}
		}

		public void SzamGeneralas(int szam)
		{
			for (int i = 1; i <= szam * szam / 2; i++)
			{
				szamok.Add(i);
				szamok.Add(i);
			}
		}

		public void SzamokKeverese()
		{
			Random rnd = new Random();
			int n = szamok.Count;
			while (n > 1)
			{
				n--;
				int k = rnd.Next(n + 1);
				int value = szamok[k];
				szamok[k] = szamok[n];
				szamok[n] = value;
			}
		}

		public void SzamokMegjelenitese()
		{
			for (int i = 0; i < buttons.Count; i++)
			{
				buttons[i].Content = szamok[i].ToString();
			}
		}

		private Button lastClickedButton = null;

		private void Card_Click(object sender, RoutedEventArgs e)
		{
			Button clickedButton = (Button)sender;

			if (clickedButton.Content != null)
				return;

			int index = buttons.IndexOf(clickedButton);
			clickedButton.Content = szamok[index].ToString();

			if (lastClickedButton == null)
			{
				lastClickedButton = clickedButton;
			}
			else
			{
				if (lastClickedButton.Content.ToString() == clickedButton.Content.ToString())
				{
					lastClickedButton.IsEnabled = false;
					clickedButton.IsEnabled = false;
				}
				else
				{
					lastClickedButton.Content = "";
					clickedButton.Content = "";

					lastClickedButton = null;
				}
			}
		}
	}
}
