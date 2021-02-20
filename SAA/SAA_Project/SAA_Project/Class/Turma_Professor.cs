using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class Turma_Professor
    {
        private String _Nome_Prof;
        private int _ID_Turma;
        private String _Email;
        private int _TMEC;


        public String Nome_Prof
        {
            get { return _Nome_Prof; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Nome necessário!");
                }
                _Nome_Prof = value;
            }
        }

        public int ID_Turma
        {
            get { return _ID_Turma; }
            set
            {

                _ID_Turma = value;
            }
        }
        public String Email
        {
            get { return _Email; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Email necessário");
                }
                _Email = value;
            }
        }
        public int TMEC
        {
            get { return _TMEC; }
            set
            {
                _TMEC = value;
            }
        }

        public override String ToString()
        {
            String s = String.Format("Nmec:  {0,-15}  {1,-10} {2,-10} {3,-10}", _Nome_Prof, _TMEC, _Email, _ID_Turma);
            return s;
        }


    }
}
