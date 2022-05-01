using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamentos.Testes
{
    public class VeiculoTestes
    {
        private Veiculo veiculo;
        public ITestOutputHelper TestOutputHelper { get; set; }

        public VeiculoTestes(ITestOutputHelper testOutputHelper)
        {
            this.TestOutputHelper = testOutputHelper;
            veiculo = new Veiculo();
        }
        [Fact]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarParametro10()
        {
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearParametro10()
        {
            //Act
            veiculo.Frear(15);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Act
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(Skip = "Nãoo implementado.")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]
        public void FichaInformacaoDoVeiculo()
        {
            //Arrange
            Veiculo carro = new Veiculo()
            {
                Proprietario = "Vinicius",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Verde",
                Placa = "ZAP-5467",
                Modelo = "Variante"
            };

            //Act
            string dados = carro.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo:", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoCaracteres()
        {
            string nomeProprietario = "Ab";

            Assert.Throws<System.FormatException>(
                () => veiculo.Proprietario = nomeProprietario
            ); 
        }

        [Theory]
        [InlineData("AAA-22")]
        [InlineData("A2D-1293")]
        [InlineData("231C2345")]
        [InlineData("AAA-123D")]
        public void TestaExceptionDaPlaca(string placa)
        {
            Assert.Throws<System.FormatException>(
                () => veiculo.Placa = placa
            );
        }
    }
}
