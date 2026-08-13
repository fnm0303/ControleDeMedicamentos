using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedores;

public sealed class FornecedorController : Controller
{
    private readonly RepositorioFornecedorEmArquivo repositorioFornecedor;
    public FornecedorController(RepositorioFornecedorEmArquivo repositorioFornecedor)
    {
        this.repositorioFornecedor = repositorioFornecedor;
    }
    [HttpGet] //método será acessado pela barra de endereços do navegador
    public ActionResult Listar()
    {
        List<Fornecedor> fornecedores = repositorioFornecedor.SelecionarTodos();
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
        repositorioFornecedor.Cadastrar(fornecedor);
        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(int id)
    {
        Fornecedor? fornecedor = repositorioFornecedor.SelecionarPorId(id);

        if (fornecedor == null)
            return NotFound();

        return View(fornecedor);
    }

    [HttpPost]
    public ActionResult Editar(int id, string nome, string telefone, string cnpj)
    {
        Fornecedor? fornecedor = repositorioFornecedor.SelecionarPorId(id);

        if (fornecedor == null)
            return NotFound();

        Fornecedor fornecedorAtualizado = new Fornecedor(nome, telefone, cnpj);

        bool conseguiuEditar = repositorioFornecedor.Editar(id, fornecedorAtualizado);

        if (!conseguiuEditar)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(int id)
    {
        Fornecedor? fornecedor = repositorioFornecedor.SelecionarPorId(id);

        if (fornecedor == null)
            return NotFound();

        return View(fornecedor);
    }

    [HttpPost]
    [ActionName("Excluir")]
    public ActionResult ConfirmarExclusao(int id)
    {
        Fornecedor? fornecedor = repositorioFornecedor.SelecionarPorId(id);

        bool conseguiuExcluir = repositorioFornecedor.Excluir(id);

        if (!conseguiuExcluir)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }
}
