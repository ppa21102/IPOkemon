using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Prueba_pokemon
{
    public partial class MainWindow : Window
    {

        private string ruta = Directory.GetCurrentDirectory();
        private MediaPlayer mediaAnimaciones = new MediaPlayer();
        private DispatcherTimer t1;
        private DispatcherTimer t2;
        private DispatcherTimer t3;
        private int incremento = 10;
        private int decremento = 5;

        public MainWindow()
        {
            InitializeComponent();
            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromMilliseconds(10000);
            t1.Tick += new EventHandler(energia);
            t1.Start();

            t2 = new DispatcherTimer();
            t2.Interval = TimeSpan.FromMilliseconds(15000);
            t2.Tick += new EventHandler(alimentacion);
            t2.Start();

            t3 = new DispatcherTimer();
            t3.Interval = TimeSpan.FromMilliseconds(20000);
            t3.Tick += new EventHandler(diversion);
            t3.Start();
        }

        private void morir()
        {
            t1.Stop();
            t2.Stop();
            t3.Stop();

            Storyboard morir = (Storyboard)this.Resources["animacionMuerte"];
            morir.Completed += new EventHandler(finMuerte);

            morir.Begin();
        }

        private void finMuerte(object sender, EventArgs e)
        {
            MessageBox.Show("¡PIPLUP SE HA DEBILITADO! Vovlviendo a la pokeball..."+ MessageBoxButton.OK);
            this.Close();
        }

        private void alimentacion(object sender, EventArgs e)
        {
            this.barraSalud.Value -= decremento;
            if (this.barraSalud.Value <= 0)
            {
                morir();
            }
        }

        private void diversion(object sender, EventArgs e)
        {
            this.barraDiversion.Value -= decremento;
            if (this.barraDiversion.Value <= 0)
            {
                morir();
            }
        }

        private void energia(object sender, EventArgs e)
        {
            this.barraEnergia.Value -= decremento;
            if (this.barraEnergia.Value <= 0)
            {
                morir();
            }
        }

        private void descansar(object sender, RoutedEventArgs e)
        {
            btnDescansar.IsEnabled = false;
            Storyboard descansar = (Storyboard)this.Resources["animacionDescansar"];
            descansar.Completed += new EventHandler(finDescansar);
            descansar.Begin();

            barraSalud.Value += incremento;
        }

        private void finDescansar(object sender, EventArgs e)
        {
            btnDescansar.IsEnabled = true;
            mediaAnimaciones.Stop();
        }

        private void eventoComer(object sender, RoutedEventArgs e)
        {
            Storyboard comer = (Storyboard)this.Resources["animacionComer"];
            comer.Completed += new EventHandler(finComer);
            comer.Begin();

            barraEnergia.Value += incremento;
            mediaAnimaciones.Play();
        }

        private void finComer(object sender, EventArgs e)
        {
            btnComer.IsEnabled = true;
            mediaAnimaciones.Stop();
        }

        private void jugar(object sender, RoutedEventArgs e)
        {
            btnJugar.IsEnabled = false;
            Storyboard jugar = (Storyboard)this.Resources["animacionJugar"];
            jugar.Completed += new EventHandler(finJugar);
            jugar.Begin();

            barraDiversion.Value += incremento;
            mediaAnimaciones.Play();
        }

        private void finJugar(object sender, EventArgs e)
        {
            btnJugar.IsEnabled = true;
        }

        private void proteccion(object sender, RoutedEventArgs e)
        {
            btnAtaqueProteccion.IsEnabled = false;
            Storyboard proteccion = (Storyboard)this.Resources["animacionProteccion"];
            proteccion.Completed += new EventHandler(finProteccion);
            proteccion.Begin();

            barraEnergia.Value -= decremento;
            if (this.barraEnergia.Value <= 0)
            {
                morir();
            }
            mediaAnimaciones.Play();
        }

        private void finProteccion(object sender, EventArgs e)
        {
            btnAtaqueProteccion.IsEnabled = true;
        }

        private void rayoBurbuja(object sender, RoutedEventArgs e)
        {
            btnAtaqueRayoBurbuja.IsEnabled = false;
            Storyboard rayoBurbuja = (Storyboard)this.Resources["animacionRayoBurbuja"];
            rayoBurbuja.Completed += new EventHandler(finRayoBurbuja);
            rayoBurbuja.Begin();

            barraEnergia.Value -= decremento;
            if (this.barraEnergia.Value <= 0)
            {
                morir();
            }

            mediaAnimaciones.Play();
        }

        private void finRayoBurbuja(object sender, EventArgs e)
        {
            btnAtaqueRayoBurbuja.IsEnabled = true;
        }

        private void gruñido(object sender, RoutedEventArgs e)
        {
            btnAtaqueGruñido.IsEnabled = false;
            Storyboard gruñido = (Storyboard)this.Resources["animacionGruñido"];
            gruñido.Completed += new EventHandler(finGruñido);
            gruñido.Begin();

            barraEnergia.Value -= decremento;
            if (this.barraEnergia.Value <= 0)
            {
                morir();
            }

            mediaAnimaciones.Play();
        }

        private void finGruñido(object sender, EventArgs e)
        {
            btnAtaqueGruñido.IsEnabled = true;
        }

        private void sorpresa(object sender, RoutedEventArgs e)
        {
            btnPiplup.IsEnabled = false;
            Storyboard sorpresa = (Storyboard)this.Resources["animacionSorpresa"];
            sorpresa.Completed += new EventHandler(finSorpresa);
            sorpresa.Begin();

            mediaAnimaciones.Play();
        }

        private void finSorpresa(object sender, EventArgs e)
        {
            btnPiplup.IsEnabled = true;
        }
    }
}
