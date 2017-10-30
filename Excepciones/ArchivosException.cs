using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Excepciones
{
    public class ArchivosException:Exception
    {

        private string _mensaje = "Error en el archivo";

        public string Mensaje
        {
            get
            {
                return this._mensaje + "\n" + InnerException.Message;
            }
        }

        public ArchivosException(Exception innerException)
            : base(innerException.Message, innerException)
        { }
    }
}
