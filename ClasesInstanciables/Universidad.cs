using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{

    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Profesor))]

    public class Universidad
    {
        public enum EClases {Laboratorio, Legislacion,Programacion,SPD}

        private List<Alumno> _alumnos;
        private List<Jornada> _jornadas;
        private List<Profesor> _profesores;


        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }


        public List<Profesor> Instructores
        {
            get { return this._profesores; }
            set { this._profesores = value; }
        }


        public List<Jornada> Jornadas
        {
            get { return this._jornadas; }
            set { this._jornadas = value; }
        }


        public Jornada this[int i]
        {
            get
            {
                if (i >= this.Jornadas.Count || i < 0)
                    return null;
                else
                    return this.Jornadas[i];
            }
            set
            {
                this.Jornadas[i] = value;
            }
        }


        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._profesores = new List<Profesor>();
            this._jornadas = new List<Jornada>();
        }


        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> datosXml = new Xml<Universidad>();
            return datosXml.Guardar("Universidad.xml", gim);
        }


        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            if (gim.Jornadas != null)
            {
                sb.AppendLine("JORNADAS: ");
                foreach (Jornada j in gim.Jornadas)
                    sb.AppendLine(j.ToString());
            }

            return sb.ToString();

        }


        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alUniversidad in g._alumnos)
            {
                if (alUniversidad == a)
                {
                    return true;
                }
            }
            return false;
        }


        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }


        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor p = null;
            try
            {
                foreach (Profesor pAux in g.Instructores)
                {
                    if (pAux == (Universidad.EClases)clase)
                        return pAux;
                }

                throw new SinProfesorException();
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            return p;
        }


        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor profUni in g._profesores)
            {
                if (profUni != clase)
                {
                    return profUni;
                }
            }

            throw new SinProfesorException();
        }


        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor prof in g._profesores)
            {
                if (prof == i)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            return retorno;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }


        public static Universidad operator +(Universidad g, Alumno a)
        {
            bool retorno = true;

            foreach (Alumno aux in g._alumnos)
            {
                if (aux == a)
                {
                    retorno = false;
                
                }
            }
            if(retorno)
            {
                g._alumnos.Add(a);
            }
            if (!retorno)
            {
                throw new AlumnoRepetidoException();
            }

            return g;
        }



        public static Universidad operator +(Universidad g, Profesor i)
        {
            foreach (Profesor prof in g._profesores)
            {
                if (prof == i)
                {
                    return g;
                }
            }

            g._profesores.Add(i);
            return g;
        }



        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada j = new Jornada(clase, g == clase);

            foreach (Alumno a in g._alumnos)
            {
                if (a == clase)
                {
                    j += a;
                }
            }
            
            g._jornadas.Add(j);

            return g;
        }


        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }




    }
}
