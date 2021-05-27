using System;

namespace CadastroSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcao = OpcaoUsuario();

           while(opcao.ToUpper() != "S")
           {
               switch(opcao)
               {
                   case "1":
                        ListarSeries();
                        break;
                    case "2":
                        CadastrarSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "L":
                        Console.Clear();
                        break;
                    default:
                    throw new ArgumentOutOfRangeException();
               }

               opcao = OpcaoUsuario();
           }

           Console.WriteLine("Volte sempre!!");
           Console.ReadLine();
        }

        private static void VisualizarSeries()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void ExcluirSeries()
        {
            Console.Write("Digite o id da série: ");
            int escolhaId = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(escolhaId);
            Console.WriteLine(serie);

            Console.Write("\nDeseja mesmo excluir a série acima? (Digite 1 para confirmar ou 2 para cancelar): ");
            int respostaConfirma = int.Parse(Console.ReadLine());            

            if(respostaConfirma == 1)
            {
                repositorio.Exclui(escolhaId);
                Console.WriteLine("Série Excluída");
            }
            else
            {
                Console.WriteLine("Exclusão cancelada");
                return;
            }

            
        }

        private static void AtualizarSeries()
        {
            Console.Write("Digite o ID da série: ");
            int escolhaId = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Gênero entre as opções acima: ");
            int escolhaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série: ");
            string escolhaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano da série: ");
            int escolhaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da série: ");
            string escolhaDescricao = Console.ReadLine();

            Console.Write("Digite a Plataforma(Netflix, Amazon Prime, Disney+) da série: ");
            string escolhaPlataforma = Console.ReadLine();

            Console.Write("Digite quantas Temporadas a série possui: ");
            int escolhaTemporadas = int.Parse(Console.ReadLine());

            Serie atualizaSerie = new Serie(id: escolhaId, genero: (Genero)escolhaGenero, titulo: escolhaTitulo, descricao: escolhaDescricao,
                                        ano: escolhaAno, plataforma: escolhaPlataforma, temporadas: escolhaTemporadas); 

            repositorio.Atualiza(escolhaId, atualizaSerie);
        }

        private static void CadastrarSeries()
        {
            Console.WriteLine("Cadastrar nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Gênero entre as opções acima: ");
            int escolhaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série: ");
            string escolhaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano da série: ");
            int escolhaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da série: ");
            string escolhaDescricao = Console.ReadLine();

            Console.Write("Digite a Plataforma(Netflix, Amazon Prime, Disney+) da série: ");
            string escolhaPlataforma = Console.ReadLine();

            Console.Write("Digite quantas Temporadas a série possui: ");
            int escolhaTemporadas = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),genero: (Genero)escolhaGenero, titulo: escolhaTitulo, descricao: escolhaDescricao,
                                        ano: escolhaAno, plataforma: escolhaPlataforma, temporadas: escolhaTemporadas);                                                                     

            repositorio.Insere(novaSerie);                              

        }

        private static void ListarSeries()
        {
            Console.WriteLine("Mostrar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if(!excluido)
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
                
            }
        }

        private static string OpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Cadastro de Séries!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Mostrar séries");
            Console.WriteLine("2 - Cadastrar nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("L - Limpar Tela");
            Console.WriteLine("S - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }   
        
        
    }
}
