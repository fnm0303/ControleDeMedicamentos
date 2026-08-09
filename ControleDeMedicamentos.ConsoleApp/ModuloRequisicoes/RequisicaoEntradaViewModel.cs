using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
public record ListarRequisicaoEntradaViewModel(int Id, Medicamento Medicamento, int Quantidade, DateTime Data);

public record CadastrarRequisicaoEntradaViewModel(int MedicamentoId, int Quantidade);

public record ExcluirRequisicaoEntradaViewModel(int Id);

