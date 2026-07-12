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
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Requisições de Saída");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -15} | {3, -15} | {4,-10}",
            "Id", "Paciente", "Medicamento", "Data", "Quantidade retirada"
        );

        List<RequisicaoSaida> registros = repositorio.SelecionarTodos();

        foreach (RequisicaoSaida s in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -15} | {3, -15} | {4, -10}",
                s.Id, s.Paciente.Nome, s.MedicamentoRequisitado.Nome, s.Data.ToShortDateString(), s.Quantidade
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
        VisualizarPacientes();
        Console.WriteLine("---------------------------------");
        Console.Write("Digite o ID do paciente que deseja requisitar a saída: ");
        int idPaciente = Convert.ToInt32(Console.ReadLine());

        Paciente paciente = repositorioPaciente.SelecionarPorId(idPaciente)!;

        Console.WriteLine("---------------------------------");
        VisualizarMedicamentos();
        Console.WriteLine("---------------------------------");
        Console.Write("Digite o ID do medicamento que deseja requisitar a saída: ");
        int idMedicamento = Convert.ToInt32(Console.ReadLine());

        Medicamento medicamento = repositorioMedicamento.SelecionarPorId(idMedicamento)!;

        Console.Write("Digite a quantidade que deseja requisitar: ");
        int quantidade = Convert.ToInt32(Console.ReadLine());

        return new RequisicaoSaida(paciente, medicamento, quantidade);
    }

    private void VisualizarPacientes()
    {
        Console.WriteLine(
                    "{0, -7} | {1, -30} | {2, -15} | {3, -17} | {4, -15}",
                    "Id", "Nome", "Telefone", "Cartão SUS", "CPF"
                );

        List<Paciente> registros = repositorioPaciente.SelecionarTodos();

        foreach (Paciente p in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -17} | {4, -15}",
                p.Id, p.Nome, p.Telefone, p.CartaoSus, p.CPF
            );
        }
    }
    private void VisualizarMedicamentos()
    {
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20} | {3, -25}",
            "Id", "Nome", "Fornecedor", "Quantidade em estoque"
        );

        List<Medicamento> registros = repositorioMedicamento.SelecionarTodos();

        foreach (Medicamento m in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -25}",
                m.Id, m.Nome, m.Fornecedor.Nome, m.QuantidadeEmEstoque
            );
        }
    }

    protected override void ExecutarPosValidacao(RequisicaoSaida entidade)
    {
        RequisicaoSaida requisicao = entidade;

        requisicao.MedicamentoRequisitado.RegistrarSaida(requisicao);
    }

}
