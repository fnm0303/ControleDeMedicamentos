namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public record ListarPacienteViewModel(int Id, string Nome, string Telefone, string CartaoSus);

public record CadastrarPacienteViewModel(string Nome, string Telefone, string CartaoSus, string CPF);

public record EditarPacienteViewModel(int Id, string Nome, string Telefone, string CartaoSus, string CPF);
public record ExcluirPacienteViewModel(int Id, string Nome);