using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class Horario
    {
        private String _ID_Horario;

        public String ID_Horario
        {
            get { return _ID_Horario; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("ID Horario necessário");
                }
                _ID_Horario = value;
            }
        }
        public override String ToString()
        {
            return _ID_Horario;
        }
    }
}
