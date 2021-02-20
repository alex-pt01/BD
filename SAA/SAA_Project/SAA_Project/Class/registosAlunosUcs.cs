using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class registosAlunosUcs
    {
        private int _NMEC;
        private int _ID_UC;
        private int _ID_Curso;
        private int _ID_Reg;

        private String _Email;
        private String _RegismeEst;
        private String _NomeAlu;


        public int ID_UC
        {
            get { return _ID_UC; }
            set
            {

                _ID_UC = value;
            }
        }


        public int ID_Curso
        {
            get { return _ID_Curso; }
            set
            {

                _ID_Curso = value;
            }
        }


        public int ID_Reg
        {
            get { return _ID_Reg; }
            set
            {

                _ID_Reg = value;
            }
        }

        public String Email
        {
            get { return _Email; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("nome necessario");
                }
                _Email = value;
            }
        }

        public String RegismeEst
        {
            get { return _RegismeEst; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("email necessario");
                }
                _RegismeEst = value;
            }
        }

        public String NomeAlu
        {
            get { return _NomeAlu; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("email necessario");
                }
                _NomeAlu = value;
            }
        }

        public int NMEC
        {
            get { return _NMEC; }
            set
            {

                _NMEC = value;
            }
        }


        public override String ToString()
        {

            String s = String.Format("  {0,-10}    {1,-25}   {2,-25}  {3,-16}   {4,-14} {5,-14} {6,-14}  ", _NMEC, _NomeAlu, _Email, _RegismeEst, _ID_UC, _ID_Curso, _ID_Reg);
            return s;
        }
    }
}
