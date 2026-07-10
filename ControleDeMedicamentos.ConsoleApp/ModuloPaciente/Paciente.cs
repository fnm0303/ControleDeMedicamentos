using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public class Paciente : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CartaoSus { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;

    public Paciente() { }
    public Paciente(string nome, string telefone, string cartaoSus, string cpf) : this()
    {
        Nome = nome;
        Telefone = telefone;
        CartaoSus = cartaoSus;
        CPF = cpf;
    }
    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Paciente pacienteAtualizado = (Paciente)entidadeAtualizada;

        Nome = pacienteAtualizado.Nome;
        Telefone = pacienteAtualizado.Telefone;
        CartaoSus = pacienteAtualizado.CartaoSus;
        CPF = pacienteAtualizado.CPF;
    }
}
