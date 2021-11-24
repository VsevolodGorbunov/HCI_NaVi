using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using System.Collections.Generic;

namespace HCI_NaVi
{
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		Dictionary<string, string> roomsPaths = new Dictionary<string, string>();
		public MainPage()
		{
            InitializeComponent();
			StreamReader f = new StreamReader("cabinet.txt");
			List<string> contentList = new List<string>();

			while (!f.EndOfStream)
			{
				contentList.Add(f.ReadLine());
			}
			f.Close();

			string content = string.Join("", contentList);
			foreach (string line in content.Split(';'))
			{
				string[] pair = line.Split('|');
				if (pair[0].Length == 0) break;
				string cabinet = pair[0].ToLower();
				string path = pair[1];
				if (!roomsPaths.ContainsKey(cabinet))
				{
					roomsPaths.Add(cabinet, path);
				}
			}

		}
		private void Button_Clicked(object sender, EventArgs e) //Обработчик нажатия на кнопку
        {
			string search = Numcab.Text.ToLower();
			if (roomsPaths.ContainsKey(search))
			{
				Way.Text = roomsPaths[search];
            }
            else
            {
				Way.Text = "Такого кабинета не существует!";
			}
		}

    }
}