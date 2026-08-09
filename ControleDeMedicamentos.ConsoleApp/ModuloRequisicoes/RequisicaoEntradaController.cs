using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public sealed class RequisicaoEntradaController : Controller
{
    private readonly RepositorioRequisicaoEntradaEmArquivo repositorioEntrada;
    public RequisicaoEntradaController()
    {
        ContextoJson contexto = new ContextoJson();

        contexto.Carregar();

        repositorioEntrada = new RepositorioRequisicaoEntradaEmArquivo(contexto);
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
}
