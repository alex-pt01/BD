using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class relAlunosTurma
    {
        private int _ID_turma;
        private int _TNMEC;
        private String _Nome;
        private String _Email;
        private String _RegEstudo;
        private int _Idade;
 
        public String nome_Prof
        {
            get { return _Nome; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("nome necessario");
                }
                _Nome = value;
            }
        }

        public String RegEstudo
        {
            get { return _RegEstudo; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("nome necessario");
                }
                _RegEstudo = value;
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

        public int Idade
        {
            get { return _Idade; }
            set
            {

                _Idade = value;
            }
        }


        public override String ToString()
        {

            String s = String.Format("  {0,-15}  {1,-10}   {2,-15}   {3,-20}   {4,-25}   {5,-10}  ", _ID_turma, _TNMEC, _Nome, _Email, _RegEstudo, _Idade);
            return s;
        }


    }
}
