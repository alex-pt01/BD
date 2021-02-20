using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class uc_Curso
    {
        private String _anoForm;
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

        public String anoForm
        {
            get { return _anoForm; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("nome necessario");
                }
                _anoForm = value;
            }
        }


        public int idUC
        {
            get { return _idUC; }
            set
            {

                _idUC = value;
            }
        }

        public override String ToString()
        {

            String s = String.Format("  {0,-10}     {1,-20}  {2,-20}  ", _idUC, _nomeCurso, _anoForm);
            return s;
        }
    }
}
