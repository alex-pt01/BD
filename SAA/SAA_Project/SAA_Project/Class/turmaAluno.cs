using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class turmaAluno
    {
        private int _ID_turma;
        private int _TNMEC;
        private int _numGab;

        private String _nome_Prof;
        private String _Email;

        public String nome_Prof
        {
            get { return _nome_Prof; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("nome necessario");
                }
                _nome_Prof = value;
            }
        }

        public String Email
        {
            get { return _Email; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("email necessario");
                }
                _Email = value;
            }
        }





        public int ID_turma
        {
            get { return _ID_turma; }
            set
            {

                _ID_turma = value;
            }
        }

        public int TNMEC
        {
            get { return _TNMEC; }
            set
            {

                _TNMEC = value;
            }
        }

        public int numGab
        {
            get { return _numGab; }
            set
            {

                _numGab = value;
            }
        }

      



        public override String ToString()
        {

            String s = String.Format("  {0,-15}  {1,-10}  {2,-10}  {3,-10}  {4,-10}  ", _ID_turma, _TNMEC, _nome_Prof, _numGab, _Email);
            return s;
        }
    }
}
