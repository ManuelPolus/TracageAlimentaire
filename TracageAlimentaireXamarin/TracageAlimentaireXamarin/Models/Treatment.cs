﻿using TracageAlmentaireWeb.Models;

namespace Tracage.Models
{
    public class Treatment
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public State OutgoingState { get; set; }

        public string Name { get; set; }

        public int Position { get; set; }

    }
}
