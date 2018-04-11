using Adneom.Distributeur.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Adneom.Distributeur.ApplicationCore.Interfaces;

namespace Adneom.Distributeur.Infrastucture.Data
{
    public class EfSpecRepository: IEfSpecRepository
    {
        protected readonly DistruputionContext _dbContext;

        public EfSpecRepository(DistruputionContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Commande> GetCommandeByLogin(string login)
        {
            return (from item in _dbContext.Commande
                    where item.Login == login
                    orderby item.DateComande descending
                    select new Commande
                    {
                        DateComande=item.DateComande,
                        IdTypeBoisson=item.IdTypeBoisson
                    }).ToList();
        }
    }
}
