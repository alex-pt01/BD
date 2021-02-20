using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class ucFaltas
    {

        private String _tipoFalta;
        private int _ID_UC;
        private String _Nome;
        private int _nmec;
        private String _email;


        public int NMEC
        {
            get { return _nmec; }
            set
            {

                _nmec = value;
            }
        }

        public int ID_UC
        {
            get { return _ID_UC; }
            set
            {

                _ID_UC = value;
            }
        }

        public String  Email
        {
            get { return _email; }
            set
            {

                _email = value;
            }
        }
      

        public String tipo_Falta
        {
            get { return _tipoFalta; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("tipo Falta necessario");
                }
                _tipoFalta = value;
            }
        }

        public String nomeAluno
        {
            get { return _Nome; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("nome aluno necessario");
                }
                _Nome = value;
            }
        }


        public override String ToString()
        {
            String details = "  {0,-12} {1,-20} {2,-25} {3,-25} {4,-25}  ";
            String s = String.Format(details, _ID_UC, _tipoFalta, _nmec, _Nome,  _email);
            return s;
        }

    }
}
