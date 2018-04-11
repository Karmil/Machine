using Adneom.Distributeur.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adneom.Distributeur.ApplicationCore.Interfaces
{
    public interface IMachineService
    {
        Task<Commande> ConstructionCafe(CustumMachine custumMachine);
        CustumMachine SectionDernierChoix(string login);
        Task<BoissonType> InitMachine(BoissonType boissonType);
        Task<BoissonType> RemplirMachine(BoissonType boissonType);
        Task<List<BoissonType>> ListAllTypeBoisson();
    }
}
