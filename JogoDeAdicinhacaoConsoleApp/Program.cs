namespace JogoDeAdicinhacaoConsoleApp
{
    internal class Program
    {

        //Versão 2: Gerar um número secreto aleatório 
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

            Console.WriteLine("O numero digitado foi:" + numeroDigitado);
            Console.WriteLine("O numero secreto é:" + numeroSecreto);

            Console.ReadLine();
        }
    }
}
