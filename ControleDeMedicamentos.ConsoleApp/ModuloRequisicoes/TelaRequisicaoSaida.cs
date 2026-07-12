using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public class TelaRequisicaoSaida : TelaBase<RequisicaoSaida>, ITelaOpcoes, ITelaCrud
{
    private readonly RepositorioPacienteEmArquivo repositorioPaciente;
    private readonly RepositorioMedicamentoEmArquivo repositorioMedicamento;
    public TelaRequisicaoSaida(
        RepositorioRequisicaoSaidaEmArquivo repositorioSaida,
        RepositorioPacienteEmArquivo repositorioPaciente,
        RepositorioMedicamentoEmArquivo repositorioMedicamento) : base("Requisição de Saída", repositorioSaida)
    {
        this.repositorioPaciente = repositorioPaciente;
        this.repositorioMedicamento = repositorioMedicamento;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            //Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Requisições de Saída");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -15} | {3, -15}",
            "Id", "Paciente", "Medicamento", "Data"
        );

        List<RequisicaoSaida> registros = repositorio.SelecionarTodos();

        foreach (RequisicaoSaida s in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -15} | {3, -15}",
                s.Id, s.Paciente.Nome, s.MedicamentoRequisitado.Nome, s.Data.ToShortDateString()
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override RequisicaoSaida ObterDadosCadastrais()
    {
        throw new NotImplementedException();
    }
}
