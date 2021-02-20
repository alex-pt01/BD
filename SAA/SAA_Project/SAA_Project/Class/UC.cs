using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class UC
    {
        private int _ID_UC;
        private String _anoFormacao;
        private int _ID_Horario;
        private int _ID_Aval;

        public String anoFormacao
        {
            get { return _anoFormacao; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("email necessario");
                }
                _anoFormacao = value;
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

        public int ID_Horario
        {
            get { return _ID_Horario; }
            set
            {

                _ID_Horario = value;
            }
        }

        public int ID_Aval
        {
            get { return _ID_Aval; }
            set
            {

                _ID_Aval = value;
            }
        }

        public override String ToString()
        {

            char[] separator = { ' ' };
            _anoFormacao = _anoFormacao.Split(separator)[0];
            String s = String.Format("  {0,-15}       {1,-20}    {2,-16}    {3,-20}   ", _ID_UC, _anoFormacao, _ID_Horario, _ID_Aval);
            return s;
        }

    }
}
