using System;
using Tabuleiro;
using Xadrez;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PosicaoXadrez posicao = new PosicaoXadrez('c', 7);
                Console.WriteLine(posicao);

                Console.WriteLine(posicao.ToPosicao());


            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
