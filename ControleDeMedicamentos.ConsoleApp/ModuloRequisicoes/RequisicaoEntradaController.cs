using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public sealed class RequisicaoEntradaController : Controller
{
    private readonly RepositorioRequisicaoEntradaEmArquivo repositorioEntrada;
    private readonly RepositorioMedicamentoEmArquivo repositorioMedicamento;
    public RequisicaoEntradaController()
    {
        ContextoJson contexto = new ContextoJson();

        contexto.Carregar();

        repositorioEntrada = new RepositorioRequisicaoEntradaEmArquivo(contexto);
        repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contexto);
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<RequisicaoEntrada> entradas = repositorioEntrada.SelecionarTodos();

        List<ListarRequisicaoEntradaViewModel> viewModels = new List<ListarRequisicaoEntradaViewModel>();

        foreach (RequisicaoEntrada e in entradas)
        {
            ListarRequisicaoEntradaViewModel vm = new ListarRequisicaoEntradaViewModel(e.Id, e.Medicamento, e.Quantidade, e.Data);
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
    public ActionResult Cadastrar(CadastrarRequisicaoEntradaViewModel cadastrarVm)
    {
        Medicamento? medicamento = repositorioMedicamento.SelecionarPorId(cadastrarVm.MedicamentoId);

        if (medicamento == null)
            return NotFound();

        RequisicaoEntrada entrada = new RequisicaoEntrada(medicamento, cadastrarVm.Quantidade);

        repositorioEntrada.Cadastrar(entrada);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(int id)
    {
        RequisicaoEntrada? entradaSelecionada = repositorioEntrada.SelecionarPorId(id);

        if (entradaSelecionada == null)
            return NotFound();

        ExcluirRequisicaoEntradaViewModel vm = new ExcluirRequisicaoEntradaViewModel(id);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirRequisicaoEntradaViewModel excluirVm)
    {
        bool conseguiuExcluir = repositorioEntrada.Excluir(excluirVm.Id);

        if (!conseguiuExcluir)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }

}
