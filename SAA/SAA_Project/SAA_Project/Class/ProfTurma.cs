using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class ProfTurma
    {

        private String _Nome;
        private int _TNMEC;
        private int _ID_turma;
        private String _Email;
        private int _numGabinete;
        private int _ID_Dep;
        private int _ID_Horario;

        public String Nome
        {
            get { return _Nome; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Nome necessário!");
                }
                _Nome = value;
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
        public int numGabinete
        {
            get { return _numGabinete; }
            set
            {
                _numGabinete = value;
            }
        }

        public int ID_Dep
        {
            get { return _ID_Dep; }
            set
            {

                _ID_Dep = value;
            }
        }

        public int ID_Horario
        {
            get { return _ID_Horario; }
            set
            {
                _ID_Horario = value;
            }
        }

        public  String testar()
        {
            String s = String.Format("{0,-15}  {1,-15} {2,-15} {3,-15}", _ID_turma, _TNMEC, _Nome, _Email);
            return s;

        }
        public override String ToString()
        {
            String s = String.Format("{0,-15}  {1,-15} {2,-15} {3,-15}", _ID_turma, _TNMEC, _Nome, _Email);
            return s;
        }


    }
}

