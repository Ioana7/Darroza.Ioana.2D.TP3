using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto:IArchivo<string>
    {

        public bool Guardar(string archivo, string dato)
        {
            try
            {
                using (StreamWriter texto = new StreamWriter(archivo, true))
                    texto.WriteLine(dato);
                return true;
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Mensaje);
                return false;
            }
        }

        public bool Leer(string archivo, out string dato)
        {
            bool retorno = false;
            try
            {
                using (StreamReader texto = new StreamReader(archivo))
                dato = texto.ReadToEnd();
                retorno = true;
            }
            catch (ArchivosException e)
            {
                retorno = false;
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
