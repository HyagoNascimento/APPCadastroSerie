using System;

namespace DIO.Series{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
        string opcaoUsuario = ObterOpcaoUsuario();
        while (opcaoUsuario.ToUpper()!="X"){
            switch(opcaoUsuario){
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSerie();
                    break;
                case "3":
                   AtualizarSerie();
                    break;
                case "4":
                   ExcluirSerie();
                    break;
                case "5":
                   VisualizarSerie();
                    break;
                case "C":
                   Console.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            opcaoUsuario = ObterOpcaoUsuario();
        }
        Console.WriteLine("Obrigado por utilizar nossos serviços!!!");
        Console.WriteLine();
        }

    private static void ListarSeries()
    {
        Console.WriteLine("Listar Séries.");
        var Lista = repositorio.Lista();

        if(Lista.Count ==0)
        {
            Console.WriteLine("Nenhuma série encontrada.");
            return;
        }
        foreach (var serie in Lista)
        {
            var excluido = serie.retornaExcluido();
        Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));

        }
    }

    private static void InserirSerie()
    {         
        Console.WriteLine("Insira uma nova série.");

        foreach(int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("#ID {0}: - {1}", i, Enum.GetName(typeof(Genero),i ));
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());
        
        Console.Write("Digite o Título da Série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição da Série: ");
        string entradaDescricao = Console.ReadLine();

        Serie novaSerie = new Serie ( Id: repositorio.Proximoid(),
                                      genero: (Genero)entradaGenero,
                                      titulo: entradaTitulo,
                                      ano: entradaAno,
                                      descricao: entradaDescricao);
        repositorio.Insere(novaSerie);
    }
    private static void AtualizarSerie()
    {         
        Console.WriteLine("Digite o ID da série:  ");
        int indiceSerie = int.Parse(Console.ReadLine());

        foreach(int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("#ID {0}: - {1}", i, Enum.GetName(typeof(Genero),i ));
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());
        
        Console.Write("Digite o Título da Série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite o gênero entre as opções acima: ");
        string entradaDescricao = Console.ReadLine();

        Serie atualizaSerie = new Serie ( Id: indiceSerie,
                                      genero: (Genero)entradaGenero,
                                      titulo: entradaTitulo,
                                      ano: entradaAno,
                                      descricao: entradaDescricao);
       
        repositorio.Atualiza(indiceSerie, atualizaSerie);
    }
    
    private static void ExcluirSerie()
    {
        Console.WriteLine("Digite o ID da série:  ");
        int indiceSerie = int.Parse(Console.ReadLine());

        repositorio.Exclui(indiceSerie);
    }

    private static void VisualizarSerie()
    {
        Console.WriteLine("Digite o ID da série:  ");
        int indiceSerie = int.Parse(Console.ReadLine());

        var serie = repositorio.RetornaPorId(indiceSerie);

        Console.WriteLine(serie);
    }
    private static string ObterOpcaoUsuario()
    {
    Console.WriteLine();
    Console.WriteLine("DIO Séries na palma da mão!!!");
    Console.WriteLine("Infome a opção desejada: ");

    Console.WriteLine("1 - Listar Séries.");
    Console.WriteLine("2 - Inserir Nova Série.");
    Console.WriteLine("3 - Atualizar Série.");
    Console.WriteLine("4 - Excluir Série.");
    Console.WriteLine("5 - Visualizar Série.");
    Console.WriteLine("C - Limpar Tela.");
    Console.WriteLine("X - Sair.");
    Console.WriteLine(); 

    string opcaoUsuario = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return opcaoUsuario;   
    }


    }
}