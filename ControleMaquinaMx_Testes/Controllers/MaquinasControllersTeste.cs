using ControleMaquinasMx.Controllers;
using ControleMaquinasMx_CoreShared.MaquinasDtos;
using ControleMaquinasMx_FakeData.ClienteData;
using ControleMaquinasMx_Manager.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace ControleMaquinaMx_Testes.Controllers
{
    public class MaquinasControllerTeste
    {
        private readonly IMaquinasManager _manager;
        private readonly ILogger<MaquinaController> _logger;
        private readonly MaquinaController _controller;
        private readonly MaquinaViewDto _maquinaDto;
        private readonly List<MaquinaViewDto> _listaMaquinas;

        public MaquinasControllerTeste()
        {
            _manager = Substitute.For<IMaquinasManager>();
            _logger = Substitute.For<ILogger<MaquinaController>>();
            _controller = new MaquinaController(_manager, _logger);
            _listaMaquinas = new MaquinaViewFaker().Generate(10);
            _maquinaDto = new MaquinaViewFaker().Generate();
        }

        [Fact]
        public async Task BuscarTodasMaquinas_Ok()
        {
            var controle = new List<MaquinaViewDto>();
            _listaMaquinas.ForEach(x => controle.Add(x.CloneTipado()));
            _manager.SearchMaquinasAsync().Returns(_listaMaquinas);

            var resultado = (ObjectResult)await _controller.BuscaTodasMaquinas();

            await _manager.Received().SearchMaquinasAsync();
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
            resultado.Value.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task BuscarTodasMaquinas_NotFound()
        {
            _manager.SearchMaquinasAsync().Returns(new List<MaquinaViewDto>());

            var resultado = (StatusCodeResult)await _controller.BuscaTodasMaquinas();

            await _manager.Received().SearchMaquinasAsync();
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task BuscarMaquinasPorId_Ok()
        {
            _manager.SearchMaquinasAsync(Arg.Any<int>()).Returns(_maquinaDto.CloneTipado());

            var resultado = (ObjectResult)await _controller.BuscarMaquinaPorId(_maquinaDto.Id);

            await _manager.Received().SearchMaquinasAsync(Arg.Any<int>());
            resultado.Value.Should().BeEquivalentTo(_maquinaDto);
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task BuscarMaquinasPorId_NotFound()
        {
            _manager.SearchMaquinasAsync(Arg.Any<int>()).Returns(new MaquinaViewDto());

            var resultado = (StatusCodeResult)await _controller.BuscarMaquinaPorId(1);

            await _manager.Received().SearchMaquinasAsync(Arg.Any<int>());
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        //[Fact]
        //public async Task AdicionarMaquinas_CreatedAtAction()
        //{
        //    throw new NotImplementedException();
        //}

        //[Fact]
        //public async Task AdicionarMaquinas_BadRequest()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
