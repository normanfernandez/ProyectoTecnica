using ProyectoTecnica.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace ProyectoTecnica.utils
{
    public static class JugadaIO
    {
        
        public static void GuardarJugadas(string filename, 
            List<Jugada> jugadas) {
           
            Stream fs = new FileStream(filename, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(jugadas.GetType());
            StreamWriter writer = new StreamWriter(fs, Encoding.Unicode);
            serializer.Serialize(writer,jugadas);
            writer.Close();
        }
 
        public static List<Jugada> LeerJugadas(string filename) {
            FileStream fs = new FileStream(filename, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Jugada>));
            XmlReader reader = XmlReader.Create(fs);
            List<Jugada> jugadas = (List<Jugada>)serializer.Deserialize(reader);
            reader.Close();
            return jugadas;
        }
    }
}
