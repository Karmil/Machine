using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Adneom.Distributeur.ApplicationCore.Entities
{
    public class Commande : BaseEntity
    {
        public Commande()
        {
        }

        public string IdTypeBoisson { get; set; }
        public string Login { get; set; }
        public DateTime? DateComande { get; set; }
        public bool Mug { get; set; }
        public BoissonType IdTypeBoissonNavigation { get; set; }
    }
}
