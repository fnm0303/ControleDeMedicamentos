namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

public record ListarFuncionarioViewModel(int Id, string Nome, string Telefone);

public record CadastrarFuncionarioViewModel(string Nome, string Telefone, string CPF);

public record EditarFuncionarioViewModel(int Id, string Nome, string Telefone, string CPF);
