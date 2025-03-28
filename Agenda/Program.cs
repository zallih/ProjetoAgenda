using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda{
    class Program {

        static int ExibirMenu() {
            int op = 0;
            Console.Clear();
            Console.WriteLine("Agenda Console...");
            Console.WriteLine("1 - Exibir Dados");
            Console.WriteLine("2 - Adicionar contato");
            Console.WriteLine("3 - Alterar contato");
            Console.WriteLine("4 - Localizar contato");
            Console.WriteLine("5 - Excluir contato");
            Console.WriteLine("6 - Sair");
            Console.Write("Escolha uma opção: ");
            op = Convert.ToInt32(Console.ReadLine());
            return op;
        }

        static void ExibirContatos(String[] nome, String[] email, int tl) {
            Console.WriteLine("Exibir Contatos...");
            for (int i = 0; i < tl; i++) {
                Console.WriteLine("Nome: {0} | Email: {1} ", nome[i], email[i]);
                Console.WriteLine("-------------------------------");
            }
            Console.ReadKey();
        }

        static void IserirContato(ref String[] nome, ref String[] email, ref int tl) {
            try {
                Console.Clear();
                Console.WriteLine("Inserir Contato...");
                Console.Write("Nome: ");
                nome[tl] = Console.ReadLine();
                Console.Write("Email: ");
                email[tl] = Console.ReadLine();
                int pos = LocalizarContato(nome, tl, nome[tl]);
                if (pos != -1) {
                    tl++;
                } else {
                    Console.WriteLine("Contato já cadastrado...");
                    Console.ReadKey();
                }
            } catch (Exception e) {
                Console.WriteLine("Erro: " + e.Message);
                Console.ReadKey();
            }
        }

        static void AlterarContato(ref String[] nome, ref String[] email, ref int tl) {
            try {
                Console.Write("Email: ");
                String emailContato = Console.ReadLine();
                int pos = LocalizarContato(email, tl, emailContato);
                if (pos != -1) {
                    Console.WriteLine("Alterar Nome...");
                    Console.Write("Nome: ");
                    String novoNome = Console.ReadLine();
                    

                    Console.WriteLine("Alterar Email...");
                    Console.Write("Nome: ");
                    String novoEmail = Console.ReadLine();
                    

                    if(LocalizarContato(email, tl, novoEmail) == -1) {
                        nome[pos] = novoNome;
                        email[pos] = novoEmail;
                        Console.WriteLine("Contato alterado com sucesso...");
                        Console.ReadKey();
                    } else {
                        Console.WriteLine("Contato já cadastrado...");
                        Console.ReadKey();
                    }
                } else {
                    Console.WriteLine("Contato não encontrado...");
                    Console.ReadKey();
                }
                
                
            } catch (Exception e) {
                Console.WriteLine("Erro: " + e.Message);
                Console.ReadKey();
            }
        }


        static int LocalizarContato(String[] nome, int tl, String nomeContato) { 
            int pos = -1;
            int i = 0;
            while (i < tl && nome[i] != nomeContato) {
                i++;
            }

            if (nome[i] == nomeContato) {
                pos = i;
            }

            return pos;
        }


        static void ExcluirContato(ref String[] nome, ref String[] email, ref int tl, String emailContato) {
            int pos = -1;
            pos = LocalizarContato(email, tl, emailContato);
            if (pos != -1) {
                for (int i = pos; i < tl-1; i++) {
                    nome[i] = nome[i + 1];
                    email[i] = email[i + 1];
                }
                tl--;
                Console.WriteLine("Contato excluído com sucesso...");
                Console.ReadKey();
            } else {
                Console.WriteLine("Contato não encontrado...");
                Console.ReadKey();
            }
        }

            static void Main(string[] args){
            String[] nome = new string[200];
            String[] email = new string[200];

            int tl = 0;
            int op = 0;

            String nomeContato = "";   

            BackupAgenda.nomeArquivo = "agenda.txt";    
            BackupAgenda.RecuperarDados(ref nome, ref email, ref tl);

            Console.WriteLine("Agenda Console...");

            while(op != 6) {
                op = ExibirMenu();
                switch (op) {
                    case 1: //Exibir Dados
                        ExibirContatos(nome, email, tl);
                        break;

                    case 2: //Adicionar contato
                        IserirContato(ref nome, ref email, ref tl);
                        break;

                    case 3: //Alterar contato
                        AlterarContato(ref nome, ref email, ref tl);

                        break;

                    case 4: //Localizar contato
                        Console.WriteLine("Localizar contato...");
                        Console.Write("Digite o nome do contato: ");
                        nomeContato = Console.ReadLine();
                        int pos = LocalizarContato(nome, tl, nomeContato);
                        if (pos != -1) {
                           Console.WriteLine("Nome: {0} | Email: {1} ", nome[pos], email[pos]);
                           Console.ReadKey();
                        } else {
                            Console.WriteLine("Contato não encontrado...");
                        }
                            break;

                    case 5: //Excluir contato
                        Console.WriteLine("Excluir contato...");
                        Console.Write("Digite o email do contato: ");
                        String emailContato = Console.ReadLine();
                        if (emailContato != "") {
                            ExcluirContato(ref nome, ref email, ref tl, emailContato);
                        } else {
                            Console.WriteLine("Email inválido...");
                            Console.ReadKey();
                        }
                        break;

                }
            }
            BackupAgenda.SalvarDados(nome, email, tl);
        }
    }
}
