using System.Runtime.Serialization;
using System.Data;
using System;

namespace StarSeries
{
    class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
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
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

			private static void ExcluirSerie()
			{
				Console.Write("Digite o id da série que deseja excluir: ");
				int indiceSerie = int.Parse(Console.ReadLine());

				repositorio.Exclui(indiceSerie);
			}

			private static void VisualizarSerie()
			{
				Console.WriteLine("Digite o id da série: ");
				int indiceSerie = int.Parse(Console.ReadLine());

				var series = repositorio.RetornaPorId(indiceSerie);
				Console.WriteLine(series);

			}

			private static void  ListarSeries()
			{
				Console.WriteLine("Listar Series");

				var lista = repositorio.Lista();

				if (lista.Count == 0)
				{
					Console.WriteLine("Nenhuma série Cadastrada");
					return;
				}

				foreach (var serie in lista)
				{
					var excluido = serie.retornaExcluido(); 	
					Console.WriteLine("#ID {0}: {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : " "));
				}

			}

			private static void AtualizarSerie()
			{
				Console.WriteLine("Digite o Id da série: ");
				int indiceSerie = int.Parse(Console.ReadLine());

				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0} . {1}", i, Enum.GetName(typeof(Genero), i));
				}

				Console.WriteLine("Digite o gênero entre as opções acima: ");
				int entradaGenero = int.Parse(Console.ReadLine());

				Console.WriteLine("Digite o título da série: ");
				string entradaTitulo = Console.ReadLine();

				Console.WriteLine("Digite o ano que a série foi criada: ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.WriteLine("Digite a sinopse da série: ");
				string entradaSinopse = Console.ReadLine();

				Series atualizaSerie = new Series(id: indiceSerie,
											genero: (Genero)entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											sinopse: entradaSinopse);
				
				repositorio.Atualiza(indiceSerie , atualizaSerie);
			}

			private static void InserirSerie()
			{
				Console.WriteLine("Imprimir Uma Nova Série");

				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0} . {1}", i, Enum.GetName(typeof(Genero), i));
				}

				Console.WriteLine("Digite o gênero entre as opções acima: ");
				int entradaGenero = int.Parse(Console.ReadLine());

				Console.WriteLine("Digite o título da série: ");
				string entradaTitulo = Console.ReadLine();

				Console.WriteLine("Digite o ano que a série foi criada: ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.WriteLine("Digite a sinopse da série: ");
				string entradaSinopse = Console.ReadLine();

				Series novaSerie = new Series(id: repositorio.ProxId(),
											genero: (Genero)entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											sinopse: entradaSinopse);
				
				repositorio.Insere(novaSerie);
			}



            private static string ObterOpcaoUsuario()
            {
                Console.WriteLine();
                Console.WriteLine("DIO Séries a seu dispor!!!");
                Console.WriteLine("Informe a opção desejada:");

                Console.WriteLine("1- Listar séries");
                Console.WriteLine("2- Inserir nova série");
                Console.WriteLine("3- Atualizar série");
                Console.WriteLine("4- Excluir série");
                Console.WriteLine("5- Visualizar série");
                Console.WriteLine("C- Limpar Tela");
                Console.WriteLine("X- Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }
        }
}
