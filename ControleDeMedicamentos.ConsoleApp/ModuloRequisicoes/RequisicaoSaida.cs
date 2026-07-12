using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public class RequisicaoSaida : EntidadeBase
{
    public DateTime Data { get; set; } = DateTime.Now;
    public Paciente Paciente { get; set; } = null!;
    public Medicamento MedicamentoRequisitado { get; set; } = null!;

    public RequisicaoSaida() { }
    public RequisicaoSaida(Paciente paciente, Medicamento medicamentoRequisitado) : this()
    {
        Paciente = paciente;
        MedicamentoRequisitado = medicamentoRequisitado;
    }
    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        RequisicaoSaida requisicaoAtualizada = (RequisicaoSaida)entidadeAtualizada;

        Paciente = requisicaoAtualizada.Paciente;
        MedicamentoRequisitado = requisicaoAtualizada.MedicamentoRequisitado;
    }

}
