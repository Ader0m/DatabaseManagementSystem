using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDataBase
{
    public class MyException : Exception
    {
        String exeption;

        public MyException(String str)
        {
            exeption = str;
        }
    }
}
