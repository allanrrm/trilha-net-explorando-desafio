using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();
List<Reserva> listarReservas = new List<Reserva>();

// Cria a suíte
List<Suite> listaSuite = new List<Suite>();
Suite suiteBasica = new Suite(tipoSuite: "Basica", capacidade: 1, valorDiaria: 30);
Suite suitePremium = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 60);
Suite suitePresidencial = new Suite(tipoSuite: "Presidencial", capacidade: 3, valorDiaria: 90);
Suite suiteReal = new Suite(tipoSuite: "Real", capacidade: 5, valorDiaria: 120);
listaSuite.Add(suiteBasica);
listaSuite.Add(suitePremium);
listaSuite.Add(suitePresidencial);
listaSuite.Add(suiteReal);


// Exibe a quantidade de hóspedes e o valor da diária

string nomeHotel = "Noite Tranquila";
Console.Clear();
Menu();
void Menu()
{


    System.Console.WriteLine("----------------------------------------");
    System.Console.WriteLine($"| Seja Bem Vindo ao Hotel {nomeHotel} |");
    System.Console.WriteLine($"| Por Favor, Selecione uma das Opções:|");
    System.Console.WriteLine($"| 1 - Cadastrar Hospedes              |");
    System.Console.WriteLine($"| 2 - Realizar Reserva                |");
    System.Console.WriteLine($"| 3 - Fechamento                      |");
    System.Console.WriteLine($"| 4 - Finalizar o Programa            |");
    System.Console.WriteLine("----------------------------------------");

    int opcao = int.Parse(Console.ReadLine());
    switch (opcao)
    {
        case 1:
            bool cadastrarNovoHospede = false;
            do
            {
                System.Console.WriteLine("Digite o Nome do Hospede");
                string nome = Console.ReadLine();
                System.Console.WriteLine("Digite o Sobrenome do Hospede");
                string sobrenome = Console.ReadLine();
                Pessoa pessoa = new Pessoa(nome, sobrenome);
                System.Console.WriteLine("Deseja cadastrar um novo Hospede?(S/N)");
                cadastrarNovoHospede = Console.ReadLine().ToUpper() == "S";
                hospedes.Add(pessoa);
            } while (cadastrarNovoHospede == true);
            Console.Clear();
            Menu();
            break;
        case 2:
            int opcaoSuite = 0;
            int numeroOpcao = 1;
            System.Console.WriteLine("Digite a suite que deseja:");
            foreach (Suite suite in listaSuite)
            {
                System.Console.WriteLine($"{numeroOpcao}");
                System.Console.WriteLine($"Suite: {suite.TipoSuite}");
                System.Console.WriteLine($"Capacidade: {suite.Capacidade}");
                System.Console.WriteLine($"Valor Diária: {suite.ValorDiaria}");
                numeroOpcao++;
            }
            do
            {
                opcaoSuite = int.Parse(Console.ReadLine());
            } while (opcaoSuite > 3 || opcaoSuite < 1);
            System.Console.WriteLine("Reserva para quantos dias:");
            int diasReserva = int.Parse(Console.ReadLine());
            Reserva reserva = new Reserva(diasReservados: diasReserva);
            reserva.CadastrarSuite(listaSuite[opcaoSuite - 1]);
            reserva.DataEntrada = DateTime.Now;
            reserva.DataSaida = reserva.DataEntrada.AddDays(diasReserva);
            reserva.CadastrarHospedes(hospedes);
            listarReservas.Add(reserva);
            Console.Clear();
            Menu();
            break;
        case 3:
            int contador = 1;
            System.Console.WriteLine("Selecione a Reserva digitando o numero:");
            foreach (Reserva reservas in listarReservas)
            {
                System.Console.WriteLine($"Reserva numero {contador}");
                Console.WriteLine($"Data Entrada: {reservas.DataEntrada}");
                Console.WriteLine($"Data Saída: {reservas.DataSaida}");
                contador++;
            }

            int opcaoReserva = int.Parse(Console.ReadLine());
            Console.WriteLine($"Suite: {listarReservas[opcaoReserva - 1].Suite.TipoSuite}");
            Console.WriteLine($"Valor: {listarReservas[opcaoReserva - 1].Suite.ValorDiaria}");
            Console.WriteLine($"Hóspedes: {listarReservas[opcaoReserva - 1].ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {listarReservas[opcaoReserva - 1].CalcularValorDiaria()}");
            Console.ReadKey();
            reserva = new Reserva();
            Console.Clear();
            Menu();
            break;
        default:
            break;
    }
}