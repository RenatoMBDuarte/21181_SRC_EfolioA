//NOME: Renato Manuel Bogalho Duarte
//N.º DE ESTUDANTE: 800873
//CURSO: Licenciatura Engenharia de Informática
//DATA DE ENTREGA: 22-11-2021


using System;
using System.Numerics;


namespace EfolioA_SR
{
    class Program
    {
        static void Main(string[] args)
        {

            string frase;
            char[] dados;
            char[] encriptado;

            #region Variaveis
            //Dois numeros primos (Por simplicidade são mesmo disponibilizados pelo manual)
            double p = 11;
            double q = 17;

            //Tamanho finito do conjunto
            double n = p * q;

            //Calcular a função totiente
            double phi = (p - 1) * (q - 1);
            #endregion

            #region Chave_publica 
            //Inicia chave publica de encriptação maior que 1
            double e = 7;

            //Atualização de "e" para que seja co-primo de "phi"
            while (e < phi)
            {
                if (Gcd(e, phi) == 1)
                {
                    break;
                }
                else
                {
                    e++;
                }
            }
            #endregion

            #region Chave_Privada
            //Modulo inverso entre 'e' e phi
            double d = ModInverso((int)e, (int)phi);

            #endregion
            do
            {
                Console.WriteLine("\nQual a frase para encriptar?");
                frase = Console.ReadLine();

            } while (frase.Length == 0);

            dados = frase.ToCharArray();
            encriptado = new char[frase.Length];


            //Encripta caracter a caracter
            for (int i = 0; i < dados.Length; i++)
            {
                encriptado[i] = Converte(dados[i], (int)e, (int)n);
            }

            //Informações apenas para o Efolio
            Console.WriteLine("\nChave publica utilizada: " + e);
            Console.WriteLine("\nChave privada utilizada: " + d);

            //Apresenta texto encriptado ao utilizador
            Console.WriteLine("\nTexto encriptado:");
            foreach (char item in encriptado)
            {
                Console.Write((char)item);
            }

            //Desencripta com chave privada apenas para prova do conceito
            Console.WriteLine("\n\nTexto original:");
            foreach (char item in encriptado)
            {
                Console.Write((char)Converte(item, (int)d, (int)n));
            }


            char Converte(char letra, int eChave, int nTamanho)
            {
                BigInteger valor = BigInteger.Pow(letra, eChave) % nTamanho;
                return (char)valor;
            }


            #region Auxiliares
            //Máximo Divisor Comum
            double Gcd(double a, double h)
            {
                double temp;
                while (true)
                {
                    temp = a % h;
                    if (temp == 0)
                        return h;
                    a = h;
                    h = temp;
                }
            }

            // Modulo Inverso
            int ModInverso(int a, int m)
            {

                for (int x = 1; x < m; x++)
                    if (((a % m) * (x % m)) % m == 1)
                        return x;
                return 1;
            }
            #endregion

            Console.WriteLine("\n\nQualquer tecla para sair.");
            Console.ReadKey();
        }

    }
}
