using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Adneom.Distributeur.ApplicationCore.Entities
{
    public class BoissonType : BaseEntity
    {
        public BoissonType()
        {
            Commande = new HashSet<Commande>();
        }

        public string DescriptionType { get; set; }
        public int? Quantite { get; set; }

        public ICollection<Commande> Commande { get; set; }
    }
}
