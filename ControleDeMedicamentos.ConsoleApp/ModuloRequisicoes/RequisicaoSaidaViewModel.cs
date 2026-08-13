using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
public record ListarRequisicaoSaidaViewModel(int Id, Medicamento MedicamentoRequisitado, int Quantidade, DateTime Data);

public record CadastrarRequisicaoSaidaViewModel(int PacienteId, int MedicamentoId, int Quantidade);

public record ExcluirRequisicaoSaidaViewModel(int Id);