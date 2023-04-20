using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    internal class Videogame
    {
        public string Nome { get; set;}
        public string Descrizione { get; set;}
        public DateTime Uscita { get; set;}
        public long SoftwareHouse { get; set;}

        public Videogame(string nome, string descrizione, DateTime uscita, long softwareHouse)
        {
            Nome = nome;
            Descrizione = descrizione;
            Uscita = uscita;
            SoftwareHouse = softwareHouse;
        }

        public override string ToString()
        {
            return $"{Nome} - {Uscita}\n{SoftwareHouse}\n{Descrizione}";
        }
    }
}
