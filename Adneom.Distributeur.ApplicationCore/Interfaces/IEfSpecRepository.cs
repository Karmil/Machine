using Adneom.Distributeur.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adneom.Distributeur.ApplicationCore.Interfaces
{
    public interface IEfSpecRepository
    {
        List<Commande> GetCommandeByLogin(string login);
    }
}
