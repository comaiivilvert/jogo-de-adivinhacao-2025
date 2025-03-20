namespace JogoDeAdicinhacaoConsoleApp
{
    internal class Program
    {

        //Versão 1: Estrutura básica e entrada do usuário 
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Jogo de Adivinhação");
            Console.WriteLine("----------------------");

            Console.Write("Digite um numero para chutar:");
            int numeroDigitado = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("O numero digitado foi:" + numeroDigitado);
            
            Console.ReadLine();
        }
    }
}
