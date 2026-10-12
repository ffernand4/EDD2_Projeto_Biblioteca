using System;

namespace ProjetoBiblioteca
{
    class Program
    {
        private static Livros acervoGeral = new Livros();

        static void Main(string[] args)
        {
            int opcao = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("=============================================");
                Console.WriteLine("        SISTEMA DE GESTÃO DE BIBLIOTECA      ");
                Console.WriteLine("=============================================");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                Console.WriteLine("=============================================");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("\nOpção inválida! Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine();

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Saindo do sistema...");
                        break;
                    case 1:
                        AdicionarLivro();
                        break;
                    case 2:
                        PesquisarLivroSintetico();
                        break;
                    case 3:
                        PesquisarLivroAnalitico();
                        break;
                    case 4:
                        AdicionarExemplar();
                        break;
                    case 5:
                        RegistrarEmprestimo();
                        break;
                    case 6:
                        RegistrarDevolucao();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        static void AdicionarLivro()
        {
            Console.WriteLine("--- ADICIONAR LIVRO ---");
            Console.Write("Informe o ISBN (número): ");
            if (!int.TryParse(Console.ReadLine(), out int isbn))
            {
                Console.WriteLine("ISBN inválido.");
                return;
            }

            Livro livroExistente = acervoGeral.Pesquisar(new Livro(isbn));
            if (livroExistente != null)
            {
                Console.WriteLine("Livro já cadastrado com este ISBN!");
                return;
            }

            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Editora: ");
            string editora = Console.ReadLine();

            Livro novoLivro = new Livro(isbn, titulo, autor, editora);
            acervoGeral.Adicionar(novoLivro);

            Console.WriteLine("\nLivro adicionado com sucesso!");
        }

        static void PesquisarLivroSintetico()
        {
            Console.WriteLine("--- PESQUISAR LIVRO (SINTÉTICO) ---");
            Console.Write("Informe o ISBN: ");
            if (!int.TryParse(Console.ReadLine(), out int isbn))
            {
                Console.WriteLine("ISBN inválido.");
                return;
            }

            Livro livro = acervoGeral.Pesquisar(new Livro(isbn));
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            ExibirDadosSinteticos(livro);
        }

        static void ExibirDadosSinteticos(Livro livro)
        {
            Console.WriteLine($"\nISBN: {livro.Isbn}");
            Console.WriteLine($"Título: {livro.Titulo}");
            Console.WriteLine($"Autor: {livro.Autor}");
            Console.WriteLine($"Editora: {livro.Editora}");
            Console.WriteLine($"Total de Exemplares: {livro.QtdeExemplares()}");
            Console.WriteLine($"Exemplares Disponíveis: {livro.QtdeDisponiveis()}");
            Console.WriteLine($"Total de Empréstimos: {livro.QtdeEmprestimos()}");
            Console.WriteLine($"Percentual de Disponibilidade: {livro.PercDisponibilidade():F2}%");
        }

        static void PesquisarLivroAnalitico()
        {
            Console.WriteLine("--- PESQUISAR LIVRO (ANALÍTICO) ---");
            Console.Write("Informe o ISBN: ");
            if (!int.TryParse(Console.ReadLine(), out int isbn))
            {
                Console.WriteLine("ISBN inválido.");
                return;
            }

            Livro livro = acervoGeral.Pesquisar(new Livro(isbn));
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            ExibirDadosSinteticos(livro);

            Console.WriteLine("\n--- DETALHES DOS EXEMPLARES ---");
            if (livro.Exemplares.Count == 0)
            {
                Console.WriteLine("Nenhum exemplar cadastrado para este livro.");
                return;
            }

            foreach (var exemplar in livro.Exemplares)
            {
                Console.WriteLine($"\n  Tombo: {exemplar.Tombo}");
                Console.WriteLine($"  Status: {(exemplar.Disponivel() ? "Disponível" : "Emprestado")}");
                Console.WriteLine($"  Total de Empréstimos: {exemplar.QtdeEmprestimos()}");

                if (exemplar.Emprestimos.Count > 0)
                {
                    Console.WriteLine("  Histórico de Empréstimos:");
                    foreach (var emp in exemplar.Emprestimos)
                    {
                        string dev = emp.DtDevolucao == DateTime.MinValue ? "Em aberto" : emp.DtDevolucao.ToString("dd/MM/yyyy HH:mm:ss");
                        Console.WriteLine($"    - Empréstimo: {emp.DtEmprestimo:dd/MM/yyyy HH:mm:ss} | Devolução: {dev}");
                    }
                }
                else
                {
                    Console.WriteLine("  Histórico: Nenhum empréstimo registrado.");
                }
            }
        }

        static void AdicionarExemplar()
        {
            Console.WriteLine("--- ADICIONAR EXEMPLAR ---");
            Console.Write("Informe o ISBN do livro: ");
            if (!int.TryParse(Console.ReadLine(), out int isbn))
            {
                Console.WriteLine("ISBN inválido.");
                return;
            }

            Livro livro = acervoGeral.Pesquisar(new Livro(isbn));
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            Console.Write("Informe o número de Tombo do exemplar: ");
            if (!int.TryParse(Console.ReadLine(), out int tombo))
            {
                Console.WriteLine("Tombo inválido.");
                return;
            }

            Exemplar novoExemplar = new Exemplar(tombo);
            livro.AdicionarExemplar(novoExemplar);

            Console.WriteLine("\nExemplar adicionado com sucesso!");
        }

        static void RegistrarEmprestimo()
        {
            Console.WriteLine("--- REGISTRAR EMPRÉSTIMO ---");
            Console.Write("Informe o ISBN do livro: ");
            if (!int.TryParse(Console.ReadLine(), out int isbn))
            {
                Console.WriteLine("ISBN inválido.");
                return;
            }

            Livro livro = acervoGeral.Pesquisar(new Livro(isbn));
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            if (livro.QtdeDisponiveis() == 0)
            {
                Console.WriteLine("Não há exemplares disponíveis para este livro.");
                return;
            }

            Exemplar exemplarDisponivel = livro.Exemplares.Find(e => e.Disponivel());
            if (exemplarDisponivel != null && exemplarDisponivel.Emprestar())
            {
                Console.WriteLine($"\nEmpréstimo realizado com sucesso para o exemplar Tombo #{exemplarDisponivel.Tombo}!");
            }
            else
            {
                Console.WriteLine("\nNão foi possível realizar o empréstimo.");
            }
        }

        static void RegistrarDevolucao()
        {
            Console.WriteLine("--- REGISTRAR DEVOLUÇÃO ---");
            Console.Write("Informe o ISBN do livro: ");
            if (!int.TryParse(Console.ReadLine(), out int isbn))
            {
                Console.WriteLine("ISBN inválido.");
                return;
            }

            Livro livro = acervoGeral.Pesquisar(new Livro(isbn));
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            Console.Write("Informe o número de Tombo do exemplar a ser devolvido: ");
            if (!int.TryParse(Console.ReadLine(), out int tombo))
            {
                Console.WriteLine("Tombo inválido.");
                return;
            }

            Exemplar exemplar = livro.Exemplares.Find(e => e.Tombo == tombo);
            if (exemplar == null)
            {
                Console.WriteLine("Exemplar não encontrado para este livro.");
                return;
            }

            if (exemplar.Devolver())
            {
                Console.WriteLine($"\nDevolução do exemplar Tombo #{exemplar.Tombo} registrada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nEste exemplar já está disponível ou não possui empréstimos em aberto.");
            }
        }
    }
}