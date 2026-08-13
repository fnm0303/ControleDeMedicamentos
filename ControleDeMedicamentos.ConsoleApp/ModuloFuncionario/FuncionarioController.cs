using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

public sealed class FuncionarioController : Controller
{
    private readonly RepositorioFuncionarioEmArquivo repositorioFuncionario;
    public FuncionarioController(RepositorioFuncionarioEmArquivo repositorioFuncionario)
    {
        this.repositorioFuncionario = repositorioFuncionario;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Funcionario> funcionarios = repositorioFuncionario.SelecionarTodos();

        List<ListarFuncionarioViewModel> viewModels = new List<ListarFuncionarioViewModel>();

        foreach (Funcionario f in funcionarios)
        {
            ListarFuncionarioViewModel vm = new ListarFuncionarioViewModel(f.Id, f.Nome, f.Telefone);

            viewModels.Add(vm);
        }

        return View(viewModels); //tudo isso para não passar o CPF, não passar todas as informações de uma lista
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarFuncionarioViewModel cadastrarVm)
    {
        Funcionario funcionario = new Funcionario(cadastrarVm.Nome, cadastrarVm.Telefone, cadastrarVm.CPF);

        repositorioFuncionario.Cadastrar(funcionario);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(int id)
    {
        Funcionario? funcionarioSelecionado = repositorioFuncionario.SelecionarPorId(id);

        if (funcionarioSelecionado == null)
            return NotFound();

        EditarFuncionarioViewModel vm = new EditarFuncionarioViewModel(id, funcionarioSelecionado.Nome, funcionarioSelecionado.Telefone, funcionarioSelecionado.CPF);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Editar(EditarFuncionarioViewModel editarVm)
    {
        Funcionario funcionarioAtualizado = new Funcionario(editarVm.Nome, editarVm.Telefone, editarVm.CPF);

        bool conseguiuEditar = repositorioFuncionario.Editar(editarVm.Id, funcionarioAtualizado);

        if (!conseguiuEditar)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(int id)
    {
        Funcionario? funcionarioSelecionado = repositorioFuncionario.SelecionarPorId(id);

        if (funcionarioSelecionado == null)
            return NotFound();

        ExcluirFuncionarioViewModel vm = new ExcluirFuncionarioViewModel(id, funcionarioSelecionado.Nome);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirFuncionarioViewModel excluirVm)
    {
        bool conseguiuExcluir = repositorioFuncionario.Excluir(excluirVm.Id);

        if (!conseguiuExcluir)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }
}
