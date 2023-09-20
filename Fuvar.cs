using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFuvar
{
    internal class Fuvar
    {
        int azonosito;
        string indulas;
        int idotartam;
        double tavolsag;
        double dij;
        double borravalo;
        string fizetesiMod;
        string csvSor;

        public Fuvar(string csvSor)
        {
            string[] mezok = csvSor.Split(';');

            this.azonosito = Convert.ToInt32(mezok[0]);
            this.indulas = mezok[1];
            this.idotartam = Convert.ToInt32(mezok[2]);
            this.tavolsag = Convert.ToDouble(mezok[3]);
            this.dij = Convert.ToDouble(mezok[4]);
            this.borravalo = Convert.ToDouble(mezok[5]);
            this.fizetesiMod = mezok[6];
            this.csvSor = csvSor;
        }

        public int Azonosito { get => azonosito; }
        public string Indulas { get => indulas; }
        public int Idotartam { get => idotartam; }
        public double Tavolsag { get => tavolsag; }
        public double Dij { get => dij; }
        public double Borravalo { get => borravalo; }
        public string FizetesiMod { get => fizetesiMod; }
        public string CsvSor { get => csvSor; }

        public double Bevetel { get => dij + borravalo; }
        public double TavolsagKm { get => tavolsag * 1.6; }
        public bool Hibas { get => idotartam > 0 && dij > 0 && tavolsag == 0; }
    }
}
