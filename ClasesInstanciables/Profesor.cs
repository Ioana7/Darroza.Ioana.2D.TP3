using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    [Serializable]

    public sealed class Profesor:Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        
        static Profesor()
        {
           _random = new Random();
        }


        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>(2);
            _clasesDelDia.Enqueue((Universidad.EClases)_random.Next(1, 4));
            _clasesDelDia.Enqueue((Universidad.EClases)_random.Next(1, 4));
            
        }

        public Profesor()
        { }


        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        } 


        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }


        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases c in i._clasesDelDia)
            {
                if ((Universidad.EClases)clase == (Universidad.EClases)c)
                {
                    retorno = true;
                }
            }
            return retorno;

        }



        protected override string ParticiparEnClase()
        {
            StringBuilder strRetorno = new StringBuilder();

            strRetorno.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases clase in this._clasesDelDia)
            {
                strRetorno.AppendLine(clase.ToString());
            }
            return strRetorno.ToString();
        }


        public override string ToString()
        {
            return this.MostrarDatos();
        }

    }
}
