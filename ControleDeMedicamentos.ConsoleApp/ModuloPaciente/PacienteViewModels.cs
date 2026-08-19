using System.ComponentModel.DataAnnotations;
namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public record ListarPacienteViewModel(int Id, string Nome, string Telefone, string CartaoSus);

public record CadastrarPacienteViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage ="O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" é obrigatório.")]
    [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage ="O campo \"Telefone\" deve estar no formato (DDD) 90000-0000.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"Cartão SUS\" é obrigatório.")]
    [RegularExpression(@"\d{15}", ErrorMessage ="O campo \"Cartão SUS\" deve conter 15 dígitos (valores numéricos).")]
    string CartaoSus,

    [Required(ErrorMessage = "O campo \"CPF\" é obrigatório.")]
    [RegularExpression(@"\d{11}", ErrorMessage ="O campo \"CPF\" deve conter 11 dígitos (valores numéricos)")]
    string CPF);

public record EditarPacienteViewModel(
    int Id,
     [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage ="O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" é obrigatório.")]
    [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage ="O campo \"Telefone\" deve estar no formato (DDD) 90000-0000.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"Cartão SUS\" é obrigatório.")]
    [RegularExpression(@"\d{15}", ErrorMessage ="O campo \"Cartão SUS\" deve conter 15 dígitos (valores numéricos).")]
    string CartaoSus,

    [Required(ErrorMessage = "O campo \"CPF\" é obrigatório.")]
    [RegularExpression(@"\d{11}", ErrorMessage ="O campo \"CPF\" deve conter 11 dígitos (valores numéricos)")]
    string CPF
);

public record ExcluirPacienteViewModel(int Id, string Nome);