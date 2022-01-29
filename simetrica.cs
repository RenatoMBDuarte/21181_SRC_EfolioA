//NOME: Renato Manuel Bogalho Duarte
//N.º DE ESTUDANTE: 800873
//CURSO: Licenciatura Engenharia de Informática
//DATA DE ENTREGA: 22-11-2021
using System;

namespace EfolioA_SR
{
    class Program
    {

        static void Main(string[] args)
        {
            string frase, chave = "4312567";
            string[,] dados;
            double tam_Frase, tam_chave = chave.Length;
            int linhas, count = 0, count2 = 0;

            do
            {
                Console.WriteLine("Qual a frase para encriptar?");
                frase = Console.ReadLine();

            } while (frase.Length == 0);


            //Guarda o tamanho da frase que tem de tratar
            tam_Frase = frase.Length;

            //define o numero de linha da tabela, arredonda para cima
            linhas = (int)Math.Ceiling(tam_Frase / tam_chave);

            //define o tamanho do array
            dados = new string[linhas, (int)tam_chave];


            do
            {
                //Faz a gravação no array linha/coluna
                for (int linha = 0; linha < linhas; linha++)
                {
                    for (int coluna = 0; coluna < tam_chave; coluna++)
                    {
                        if (count < tam_Frase)
                        {
                            dados[linha, coluna] = frase.Substring(count, 1);
                        }
                        else
                        {
                            dados[linha, coluna] = "x";
                        }
                        count++;
                    }
                }
            } while (count < tam_Frase);



            Console.Write("\nFrase encriptada:\n");
            do
            {
                //Precorre o array coluna/linha (A posição da coluna está definida na chave)
                for (int coluna = 0; coluna < tam_chave; coluna++)
                {
                    for (int linha = 0; linha < linhas; linha++)
                    {
                        if (count2 < tam_Frase)
                        {
                            //Identifica em que coluna vai ler
                            int posicao_coluna = chave.IndexOf((coluna + 1).ToString());

                            Console.Write(dados[linha, posicao_coluna].ToUpper());
                            count2++;
                        }
                    }
                }
            } while (count2 < tam_Frase);

            Console.Write("\n\nFrase encriptada com sucesso.\n");

            Console.WriteLine("\n\nQualquer tecla para sair.");
            Console.ReadKey();
        }
    }
}

