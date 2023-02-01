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


namespace WPF_Test
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

        private void RGB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb((byte)sliPiros.Value,(byte)sliZold.Value,(byte)sliKek.Value));
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {

            String szinadatok = $"{(byte)sliPiros.Value};{(byte)sliZold.Value};{(byte)sliKek.Value}";
            if (!lbSzinek.Items.Contains(szinadatok))
            {
                lbSzinek.Items.Add(szinadatok);
            }
            else
            {
                MessageBox.Show("Ilyen adat már létezik a listában");
            }
        }
     
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
           
            if(lbSzinek.SelectedIndex >= 0)
            {
                lbSzinek.Items.RemoveAt(lbSzinek.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a listában.");
            }
           
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lbSzinek.Items.Clear();
        }

        private void lbSzinek_Selected(object sender, RoutedEventArgs e)
        {
            var Item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            string[] parts = Item.Content.ToString().Split(';');
            sliPiros.Value = Convert.ToByte(parts[0]);
            sliZold.Value = Convert.ToByte(parts[1]);
            sliKek.Value = Convert.ToByte(parts[2]);
            rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb((byte)sliPiros.Value, (byte)sliZold.Value, (byte)sliKek.Value));

        }
    }
   
    
}


