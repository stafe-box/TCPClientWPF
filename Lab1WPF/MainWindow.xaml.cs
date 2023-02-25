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

namespace Lab1WPF
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

        private async void Launch_Click(object sender, RoutedEventArgs e)
        {
            string ip = IPBox.Text;
            string msg = MessageBox.Text;
            Color color = ColorPicker.SelectedColor;
            //Result.Text = color.ToString();
            Launch.IsEnabled = false;
            Client client = new Client();
            client.Notify += Client_Notyfy;
            await Task.Run(() => { client.Connect(ip, color.ToString() + "⫻" + msg); });
        }

        private void Client_Notyfy(string responce)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                Result.Text = responce.Split("⫻")[1];
                Launch.IsEnabled = true;
            }));
        }
    }
}
