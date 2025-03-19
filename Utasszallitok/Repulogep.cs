using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utasszallitok
{
    //típus;év;utas;személyzet;utazósebesség;felszállótömeg;fesztáv
    internal class Repulogep
    {
        public string Tipus {  get; set; }
        public int Ev {  get; set; }
        public string Utas { get; set; }
        public string Szemelyzet { get; set; }
        public int Utazosebesseg {  get; set; }
        public int Felszallotomeg {  get; set; }
        public double Fesztav {  get; set; }
        public string Kategorianev { get; set; }

        public Repulogep(string sor)
        {
            var v = sor.Split(';');

            Tipus = v[0];
            Ev = int.Parse(v[1]);
            Utas = v[2];
            Szemelyzet = v[3];
            Utazosebesseg = int.Parse(v[4]);
            Felszallotomeg = int.Parse(v[5]);
            Fesztav = double.Parse(v[6]);
            Kategorianev = new Sebessegkategoria(Utazosebesseg).Kategorianev;
        }
        public int GetMaxUtas()
        {
            if (int.TryParse(Utas, out int szam))
            {
                return szam;
            }
            else if (Utas.Contains('-'))
            {
                return int.Parse(Utas.Split('-')[1]);
            }
            return 0; 
        }

        public int GetMaxSzemely()
        {
            if (int.TryParse(Szemelyzet, out int szam))
            {
                return szam;
            }
            else if (Szemelyzet.Contains('-'))
            {
                return int.Parse(Szemelyzet.Split('-')[1]);
            }
            return 0;
        }
    }
}
