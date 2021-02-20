using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class tipoSala
    {
        private int _ID_Sala;
        private int _limiAlunos;
        private int _ID_Turma;
        private int _AnoLectivo;

        private int _idDep;
        private String _tipoSala;

        public String TipoSala
        {
            get { return _tipoSala; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("email necessario");
                }
                _tipoSala = value;
            }
        }
        public int ID_Dep
        {
            get { return _idDep; }
            set
            {

                _idDep = value;
            }
        }
        public int ID_Sala
        {
            get { return _ID_Sala; }
            set
            {

                _ID_Sala = value;
            }
        }

        public int limiAlunos
        {
            get { return _limiAlunos; }
            set
            {

                _limiAlunos = value;
            }
        }

        public int ID_Turma
        {
            get { return _ID_Turma; }
            set
            {

                _ID_Turma = value;
            }
        }

        public int AnoLectivo
        {
            get { return _AnoLectivo; }
            set
            {

                _AnoLectivo = value;
            }
        }




        public override String ToString()
        {

            String s = String.Format("  {0,-15}  {1,-20}    {2,-23} {3,-15}  {4,-18}          {5,-10}  ", _ID_Sala, _AnoLectivo, _ID_Turma, _tipoSala, _limiAlunos, _idDep);
            return s;
        }


    }
}

