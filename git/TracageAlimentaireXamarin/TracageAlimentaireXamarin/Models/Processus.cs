using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class Processus
    {

        public int Id { get; set; }

        public string Nom { get; set; }

        public List<Etape> Etapes { get; set; }

        public string Description { get; set; }
    }
}
