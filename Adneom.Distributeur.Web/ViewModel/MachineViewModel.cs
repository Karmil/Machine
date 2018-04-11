using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adneom.Distributeur.Web.ViewModel
{
    public class MachineViewModel
    {
        public string DescriptionType { get; set; }
        public int? Quantite { get; set; }
        public string IdTypeBoisson { get; set; }
        public string Login { get; set; }
        public DateTime? DateComande { get; set; }
        public bool Mug { get; set; }
    }
}
