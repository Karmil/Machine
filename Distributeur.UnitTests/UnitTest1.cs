using Adneom.Distributeur.ApplicationCore.Entities;
using Adneom.Distributeur.ApplicationCore.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Distributeur.UnitTests
{
    public class UnitTest1
    {
        private string _login = "karmil.omar@gmail.com";
        private Mock<IMachineService> _mockIMachineService;


        public UnitTest1()
        {
            _mockIMachineService = new Mock<IMachineService>();
        }

        [Fact]
        public void SelectionDernierChoix()
        {
            var result = GetTestList().AsQueryable().Where(e=>e.Login==_login).OrderByDescending(e=>e.DateComande).First();
            Assert.NotNull(result);
            Assert.Equal(_login, result.Login);
        }
        public List<Commande> GetTestList()
        {
            return new List<Commande>()
            {
                new Commande(){Id="e2b0fa40-df34-4ba0-8daa-b755fec4784a",IdTypeBoisson="90e64a45-572b-465c-ada1-cdd67bb1afa8",Login="karmil.omar@gmail.com",DateComande=DateTime.Now },
                new Commande(){Id="e2b0fa40-df34-4ba0-8daa-b755fec4784b",IdTypeBoisson="90e64a45-572b-465c-ada1-cdd67bb1afa8",Login="omar.karmil@gmail.com",DateComande=DateTime.Today },
            };
        }

    }
}
