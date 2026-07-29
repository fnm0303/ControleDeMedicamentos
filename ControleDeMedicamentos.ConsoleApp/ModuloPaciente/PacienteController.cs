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

    [HttpGet]
    public ActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarPacienteViewModel cadastrarVm)
    {
        Paciente paciente = new Paciente(cadastrarVm.Nome, cadastrarVm.Telefone, cadastrarVm.CartaoSus, cadastrarVm.CPF);

        repositorioPaciente.Cadastrar(paciente);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(int id)
    {
        Paciente? pacienteSelecionado = repositorioPaciente.SelecionarPorId(id);

        if (pacienteSelecionado == null)
            return NotFound();

        EditarPacienteViewModel vm = new EditarPacienteViewModel(id, pacienteSelecionado.Nome, pacienteSelecionado.Telefone, pacienteSelecionado.CartaoSus, pacienteSelecionado.CPF);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Editar(EditarPacienteViewModel editarVm)
    {
        Paciente pacienteAtualizado = new Paciente(editarVm.Nome, editarVm.Telefone, editarVm.CartaoSus, editarVm.CPF);

        bool conseguiuEditar = repositorioPaciente.Editar(editarVm.Id, pacienteAtualizado);

        if (!conseguiuEditar)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }

}
