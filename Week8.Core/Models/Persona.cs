﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8.Core.Models
{
    public abstract class Persona
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public string Email { get; set; }

        //override del ToString
        public override string ToString()
        {
            return$"{ID}-{Nome} - {Cognome} - {Email}";
        }
    }
}
