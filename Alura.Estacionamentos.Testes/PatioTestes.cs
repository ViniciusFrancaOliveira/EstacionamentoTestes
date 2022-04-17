using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.Estacionamentos.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            Patio estacionamento = new Patio();
            Operador operador = new Operador() { Nome = "Gilerto Soares" };
            Veiculo veiculo = new Veiculo();
            estacionamento.OperadorPatio = operador;
            veiculo.Proprietario = "Vinicius França";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "ASD-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Vinicius França", "ASD-1498", "preto", "fusca")]
        [InlineData("Gabriel Barreto", "RTC-8542", "verde", "gol")]
        [InlineData("Maria Silva", "KHS-6325", "branco", "opala")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa,
                                                       string cor, string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            Operador operador = new Operador() { Nome = "Gilerto Soares" };
            Veiculo veiculo = new Veiculo();
            estacionamento.OperadorPatio = operador;
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Vinicius França", "ASD-1498", "preto", "fusca")]
        public void LocalizaVeiculoNoPatio(string proprietario, string placa,
                                           string cor, string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            Operador operador = new Operador() { Nome = "Gilerto Soares" };
            Veiculo veiculo = new Veiculo();
            estacionamento.OperadorPatio = operador;
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            Veiculo consultado = estacionamento.PesquisaVeiculoPorPlaca(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);

        }

        [Fact]
        public void AlteraDadosVeiculo()
        {
            //Arrange
            Patio estacionamento = new Patio();
            Operador operador = new Operador() { Nome = "Gilerto Soares" };
            Veiculo veiculo = new Veiculo();
            estacionamento.OperadorPatio = operador;
            veiculo.Proprietario = "Vinicius";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Opala";
            veiculo.Placa = "ASE-2354";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo()
            {
                Proprietario = "Vinicius",
                Placa = "ASE-2354",
                Cor = "Verde",
                Modelo = "Opala"
            };

            //Act
            Veiculo alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }
    }
}
