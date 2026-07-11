using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

public class Funcionario : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;

    public Funcionario() { }
    public Funcionario(string nome, string telefone, string cpf) : this()
    {
        Nome = nome;
        Telefone = telefone;
        CPF = cpf;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Funcionario funcionarioAtualizado = (Funcionario)entidadeAtualizada;

        Nome = funcionarioAtualizado.Nome;
        Telefone = funcionarioAtualizado.Telefone;
        CPF = funcionarioAtualizado.CPF;
    }

    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
}
