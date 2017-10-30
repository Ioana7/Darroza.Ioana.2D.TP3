using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad{Argentino,Extranjero}

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public string Apellido
        {
            get {return this._apellido;}

            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this._apellido = value;
                }
            }
        }

        public int DNI
        {
            get { return this._dni;}

            set
            {
                if (ValidarDni(value) != null)
                {
                    this._dni = value;
                }
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (((ENacionalidad.Argentino == nacionalidad) && (dato >= 1 && dato <= 89999999))
                || ((ENacionalidad.Extranjero == nacionalidad) && (dato >= 90000000 && dato <= 99999999)))
            {
                return dato;
            }

            throw new DniInvalidoException();
        }

        private string ValidarNombreApellido(string dato)
        {
            Regex cadena = new Regex(@"^[a-zA-ZñÑ]$");
            string retorno = null;

            if (cadena.IsMatch(dato))
                retorno = dato;

            return retorno;
        }


    }
}
