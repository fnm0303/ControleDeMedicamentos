using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedores;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public static class InjecaoDependencia
{
    public static void AddInfraestruturaEmJson(this IServiceCollection services) //Método de Extensão
    {
        //Adiciona e injeta UMA instância por requisição/conexão
        //seria um modo (logo abaixo outro modo : DELEGATE)
        //builder.Services.AddScoped<ContextoJson>(ContextoJson.InjetarContexto);

        //Expressão Lambda =>
        services.AddScoped(_ => //mesma coisa que colocar DELEGATE
            {
                ContextoJson contexto = new ContextoJson();

                contexto.Carregar();

                return contexto;
            });

        services.AddScoped<RepositorioMedicamentoEmArquivo>();
        services.AddScoped<RepositorioFornecedorEmArquivo>();
        services.AddScoped<RepositorioFuncionarioEmArquivo>();
        services.AddScoped<RepositorioPacienteEmArquivo>();
        services.AddScoped<RepositorioRequisicaoEntradaEmArquivo>();
        services.AddScoped<RepositorioRequisicaoSaidaEmArquivo>();
    }
}