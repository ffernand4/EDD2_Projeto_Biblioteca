# Projeto Biblioteca — Estrutura de Dados 2 (CBTEDD2)

**Instituto Federal de Educação, Ciência e Tecnologia de São Paulo — Campus Cubatão**  
**Curso:** Tecnologia em Análise e Desenvolvimento de Sistemas (TADS)  
**Disciplina:** Estrutura de Dados 2 (`CBTEDD2`)  
**Atividade:** 06 — Projeto Biblioteca (Listas)  

---

## Descrição do Projeto

O **Projeto Biblioteca** é uma aplicação de console (Console Application) desenvolvida em C# para o gerenciamento de acervos bibliográficos, controle de exemplares físicos e registro de empréstimos e devoluções.

O sistema utiliza a estrutura de dados dinâmica `List<T>` do .NET para vincular relacionalmente livros, seus exemplares e os históricos de empréstimos em memória.

---

## Diagrama de Classes

```
+----------------------------------------------+
| Livro                                        |
+----------------------------------------------+
| - isbn: int                                  |
| - titulo: string                             |
| - autor: string                              |
| - editora: string                            |
| - exemplares: List<Exemplar>                 |
+----------------------------------------------+
| + adicionarExemplar(Exemplar exemplar): void |
| + qtdeExemplares(): int                      |
| + qtdeDisponiveis(): int                     |
| + qtdeEmprestimos(): int                     |
| + percDisponibilidade(): double              |
+----------------------------------------------+

+---------------------------------+
| Exemplar                        |
+---------------------------------+
| - tombo: int                    |
| - emprestimos: List<Emprestimo> |
+---------------------------------+
| + emprestar(): bool             |
| + devolver(): bool              |
| + disponivel(): bool            |
| + qtdeEmprestimos(): int        |
+---------------------------------+

+--------------------------+
| Emprestimo               |
+--------------------------+
| - dtEmprestimo: DateTime |
| - dtDevolucao: DateTime  |
+--------------------------+

+---------------------------------+
| Livros                          |
+---------------------------------+
| - acervo: List<Livro>           |
+---------------------------------+
| + adicionar(Livro livro): void  |
| + pesquisar(Livro livro): Livro |
+---------------------------------+
```

---

## Opções do Seletor (Menu)

| Opção | Funcionalidade | Descrição |
| :---: | :--- | :--- |
| `0` | **Sair** | Finaliza a execução da aplicação. |
| `1` | **Adicionar livro** | Cadastra um novo livro informando ISBN, Título, Autor e Editora. |
| `2` | **Pesquisar livro (sintético)** | Exibe os dados do livro, total de exemplares, disponíveis, emprestados e percentual de disponibilidade. |
| `3` | **Pesquisar livro (analítico)** | Exibe o resumo sintético e detalha todos os exemplares e históricos de empréstimos (com datas de empréstimo e devolução). |
| `4` | **Adicionar exemplar** | Adiciona um exemplar (através do número de tombo) a um livro existente. |
| `5` | **Registrar empréstimo** | Empresta o primeiro exemplar disponível do livro selecionado. |
| `6` | **Registrar devolução** | Devolve um exemplar específico informando seu tombo. |

---

## Tecnologias Utilizadas

- **Linguagem:** C# (.NET 6.0 ou superior)
- **Tipo de Projeto:** Console Application
- **Estruturas de Dados:** `System.Collections.Generic.List<T>`
- **Consultas e Agregações:** LINQ (`System.Linq`)

---

## Como Executar

### Opção 1: Execução via Terminal (Local)

1. Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado em sua máquina.
2. Clone ou navegue até a pasta raiz do projeto.
3. Entre na pasta da aplicação e execute os comandos:

```bash
dotnet build
dotnet run
```

---

### Opção 2: Execução via GitHub Codespaces

1. Abra o repositório no **GitHub**.
2. Clique no botão verde **Code** > aba **Codespaces** > **Create codespace on main**.
3. Quando o ambiente carregar, abra o terminal integrado (`Ctrl + '`).
4. Crie e acesse a pasta do projeto:

```bash
dotnet new console -n ProjetoBiblioteca
cd ProjetoBiblioteca
```

5. Adicione as classes C# no projeto e execute o comando:

```bash
dotnet run
```

---

## Estrutura de Arquivos Recomendada

```text
ProjetoBiblioteca/
├── Emprestimo.cs
├── Exemplar.cs
├── Livro.cs
├── Livros.cs
├── Program.cs
└── README.md
```