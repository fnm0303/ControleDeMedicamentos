using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public sealed class RequisicaoSaidaController : Controller
{
    private readonly RepositorioRequisicaoSaidaEmArquivo repositorioSaida;

    private readonly RepositorioMedicamentoEmArquivo repositorioMedicamento;

    public RequisicaoSaidaController()
    {
        ContextoJson contexto = new ContextoJson();

        contexto.Carregar();

        repositorioSaida = new RepositorioRequisicaoSaidaEmArquivo(contexto);
        repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contexto);
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

}

