using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class anosTurma
    {
        private int _ID_turma;
        private int _NNMEC;
        private int _idade;

        private int _anoLect;

        private String _nome;
        private String _resEstudo;
        private String _Email;

        public String nome
        {
            get { return _nome; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("nome necessario");
                }
                _nome = value;
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
        public String resEstudo
        {
            get { return _resEstudo; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("email necessario");
                }
                _resEstudo = value;
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

        public int anoLect
        {
            get { return _anoLect; }
            set
            {

                _anoLect = value;
            }
        }

        public int NNMEC
        {
            get { return _NNMEC; }
            set
            {

                _NNMEC = value;
            }
        }

        public int idade
        {
            get { return _idade; }
            set
            {

                _idade = value;
            }
        }





        public override String ToString()
        {

            String s = String.Format("  {0,-15}  {1,-10}  {2,-15}  {3,-18}  {4,-25}  {5,-15}  {6,-10}  ", _ID_turma, _NNMEC, _nome, _Email, _resEstudo, _idade, _anoLect);
            return s;
        }
    }
}

