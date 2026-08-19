// Instancia o construtor do servidor...
// ...configura as dependências internas (controladores e serviços) e externas (repositórios)
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//Habilita o armazenamento em JSON
builder.Services.AddInfraestruturaEmJson();

//Habilita o MVC (Model, View, Controller)
builder.Services.AddControllersWithViews();

// Constroi a instância do servidor...
// ...configura os middlewares executados durante requisições
WebApplication app = builder.Build();

// Mapeia controladores e rotas que serão gerenciadas pelo servidor
//middlewares
app.UseRouting();

//conectando URLs aos controlles (rotas)
app.MapDefaultControllerRoute();

app.UseStaticFiles();
// Inicia o loop do servidor web, escuta por requisições na porta especificada
app.Run();

/*using System.Text.Json;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;

ContextoJson contexto = new ContextoJson();

try
{
    contexto.Carregar();
}
catch (JsonException)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("O formato do arquivo de armazenamento está corrompido...");
    Console.Write("Prosseguir com alterações pode causar a sobrescrita dos dados.");
    Console.ResetColor();
    Console.ReadLine();
}
catch
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("Ocorreu um erro inesperado. O programa irá encerrar em 3 segundos...");
    Console.ResetColor();

    Thread.Sleep(TimeSpan.FromSeconds(3));

    return;
}

TelaPrincipal telaPrincipal = new TelaPrincipal(contexto);

while (true)
{
    ITelaOpcoes? telaSelecionada = telaPrincipal.ObterOpcaoMenuPrincipal();

    if (telaSelecionada == null)
        break;

    while (true)
    {
        string? opcaoMenuInterno = telaSelecionada.ObterOpcaoMenu();

        if (opcaoMenuInterno == "S")
            break;

        if (telaSelecionada is ITelaCrud telaBase)
        {
            if (opcaoMenuInterno == "1")
                telaBase.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaBase.Editar();

            else if (opcaoMenuInterno == "3")
                telaBase.Excluir();

            else if (opcaoMenuInterno == "4")
                telaBase.VisualizarTodos(true);
        }
    }
}*/
