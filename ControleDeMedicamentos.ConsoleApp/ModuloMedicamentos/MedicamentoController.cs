using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedores;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;

public sealed class MedicamentoController : Controller
{
    private readonly RepositorioMedicamentoEmArquivo repositorioMedicamento;
    private readonly RepositorioFornecedorEmArquivo repositorioFornecedor;

    public MedicamentoController()
    {
        ContextoJson contexto = new ContextoJson();
        contexto.Carregar();
        repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contexto);
        repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Medicamento> medicamentos = repositorioMedicamento.SelecionarTodos();
        return View(medicamentos);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        List<Fornecedor> fornecedores = repositorioFornecedor.SelecionarTodos();

        ViewBag.Fornecedores = fornecedores;

        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(string nome, string descricao, int fornecedorId)
    {
        Fornecedor? fornecedor = repositorioFornecedor.SelecionarPorId(fornecedorId);

        if (fornecedor == null)
            return NotFound();

        Medicamento medicamento = new Medicamento(nome, descricao, fornecedor);

        repositorioMedicamento.Cadastrar(medicamento);

        return RedirectToAction(nameof(Listar));
    }
}
