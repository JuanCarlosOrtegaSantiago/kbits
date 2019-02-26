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

namespace kbitsGUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numero;
        int numerodebit;

        public MainWindow()
        {
            InitializeComponent();
            txtnumBits.IsEnabled = false;
            txtNumEntero.IsEnabled = false;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtnumBits.IsEnabled = true;
            txtNumEntero.IsEnabled = true;
            txtNumEntero.Clear();
            txtnumBits.Clear();
            lblResul.Content = "";
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnumBits.Text) || string.IsNullOrWhiteSpace(txtNumEntero.Text))
            {
                MessageBox.Show("Ingresa algun dato porfavor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    numero = int.Parse(txtNumEntero.Text);
                    numerodebit = int.Parse(txtnumBits.Text);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            int numeroCopia = numero;
            string CodigoBinario = "";


            numero = Math.Abs(numero);
            
            string bits = "";

            while (numero>0)
            {
                int resu;
                numero =Math.DivRem(numero, 2, out resu);                
                bits += resu;
            }

            if (numerodebit <= bits.Count())
            {
                MessageBox.Show("El numero de bits ingresado no es correcto necesitas almenos "+(bits.Count()+1)+" bits", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                
                if (numeroCopia > 0)
                    CodigoBinario += "0";
                else
                    CodigoBinario += "1";

                if (numerodebit > bits.Count() + 1)
                {
                    for (int i = 0; i < numerodebit- (bits.Count() + 1); i++)
                        CodigoBinario += "0";
                }

                for (int i = bits.Count(); i > 0; i--)
                    CodigoBinario += bits[i-1];

            }

            lblResul.Content = CodigoBinario;
        }
    }
}
