using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Dominio.Validador
{
    public class ValidadorExcecaoDominio : Exception
    {
        public ValidadorExcecaoDominio(string error) : base(error)
        { }
         
        public static void Onde(bool hasError, string error)
        {
            if (hasError) throw new ValidadorExcecaoDominio(error);
        }
       
    }
}
