using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda{
    class Program{

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
        static void Main(string[] args){
            String[] nome = new string[200];
            String[] email = new string[200];

            int tl = 0;
            int op = 0;

            Console.WriteLine("Agenda Console...");

            while(op != 6) {
                op = ExibirMenu();
                switch (op) {
                    case 1: //Exibir Dados

                        break;

                    case 2: //Adicionar contato
                        break;

                    case 3: //Alterar contato
                        break;

                    case 4: //Localizar contato
                        break;

                    case 5: //Excluir contato
                        break;

                }
            }
        }
    }
}
