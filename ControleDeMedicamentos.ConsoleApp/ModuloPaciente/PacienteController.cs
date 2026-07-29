using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public sealed class PacienteController : Controller
{
    private readonly RepositorioPacienteEmArquivo repositorioPaciente;
    public PacienteController()
    {
        ContextoJson contexto = new ContextoJson();

        contexto.Carregar();

        repositorioPaciente = new RepositorioPacienteEmArquivo(contexto);
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Paciente> pacientes = repositorioPaciente.SelecionarTodos();

        List<ListarPacienteViewModel> viewModels = new List<ListarPacienteViewModel>();

        foreach (Paciente p in pacientes)
        {
            ListarPacienteViewModel vm = new ListarPacienteViewModel(p.Id, p.Nome, p.Telefone, p.CartaoSus);
            viewModels.Add(vm);
        }
        return View(viewModels);
    }

}
