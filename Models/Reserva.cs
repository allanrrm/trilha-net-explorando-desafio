namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            bool verificarQuantidade = hospedes.Count <= Suite.Capacidade;
            if (verificarQuantidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Erro: A quantidade de hospedes supera a capacidade da suite, por favor, selecione uma nova suite");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {


            decimal valor = Suite.ValorDiaria * DiasReservados;
            bool aplicarDesconto = DiasReservados >= 10;

            if (aplicarDesconto)
            {
                valor = valor * 0.90M;
            }

            return valor;
        }
    }
}