using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

public sealed class FuncionarioController : Controller
{
    private readonly RepositorioFuncionarioEmArquivo repositorioFuncionario;
    public FuncionarioController()
    {
        ContextoJson contexto = new ContextoJson();

        contexto.Carregar();

        repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contexto);
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
}
