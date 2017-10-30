using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Excepciones;


namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {

        public bool Guardar(string archivo, T dato)
        {
            try
            {
                using (TextWriter texto = new StreamWriter(archivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    xml.Serialize(texto, dato);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
                throw new ArchivosException(e);
            }
        }

        public bool Leer(string archivo, out T dato)
        {
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(T));
                TextReader writer = new StreamReader(archivo);

                dato = (T)sr.Deserialize(writer);
                writer.Close();
                return true;
                  
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
                dato = default(T);
                return false; 
            }
        }

    }
}
