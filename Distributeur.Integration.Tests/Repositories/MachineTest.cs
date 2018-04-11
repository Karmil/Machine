using Adneom.Distributeur.Infrastucture.Data;
using Distributeur.UnitTests.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Distributeur.Integration.Tests.Repositories
{
    public class MachineTest
    {
        public readonly DistruputionContext _distruputionContext;
        public readonly EfSpecRepository _efSpecRepository;
        private readonly ITestOutputHelper _output;
        private CommandeBuilder CommandeBuilder { get; } = new CommandeBuilder();
        public MachineTest(ITestOutputHelper output)
        {
            _output = output;
            var dbOptions = new DbContextOptionsBuilder<DistruputionContext>()
                .UseInMemoryDatabase(databaseName: "DistruputeurTest")
                .Options;
            _distruputionContext = new DistruputionContext(dbOptions);
            _efSpecRepository = new EfSpecRepository(_distruputionContext);
        }

        [Fact]
        public void GetExistingOrder()
        {
            var exiteCommande = CommandeBuilder.WithDefaultValues();
            _distruputionContext.Commande.Add(exiteCommande);
            _distruputionContext.SaveChanges();
            var commandeId = exiteCommande.Id;
            _output.WriteLine(commandeId);

            var selectionFromRepo = _efSpecRepository.GetCommandeByLogin(exiteCommande.Login)[0];
            Assert.Equal(CommandeBuilder.IdType, selectionFromRepo.IdTypeBoisson);
        }
    }
}
