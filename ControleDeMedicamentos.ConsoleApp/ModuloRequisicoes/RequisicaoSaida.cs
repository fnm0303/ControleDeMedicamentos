using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public class RequisicaoSaida : EntidadeBase
{
    public DateTime Data { get; set; } = DateTime.Now;
    public int Quantidade { get; set; }
    public Paciente Paciente { get; set; } = null!;
    public Medicamento MedicamentoRequisitado { get; set; } = null!;

    public RequisicaoSaida() { }
    public RequisicaoSaida(Paciente paciente, Medicamento medicamentoRequisitado, int quantidade) : this()
    {
        Paciente = paciente;
        MedicamentoRequisitado = medicamentoRequisitado;
        Quantidade = quantidade;

        medicamentoRequisitado.RegistrarSaida(this);
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Paciente == null)
            erros.Add("O campo \"Paciente\" deve ser preenchido.");

        if (MedicamentoRequisitado == null)
            erros.Add("O campo \"Medicamento\" deve ser preenchido.");

        if (Quantidade > MedicamentoRequisitado.QuantidadeEmEstoque)
            erros.Add("A \"Quantidade\" deve ser menor ou igual ao estoque disponível do medicamento.");

        return erros;
    }
    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        RequisicaoSaida requisicaoAtualizada = (RequisicaoSaida)entidadeAtualizada;

        Paciente = requisicaoAtualizada.Paciente;
        MedicamentoRequisitado = requisicaoAtualizada.MedicamentoRequisitado;
    }

}
