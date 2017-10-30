using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{

    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]

    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;


        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }


        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }


        public List<Alumno> Alumnos
        {
            get { return this._alumnos;}

            set { this._alumnos = value;}
        }


        public Universidad.EClases Clase
        {
            get { return this._clase;}

            set { this._clase = value;}
        }


        public Profesor Instructor
        {
            get { return this._instructor;}

            set { this._instructor = value;}
        }


        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar("Jornada.txt", jornada.ToString());
        }


        public static string Leer()
        {
            string cad = " ";
            Texto texto = new Texto();
            texto.Leer("Jornada.txt", out cad);
            return cad;
        }


        public static bool operator ==(Jornada j, Alumno a)
        {
            if (a == (Universidad.EClases)j.Clase)
            {
                return true;
            }
            return false;
        }


        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }


        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno al in j._alumnos)
            {
                    if (al == a)
                    {
                        retorno = true;
                        break;
                    }
            }
            if (!retorno)
            {
                j._alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return j;
        }


        public override string ToString()
        {

            if (!object.Equals(this, null) && !object.Equals(this.Clase, null) && !object.Equals(this.Instructor, null))
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat("CLASE DE {0} POR {1}", this.Clase.ToString(), this.Instructor.ToString());
                sb.AppendLine("ALUMNOS");

                foreach (Alumno a in this._alumnos)
                {
                    sb.AppendLine(a.ToString());
                }
                sb.AppendLine("<------------------------------------------------>");

                return sb.ToString();
            }
            else
            {
                return "";
            }

        }
    }
}
