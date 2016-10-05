using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProyectoTecnica.models
{
    [XmlRoot("Jugada")]
    public class Jugada
    {
        public Equipo equipo { get; set; }
        public Criterio criterio { get; set; }
        public ClasificacionJugada clasificacion { get; set; }

        public enum Equipo{ 
            HOME,
            VISITOR
        }

        public enum ClasificacionJugada { 
            //Despues de falta
            SAQUE_DE_MANO,
            TIRO_DE_ESQUINA,
            TIRO_LIBRE_DIRECTO,
            TIRO_LIBRE_INDIRECTO,
            /////////////
            
            ATAJO_DE_BALON, //Defensiva
            ROBO, //Defensiva
            DESPEJES, //Defensiva

            SAQUE_DE_META, //Ofensiva
            TIRO_A_META, //Ofensiva
            PASES, //Ofensiva
            CENTROS, //Ofensiva
            TIRO_LIBRE, //Ofensiva

            
            POSICIONES_ADELANTADAS //Falta
        }

        public enum Criterio { 
            JUGADA_DEFENSIVA,
            JUGADA_OFENSIVA,
            ANOTACION,
            FALTA
        }

        public Jugada() { }

        public Jugada(Equipo e, ClasificacionJugada cj){
            equipo = e;
            clasificacion = cj;
        }

        public Jugada(Equipo e, ClasificacionJugada cj, Criterio c){
            equipo = e;
            clasificacion = cj;
            criterio = c;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
