using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string msg) : base(msg)
        {
            //Ele simplesmente passa a mensagem para a classe Exception do C#.
        }
    }
}
