﻿using System.Collections.Generic;
using Tracage.Models;

namespace TracageAlmentaireWeb.Models
{
    public class State
    {
        public long Id { get; set; }
        public string Status { get; set; }

        public bool Final { get; set; }

    }
}