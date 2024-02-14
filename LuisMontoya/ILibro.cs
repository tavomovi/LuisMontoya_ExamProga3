using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisMontoya
{
    internal interface ILibro
    {
        public void Prestar();
        public void Devolver();
        public void Consultar();
    }
}
