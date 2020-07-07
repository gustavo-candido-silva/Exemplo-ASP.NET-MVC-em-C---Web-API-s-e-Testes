using System;
using System.Collections.Generic;
using Moq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ExemploMvc.Models;
using System.Threading.Tasks;
using ExemploAPI.Controllers;
using Xunit;
using System.Threading;

namespace ExemploTeste
{
    public class CategoriasControllerTest
    {

        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Contexto> _mockContexto;
        private readonly Categoria _categoria;

        public CategoriasControllerTest() {

            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContexto = new Mock<Contexto>();
            _categoria = new Categoria { Id = 3, Descricao = "Categoria de teste auto"};

            // mock setup, we have to setup every function that will be used in the mocked object in the tests
            _mockContexto.Setup(expression: m => m.Categorias).Returns(_mockSet.Object);

            // function get categoria 
            _mockContexto.Setup(expression: m => m.Categorias.FindAsync(3)).ReturnsAsync(_categoria);

            // function post categoria 
            _mockContexto.Setup(expression: m => m.SetModified(_categoria));

            // function put categoria 
            _mockContexto.Setup(expression: m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(3);

        }

        [Fact]
        public async Task Get_Categoria(){

            var service = new CategoriasController(_mockContexto.Object);

            await service.GetCategoria(id:3);

            _mockSet.Verify(expression: m => m.FindAsync(3), Times.Once);

        }

        [Fact]
        public async Task Put_Categoria()
        {

            var service = new CategoriasController(_mockContexto.Object);

            await service.PutCategoria(id: _categoria.Id,_categoria);

            _mockContexto.Verify(expression: m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);


        }

        [Fact]
        public async Task Post_Categoria()
        {

            var service = new CategoriasController(_mockContexto.Object);

            await service.PostCategoria(_categoria);

            _mockSet.Verify(expression: n => n.Add(_categoria), Times.Once);
            _mockContexto.Verify(expression: m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

        }

        [Fact]
        public async Task Delete_Categoria()
        {

            var service = new CategoriasController(_mockContexto.Object);

            await service.DeleteCategoria(id: 3);

            _mockSet.Verify(expression: m => m.FindAsync(3), Times.Once);
            _mockSet.Verify(expression: m => m.Remove(_categoria), Times.Once);
            _mockContexto.Verify(expression: m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

        }

    }
}
