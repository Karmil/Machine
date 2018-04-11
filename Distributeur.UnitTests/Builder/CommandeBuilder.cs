using Adneom.Distributeur.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Distributeur.UnitTests.Builder
{
    public class CommandeBuilder
    {
        private Commande _commande;
        public string IdType => "90e64a45-572b-465c-ada1-cdd67bb1afa8";
        public string Id => "e2b0fa40-df34-4ba0-8daa-b755fec4784a";
        public string DescriptionType => "Cafe";
        public string Login => "omar.karmil@gmail.com";
        public int Quantite => 100;
        public BoissonType TestBoissonType { get; }

        public CommandeBuilder()
        {
            TestBoissonType = new BoissonType { Id = IdType, DescriptionType = DescriptionType, Quantite = Quantite };
            _commande = WithDefaultValues();
        }
        public Commande Build()
        {
            return _commande;
        }
        public Commande WithDefaultValues()
        {
            _commande = new Commande { Id = Id, IdTypeBoisson = IdType, Login = Login, DateComande = DateTime.Now, Mug = true, IdTypeBoissonNavigation = TestBoissonType };
            return _commande;
        }
    }
}
