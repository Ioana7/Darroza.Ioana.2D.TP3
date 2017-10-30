using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
        private int _legajo;


        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }


        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.Append("LEGAJO: " + this._legajo.ToString());

            return sb.ToString();
        }


        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

            if (!object.Equals(pg1, null) && !object.Equals(pg2, null))
            {
                if (pg1.Equals(pg2) && pg1.DNI == pg2.DNI || pg1._legajo == pg2._legajo)
                    return true;
            }
            return false;
        }


        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }


        protected abstract string ParticiparEnClase();

        public Universitario() : base() { }

    }
}
