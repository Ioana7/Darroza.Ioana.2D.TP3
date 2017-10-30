using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno:Universitario
    {
        public enum EEstadoCuenta {Prueba, Deudor, AlDia,Becado}

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;


        public Alumno(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(legajo, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }


        public Alumno(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(legajo, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }


        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());

            switch (this._estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.AppendLine("ESTADO DE CUENTA: CUOTA AL DIA");
                    break;
                case EEstadoCuenta.Deudor:
                    sb.AppendLine("ESTADO DE CUENTA: CUOTA CON DEUDA");
                    break;
                case EEstadoCuenta.Becado:
                    sb.AppendLine("ESTADO DE CUENTA: BECADO");
                    break;
                default:
                    sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
                    break;
            }
            sb.AppendLine("TOMA CLASES DE: " + this._claseQueToma.ToString());

            return sb.ToString();
        }


        public override string ToString()
        {
            return this.MostrarDatos();
        }


        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (Universidad.EClases)a._claseQueToma != (Universidad.EClases)clase;

        }


        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if ((Universidad.EClases)clase == (Universidad.EClases)a._claseQueToma && EEstadoCuenta.Deudor != (EEstadoCuenta)a._estadoCuenta && a != null)
            {
                return true;
            }

            return false;
        }


        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma.ToString();
        }


    }
}
