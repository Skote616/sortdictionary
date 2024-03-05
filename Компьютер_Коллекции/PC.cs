using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Компьютер_Коллекции
{
    class PC
    {
        private string surname;
        private string kard;
        private string proc;
        private int oper;

        public PC(string surname, string kard, string proc, int oper)
        {
            this.surname = surname;
            this.kard = kard;
            this.proc = proc;
            this.oper = oper;
        }

        public string Get_surname()
        {
            return surname;
        }

        public string Get_kard()
        {
            return kard;
        }

        public string Get_proc()
        {
            return proc;
        }

        public int Get_oper()
        {
            return oper;
        }
    }
}
