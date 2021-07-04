using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CECAM.Domain.Interfaces.LogicLayer;
using CECAM.Entities;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Cecam.Tests
{ 
    public class UnitTestClientes
    {
        private IServiceCollection _services;
        private IClienteLogic clienteLogic;

        [SetUp]
        public void Setup()
        {
            Startup startup = new Startup(TestUtils.CreateConfigurationBuilder());
            _services = new ServiceCollection();
            _services = startup.ConfigureServices(_services);
        }

        [Test]
        public async Task TestAddCliente()
        {
            Cliente cliente = null;
            var result = default(int);
            try
            {
                using (var service = _services.BuildServiceProvider())
                {
                    clienteLogic = service.GetService<IClienteLogic>();
                    cliente = new Cliente { Codigo = 0, CNPJ = "05240427000180", RazaoSocial = "Cliente Teste 7", DataCadastro = DateTime.Now };
                    result = await clienteLogic.Add(cliente);
                }
                Assert.Pass(result > 0 ? "Inclusão Ok" : "Error");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task TestGetAllClientes()
        {
            IEnumerable<Cliente> listClientes = null;
            try
            {
                using (var service = _services.BuildServiceProvider())
                {
                    clienteLogic = service.GetService<IClienteLogic>();
                    listClientes = await clienteLogic.GetAll();
                }
                Assert.AreEqual(true, listClientes != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task TestGetClienteById()
        {
            Cliente result = null;
            try
            {
                using (var service = _services.BuildServiceProvider())
                {
                    clienteLogic = service.GetService<IClienteLogic>();
                    result = await clienteLogic.GetById(1);
                }
                Assert.AreEqual(true, result != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task TestUpdateCliente()
        {
            Cliente cliente = null;
            var result = 0;
            try
            {
                using (var service = _services.BuildServiceProvider())
                {
                    clienteLogic = service.GetService<IClienteLogic>();
                    cliente = new Cliente { Codigo = 1, CNPJ = "07218281000100", RazaoSocial = "Cliente Teste 1 Alterado" };
                    result = await clienteLogic.Update(cliente);
                }
                Assert.AreEqual(true, result > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task TestDeleteClienteAsync()
        {
            var result = 0;
            try
            {
                using (var service = _services.BuildServiceProvider())
                {
                    clienteLogic = service.GetService<IClienteLogic>();
                    result = await clienteLogic.Remove(1);
                }
                Assert.AreEqual(true, result > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
