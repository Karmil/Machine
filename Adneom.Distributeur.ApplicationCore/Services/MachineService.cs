using Adneom.Distributeur.ApplicationCore.Entities;
using Adneom.Distributeur.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adneom.Distributeur.ApplicationCore.Services
{
    public class MachineService : IMachineService
    {
        private readonly IAsyncRepository<BoissonType> asyncTypeRepository;
        private readonly IAsyncRepository<Commande> asyncCommandeRepository;
        private readonly IEfSpecRepository efSpecRepository;
        private readonly IAppLogger<MachineService> _logger;

        public MachineService(IAsyncRepository<BoissonType> asyncTypeRepository, IAsyncRepository<Commande> asyncCommandeRepository, IEfSpecRepository efSpecRepository, IAppLogger<MachineService> logger)
        {
            this.asyncTypeRepository = asyncTypeRepository;
            this.asyncCommandeRepository = asyncCommandeRepository;
            this.efSpecRepository = efSpecRepository;
            _logger = logger;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="custumMachine"></param>
        /// <returns></returns>
        public async Task<Commande> ConstructionCafe(CustumMachine custumMachine)
        {
            // Vérifier la quantite du boisson choisi 
            var boissonType = await asyncTypeRepository.GetByIdAsync(custumMachine.IdType);
            if (boissonType is null)
            {
                _logger.LogWarning("boisson n'esxiste pas");
                throw new ArgumentNullException("Idtype", "Votre choix.... ");
            }
            else
            {
                if (boissonType.Quantite > 0)
                {
                    // Reduire la quatite de la quantite consomme
                    boissonType.Quantite--;
                    await asyncTypeRepository.UpdateAsync(boissonType);

                    // Construction commande
                    var command = new Commande
                    {
                        Id = Guid.NewGuid().ToString(),
                        DateComande = DateTime.Now,
                        IdTypeBoisson = custumMachine.IdType,
                        Login = custumMachine.Login,
                        Mug = custumMachine.Mug
                    };

                    // Sauvgarder la commande
                    return await asyncCommandeRepository.AddAsync(command);
                }
                else
                {
                    _logger.LogWarning("Boisson "+ boissonType.DescriptionType+ " terminé");
                    throw new Exception("Il n'a plus de" + boissonType.DescriptionType);
                }
            }
        }
        /// <summary>
        /// Recupere le dernier chois d'utilisateur
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public CustumMachine SectionDernierChoix(string login)
        {
            // Vérifier si l'utilisateur a déja passe une commande
            var listCommnadeLogin = efSpecRepository.GetCommandeByLogin(login);

            // Retourner la commande au cas échanace retourner null
            if (listCommnadeLogin.Count > 0)
            {
                var selectionCommande = new CustumMachine
                {
                    Login = login,
                    IdType = listCommnadeLogin[0].IdTypeBoisson
                };
                return selectionCommande;
            }

            return null;

        }
        #region Remplisage machine && boisson existant
        public async Task<BoissonType> InitMachine(BoissonType boissonType)
        {

            try
            {
                if (String.IsNullOrEmpty(boissonType.Id))
                {
                    return await asyncTypeRepository.AddAsync(boissonType);
                }

                return await RemplirMachine(boissonType);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return null;
            }

        }
        public async Task<BoissonType> RemplirMachine(BoissonType boissonType)
        {
            await asyncTypeRepository.UpdateAsync(boissonType);
            return boissonType;
        }

        /// <summary>
        ///  Listes des boissons
        /// </summary>
        /// <returns></returns>
        public async Task<List<BoissonType>> ListAllTypeBoisson() => await asyncTypeRepository.ListAllAsync();

        #endregion
    }
}
