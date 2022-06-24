using System;
using System.IO;

namespace Edit
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("Bonjour, o que vossa senhoria deseja fazer? ");
            Console.WriteLine("1 -Criar um novo arquivo");
            Console.WriteLine("2 - Abrir um arquivo existente");
            Console.WriteLine("3 - Sair da aplicação");
            Console.WriteLine("**********************************************");

            short opcoesMenu = short.Parse(Console.ReadLine());

            switch (opcoesMenu)
            {
                case 1: Criar(); break;
                case 2: Abrir(); break;
                case 3: System.Environment.Exit(0); break;
            }
        }

        static void Criar()
        {
            Console.Clear();
            Console.WriteLine("Redija seu texto logo abaixo ");
            Console.WriteLine("Precione ESC para sair");
            Console.WriteLine("******************************");
            string texto = "";


            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(texto);

        }

        static void Salvar(string texto)
        {
            Console.Clear();
            Console.WriteLine("Onde vossa senhoria deseja salvar o arquivo? ");
            var pacote = Console.ReadLine();

            using (var arquivo = new StreamWriter(pacote))
            {
                arquivo.Write(texto);
            }

            Console.WriteLine("O arquivo foi salvo com sucesso, meu mestre ");
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo desejado? ");
            string pacote = Console.ReadLine();

            using (var arquivo = new StreamReader(pacote))
            {
                string texto = arquivo.ReadToEnd();
                Console.WriteLine(texto);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();

        }
    }
}
