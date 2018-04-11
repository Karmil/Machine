using System;
using System.Collections.Generic;
using System.Text;

namespace Adneom.Distributeur.ApplicationCore.Entities
{
    public class CustumMachine
    {
        public string IdType { get; set; }
        public string TypeName { get; set; }
        public int Quantite { get; set; }
        public bool Mug { get; set; }
        public string Login { get; set; }
    }
}
