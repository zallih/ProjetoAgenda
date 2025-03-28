using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda{
    class BackupAgenda{
        static public string nomeArquivo = "";
        public static void SalvarDados(String[] nome, String[] email, int tl) {
            try {
                Console.WriteLine("Salvar Dados...");
                System.IO.StreamWriter arquivo = new System.IO.StreamWriter(nomeArquivo);
                for (int i = 0; i < tl; i++) {
                    arquivo.WriteLine(nome[i] + ";" + email[i]);
                }
                arquivo.Close();
                Console.WriteLine("Dados salvos com sucesso...");
                Console.ReadKey();
            } catch (Exception e) {
                Console.WriteLine("Erro: " + e.Message);
                Console.ReadKey();
            }
        }
    

    public static void RecuperarDados(ref String[] nome, ref String[] email, ref int tl) {
            try {
                Console.WriteLine("Recuperar Dados...");
                if (System.IO.File.Exists("agenda.txt")) {
                    System.IO.StreamReader arquivo = new System.IO.StreamReader("agenda.txt");
                    String linha = arquivo.ReadLine();
                    while (linha != null) {
                        String[] dados = linha.Split(';');
                        nome[tl] = dados[0];
                        email[tl] = dados[1];
                        tl++;
                        linha = arquivo.ReadLine();
                    }
                    arquivo.Close();
                    Console.WriteLine("Dados recuperados com sucesso...");
                    Console.ReadKey();
                } else {
                    Console.WriteLine("Arquivo não encontrado...");
                    Console.ReadKey();
                }
            } catch (Exception e) {
                Console.WriteLine("Erro: " + e.Message);
                Console.ReadKey();
            }
        }
    }
}
