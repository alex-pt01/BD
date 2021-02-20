using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class anoUC
    {
        private int _ano;
        private int _idUC;
        private String _nomeCurso;


        public String nomeCurso
        {
            get { return _nomeCurso; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("nome necessario");
                }
                _nomeCurso = value;
            }
        }

        public int idCurso
        {
            get { return _idUC; }
            set
            {

                _idUC = value;
            }
        }



        public int ano
        {
            get { return _ano; }
            set
            {

                _ano = value;
            }
        }

        public override String ToString()
        {

            String s = String.Format("        {0,-10}                 {1,-20}                   {2,-10}  ", _ano, _idUC, _nomeCurso);
            return s;
        }



    }
}
