namespace JogoDeAdicinhacaoConsoleApp
{
    internal class Program
    {

        //Versão 3: Verificar se o jogador acertou
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Jogo de Adivinhação");
            Console.WriteLine("----------------------");

            //logica do jogo
            Random geradorDeNumeros = new Random();

            int numeroSecreto = geradorDeNumeros.Next(1,21);



            Console.Write("Digite um numero (de 1 a 20) para chutar:");
            int numeroDigitado = Convert.ToInt32(Console.ReadLine());

            if (numeroDigitado == numeroSecreto)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Parabéns, você acertou!");
                Console.WriteLine("----------------------");
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


            Console.ReadLine();
        }
    }
}
