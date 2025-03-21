namespace JogoDeAdicinhacaoConsoleApp
{
    internal class Program
    {

        //Versão 4: Criar múltiplas tentativas
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Jogo de Adivinhação");
                Console.WriteLine("----------------------");

                //escolha de dificuldade
                Console.WriteLine("Escolha um nível de dificuldade");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1 - Facil (10 tentativas)");
                Console.WriteLine("2 - Normal(5 tentativas)");
                Console.WriteLine("3 - Dificil (3 tentativas)");
                Console.WriteLine("-------------------------------");

                Console.Write("Digita sua escolha: ");
                string escolhaDeDificuldade = Console.ReadLine();

                int totalDeTentativas = 0;

                if (escolhaDeDificuldade == "1")
                    totalDeTentativas = 10;
                else if (escolhaDeDificuldade == "2")
                    totalDeTentativas = 5;
                else
                    totalDeTentativas = 3;

                //escolha numero aleatorio
                Random geradorDeNumeros = new Random();

                int numeroSecreto = geradorDeNumeros.Next(1, 21);


                //logica do jogo
                for (int tentativa = 1; tentativa <= totalDeTentativas; tentativa++)
                {
                    Console.Clear();
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"Tentativa {tentativa} de {totalDeTentativas}.");
                    Console.Write("Digite um numero (de 1 a 20) para chutar:");
                    int numeroDigitado = Convert.ToInt32(Console.ReadLine());

                    if (numeroDigitado == numeroSecreto)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine("Parabéns, você acertou!");
                        Console.WriteLine("----------------------");
                        break;
                    }
                    if (tentativa == totalDeTentativas)
                    {
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"Que pena! Você usou todas as tentativas. O número era {numeroSecreto}.");
                        Console.WriteLine("----------------------------------------");
                        break;
                    }
                    else if (numeroDigitado > numeroSecreto)
                    {
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine("O número digitado é maior que o numero secreto, tente novamente.");
                        Console.WriteLine("----------------------------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine("O número digitado é menor que o numero secreto, tente novamente.");
                        Console.WriteLine("----------------------------------------------------------------");
                    }
                    
                    
                    Console.Write("Deseja continuar? (S/N): ");
                    string opcaoContinuar = Console.ReadLine().ToUpper();

                    if (opcaoContinuar != "S")
                    break;

                    Console.ReadLine();
                }
            }
        }
    }
}
