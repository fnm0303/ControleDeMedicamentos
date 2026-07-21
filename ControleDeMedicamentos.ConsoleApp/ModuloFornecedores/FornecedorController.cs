using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedores;

public sealed class FornecedorController : Controller
{
    private readonly RepositorioFornecedorEmArquivo repositorio;
    public FornecedorController()
    {
        ContextoJson contexto = new ContextoJson();
        contexto.Carregar();
        repositorio = new RepositorioFornecedorEmArquivo(contexto);
    }
    [HttpGet] //método será acessado pela barra de endereços do navegador
    public ActionResult Listar()
    {
        List<Fornecedor> fornecedores = repositorio.SelecionarTodos();
        return View(fornecedores); //retorna uma página View
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(string nome, string telefone, string cnpj)
    {
        Fornecedor fornecedor = new Fornecedor(nome, telefone, cnpj);
        repositorio.Cadastrar(fornecedor);
        return RedirectToAction(nameof(Listar));
    }
}
