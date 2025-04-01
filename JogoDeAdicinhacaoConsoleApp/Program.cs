using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace JogoDeAdicinhacaoConsoleApp
{
    internal class Program
    {

        //Versão 4: Criar múltiplas tentativas
        static void Main(string[] args)
        {



            while (true)


            {
                string[] chutesPassados = new string[10];
                int contadorChutes = 0;
                int pontosTotais = 1000;

                string escolhaDeDificuldade = ChamarMenu();
                int totalDeTentativas = DificuldadeEscolhida(escolhaDeDificuldade);
                int numeroSecreto = GeradorNumeroAleatorio();


                //logica do jogo
                for (int tentativa = 1; tentativa <= totalDeTentativas; tentativa++)
                {
                    

                    Console.Clear();
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"Tentativa {tentativa} de {totalDeTentativas}.");
                    Console.Write("Digite um numero (de 1 a 20) para chutar:");
                    int numeroDigitado = Convert.ToInt32(Console.ReadLine());

                    ValidaSeNumeroJaDigitado(totalDeTentativas, chutesPassados, numeroDigitado, contadorChutes);
                    if (ValidaSeNumeroEhVencedor(numeroDigitado, numeroSecreto, totalDeTentativas, chutesPassados,ref pontosTotais))
                        break;
                    if (ValidaSeEsgotouTentativas(tentativa, totalDeTentativas, chutesPassados,ref pontosTotais, numeroSecreto))
                        break;
                    ValidaSeNumeroEhMaior(numeroDigitado, numeroSecreto, totalDeTentativas, chutesPassados, ref pontosTotais);
                    ValidaSenumeroEhMenor(numeroDigitado, numeroSecreto, totalDeTentativas, chutesPassados, ref pontosTotais);
                    contadorChutes++;
                    Console.ReadLine();

                }

            }

        }

        static string ChamarMenu()
        {
            Console.Clear();
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
            return escolhaDeDificuldade;
        }

        static int DificuldadeEscolhida(string escolhaDeDificuldade)
        {
            int totalDeTentativas;
            if (escolhaDeDificuldade == "1")
                totalDeTentativas = 10;
            else if (escolhaDeDificuldade == "2")
                totalDeTentativas = 5;
            else
                totalDeTentativas = 3;
            return totalDeTentativas;
        }

        static int GeradorNumeroAleatorio()
        {
            Random geradorDeNumeros = new Random();
            int numeroSecreto = geradorDeNumeros.Next(1, 21);
            return numeroSecreto;
        }

        static int ValidaSeNumeroJaDigitado(int totalDeTentativas, string[] chutesPassados, int numeroDigitado, int contadorChutes)
        {
            for (int i = 0; i < totalDeTentativas; i++)
            {
                if (chutesPassados[i] == null)
                    break;

                else if (numeroDigitado == Convert.ToInt32(chutesPassados[i]))
                {
                    while (numeroDigitado == Convert.ToInt32(chutesPassados[i]))
                    {
                        Console.WriteLine("Numero já digitado.");
                        Console.Write("Digite novamente um número:");
                        numeroDigitado = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
            chutesPassados[contadorChutes] = Convert.ToString(numeroDigitado);
            return numeroDigitado;
        }

        static bool ValidaSeNumeroEhVencedor(int numeroDigitado, int numeroSecreto, int totalDeTentativas, string[] chutesPassados, ref int pontosTotais)
        {
            if (numeroDigitado == numeroSecreto)
            {

                for (int i = 0; i < totalDeTentativas; i++)
                {
                    if (chutesPassados[i] != null)
                        Console.WriteLine("Numeros já digitados:" + chutesPassados[i]);
                }
                
                Console.WriteLine("----------------------");
                Console.WriteLine("Parabéns, você acertou!");
                Console.WriteLine("----------------------");
                Console.WriteLine("Sua pontuação final é: " + Math.Abs(pontosTotais));
                Console.ReadLine();
                return true;
            }
            return false;
        }

        static bool ValidaSeEsgotouTentativas(int tentativa, int totalDeTentativas, string[] chutesPassados, ref int pontosTotais, int numeroSecreto) 
        {
            if (tentativa == totalDeTentativas)
            {


                for (int i = 0; i < totalDeTentativas; i++)
                {
                    if (chutesPassados[i] != null)
                        Console.WriteLine("Numeros já digitados:" + chutesPassados[i]);
                }

                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Que pena! Você usou todas as tentativas. O número era {numeroSecreto}.");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Sua pontuação final é: " + Math.Abs(pontosTotais));
                Console.ReadLine();
                return true;
            }
            return false;
        }

        static bool ValidaSeNumeroEhMaior(int numeroDigitado, int numeroSecreto, int totalDeTentativas, string[] chutesPassados, ref int pontosTotais)
        {
             if (numeroDigitado > numeroSecreto)
            {
                for (int i = 0; i < totalDeTentativas; i++)
                {
                    if (chutesPassados[i] != null)
                        Console.WriteLine("Numeros já digitados:" + chutesPassados[i]);
                }
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("O número digitado é maior que o numero secreto, tente novamente.");
                Console.WriteLine("----------------------------------------------------------------");
                int pontos = numeroDigitado - numeroSecreto / 2;
                pontosTotais = pontosTotais - Math.Abs(pontos);
                Console.WriteLine("Sua pontuação é: " + Math.Abs(pontosTotais));
            }
            
            return true;
        }

        static bool ValidaSenumeroEhMenor(int numeroDigitado, int numeroSecreto, int totalDeTentativas, string[] chutesPassados, ref int pontosTotais)
        {  
            if (numeroDigitado < numeroSecreto)
            {
                for (int i = 0; i < totalDeTentativas; i++)
                {
                    if (chutesPassados[i] != null)
                        Console.WriteLine("Numeros já digitados:" + chutesPassados[i]);
                }
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("O número digitado é menor que o numero secreto, tente novamente.");
                Console.WriteLine("----------------------------------------------------------------");
                int pontos = numeroDigitado - numeroSecreto / 2;
                pontosTotais = pontosTotais - Math.Abs(pontos);
                Console.WriteLine("Sua pontuação é: " + Math.Abs(pontosTotais));
            }
            return true;
        }

    }
}
