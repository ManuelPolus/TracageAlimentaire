﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tracage.Models
{
    public class Organisation
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public Adresse Adresse { get; set; }

        public List<SousTraitant> SousTraitants { get; set; }


    }
}
