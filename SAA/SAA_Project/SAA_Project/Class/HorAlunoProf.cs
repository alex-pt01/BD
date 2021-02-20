using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class HorAlunoProf
    {
        //aluno
        private String _Nome;
        private String _NMEC;
        private String _Email;
        private String _ID_Horario;
        private String _RegimeEstudo;
        private String _ID_Biblioteca;
        private String _ID_Curso;
        private String _NMEC_Tutor;
        private String _Idade;

        //prof
        private String _NomeProf;
        private String _TNMEC;
        private String _EmailProf;
        private int _numGabinete;
        private int _ID_Dep;


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
        public String ID_Horario
        {
            get { return _ID_Horario; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Nome necessário!");
                }
                _ID_Horario = value;
            }
        }

        public String NomeProf
        {
            get { return _NomeProf; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Nome Profesosr necessário!");
                }
                _NomeProf = value;
            }
        }

        public String NMEC
        {
            get { return _NMEC; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("NMEC necessario!");
                }
                _NMEC = value;
            }
        }

        public String RegimeEstudo
        {
            get { return _RegimeEstudo; }
            set { _RegimeEstudo = value; }
        }

        public String ID_Biblioteca
        {
            get { return _ID_Biblioteca; }
            set { _ID_Biblioteca = value; }
        }

        public String ID_Curso
        {
            get { return _ID_Curso; }
            set { _ID_Curso = value; }
        }

        public String NMEC_Tutor
        {
            get { return _NMEC_Tutor; }
            set { _NMEC_Tutor = value; }
        }

        public String Idade
        {
            get { return _Idade; }
            set { _Idade = value; }
        }

        public String TNMEC
        {
            get { return _TNMEC; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("TNMEC necessario!");
                }
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
        public String EmailProf
        {
            get { return _EmailProf; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Email do professor necessário");
                }
                _EmailProf = value;
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

        public override String ToString()
        {
            String s = String.Format("{0,-15}  {1,-10}", _NMEC, Nome);
            return s;
        }

    }
}
