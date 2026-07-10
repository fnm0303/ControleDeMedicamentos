using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public class TelaPaciente : TelaBase<Paciente>, ITelaOpcoes, ITelaCrud
{
    public TelaPaciente(RepositorioBaseEmArquivo<Paciente> repositorio) : base("Paciente", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Pacientes");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -15} | {3, -17} | {4, -15}",
            "Id", "Nome", "Telefone", "Cartão SUS", "CPF"
        );

        List<Paciente> registros = repositorio.SelecionarTodos();

        foreach (Paciente p in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -17} | {4, -15}",
                p.Id, p.Nome, p.Telefone, p.CartaoSus, p.CPF
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Paciente ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do paciente: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone do paciente \"(xx) xxxxx-xxxx:\" ");
        string telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o número do Cartão do SUS do paciente: ");
        string cartaoSUS = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o CPF do paciente (somente números): ");
        string cpf = Console.ReadLine() ?? string.Empty;

        return new Paciente(nome, telefone, cartaoSUS, cpf);
    }
}
