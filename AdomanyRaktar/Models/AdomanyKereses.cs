using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdomanyRaktar.Models
{
    public class AdomanyKereses
    {
        public string AdomanyKereso { get; set; }
        public string KategoriaKereso { get; set; }
        public SelectList KategoriaLista { get; set; }
        public List<Adat> Adomanyok { get; set; }

        }
    }
