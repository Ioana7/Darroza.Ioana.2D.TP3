using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero}

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;


        public string Apellido
        {
            get { return this._apellido; }

            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this._apellido = this.ValidarNombreApellido(value);
                }
            }
        }


        public int DNI
        {
            get { return this._dni; }

            set{ this._dni = ValidarDni(this.Nacionalidad,value);}
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad;}

            set{this._nacionalidad = value;}
        }


        public string Nombre
        {
            get { return this._nombre;}

            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this._nombre = this.ValidarNombreApellido(value);
                }
            }
        }


        public string StringToDNI
        {
            set
            {
                try
                {
                    this._dni = ValidarDni(this._nacionalidad, value);
                }

                catch (Exception)
                {
                    throw new NacionalidadInvalidaException();
                }
            }
        }

        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre= nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }


        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
           :this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " +  this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad.ToString());
            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if ((nacionalidad == ENacionalidad.Argentino && dato > 0 && dato < 90000000) || (nacionalidad == ENacionalidad.Extranjero && dato > 90000000 && dato < 99999999))
                return dato;
            throw new DniInvalidoException();
        }


        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDni(nacionalidad, int.Parse(dato));
        }


        private string ValidarNombreApellido(string dato)
        {
            Regex rg = new Regex(@"^[a-zA-Z]$");
            if (rg.IsMatch(dato))
            {
                return dato;
            }
            else
            {
                return null;
            }
        }

    }
}
