using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public sealed class RequisicaoSaidaController : Controller
{
    private readonly RepositorioRequisicaoSaidaEmArquivo repositorioSaida;
    private readonly RepositorioPacienteEmArquivo repositorioPaciente;
    private readonly RepositorioMedicamentoEmArquivo repositorioMedicamento;

    public RequisicaoSaidaController()
    {
        ContextoJson contexto = new ContextoJson();

        contexto.Carregar();

        repositorioSaida = new RepositorioRequisicaoSaidaEmArquivo(contexto);
        repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contexto);
        repositorioPaciente = new RepositorioPacienteEmArquivo(contexto);
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<RequisicaoSaida> saidas = repositorioSaida.SelecionarTodos();

        List<ListarRequisicaoSaidaViewModel> viewModels = new List<ListarRequisicaoSaidaViewModel>();

        foreach (RequisicaoSaida s in saidas)
        {
            ListarRequisicaoSaidaViewModel vm = new ListarRequisicaoSaidaViewModel(s.Id, s.MedicamentoRequisitado, s.Quantidade, s.Data);
            viewModels.Add(vm);
        }

        return View(viewModels);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        ViewBag.Medicamentos = new SelectList(repositorioMedicamento.SelecionarTodos(), "Id", "Nome");
        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarRequisicaoSaidaViewModel cadastrarVm)
    {
        Medicamento? medicamento = repositorioMedicamento.SelecionarPorId(cadastrarVm.MedicamentoId);

        Paciente? paciente = repositorioPaciente.SelecionarPorId(cadastrarVm.PacienteId);

        if (medicamento == null)
            return NotFound();


        RequisicaoSaida saida = new RequisicaoSaida(paciente!, medicamento, cadastrarVm.Quantidade);

        repositorioSaida.Cadastrar(saida);

        saida.MedicamentoRequisitado.RegistrarSaida(saida);

        return RedirectToAction(nameof(Listar));
    }


}

