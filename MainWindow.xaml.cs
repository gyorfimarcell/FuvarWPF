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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfFuvar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Fuvar> fuvarok;

        public MainWindow()
        {
            // << Vedrán Krisztián, - >>
            InitializeComponent();

            fuvarok = File.ReadAllLines("Fuvar.csv").Skip(1).Select(x => new Fuvar(x)).ToList();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"3. feladat: {fuvarok.Count()} fuvar");
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (tb4.Text == "")
            {
                MessageBox.Show("Az azonosító nem lehet üres!");
                return;
            }

            int azonosito;
            if (!int.TryParse(tb4.Text, out azonosito))
            {
                MessageBox.Show("Egy számot kell megadnod!");
                return;
            }

            List<Fuvar> kivalasztott = fuvarok.Where(x => x.Azonosito == azonosito).ToList();
            if (kivalasztott.Count() == 0)
            {
                MessageBox.Show("Nincs ilyen azonosítójú taxis.");
                return;
            }

            MessageBox.Show($"4. feladat: {kivalasztott.Count()} fuvar alatt {kivalasztott.Sum(x => x.Bevetel)}$");
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            lb5.ItemsSource = fuvarok.GroupBy(x => x.FizetesiMod).Select(x => $"{x.Key}: {x.Count()} fuvar");
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"6. feladat: {Math.Round(fuvarok.Sum(x => x.TavolsagKm), 2)} km");
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            lb7.Items.Clear();

            Fuvar leghosszabb = fuvarok.MaxBy(x => x.Idotartam);
            lb7.Items.Add($"Fuvar hossza: {leghosszabb.Idotartam} másodperc");
            lb7.Items.Add($"Taxi azonosító: {leghosszabb.Azonosito}");
            lb7.Items.Add($"Megtett távolság: {Math.Round(leghosszabb.TavolsagKm, 1)} km");
            lb7.Items.Add($"Viteldíj: {leghosszabb.Dij}$");
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            string fejlec = "taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja";
            File.WriteAllLines("hibak.txt", fuvarok.Where(x => x.Hibas).OrderBy(x => x.Indulas).Select(x => x.CsvSor).Prepend(fejlec));
            MessageBox.Show("8. feladat: hibak.txt");
        }
    }
}
