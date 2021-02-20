using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class Curso
    {
        private int _idCurso;
        private int _idDep;

        private String _nome_Curso;


        public String nome_Curso
        {
            get { return _nome_Curso; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("nome necessario");
                }
                _nome_Curso = value;
            }
        }

        public int idCurso
        {
            get { return _idCurso; }
            set
            {

                _idCurso = value;
            }
        }

        public int idDep
        {
            get { return _idDep; }
            set
            {

                _idDep = value;
            }
        }

        public override String ToString()
        {

            String s = String.Format("  {0,-25}  {1,-30}  {2,-10}  ", _idCurso, _nome_Curso, _idDep);
            return s;
        }
    }
}