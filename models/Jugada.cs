﻿using System;
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
       
            
            ATAJO_DE_BALON, //Defensiva
            ROBO, //Defensiva
            DESPEJES, //Defensiva
            BLOQUEOS,//Defensiva

            GOL,
            SAQUE_DE_META, //Ofensiva
            TIRO_A_META, //Ofensiva
            PASES, //Ofensiva
            CENTROS, //Ofensiva
            TIRO_LIBRE, //Ofensiva

            SAQUE_DE_MANO,
            TIRO_DE_ESQUINA,
            TIRO_LIBRE_DIRECTO,
            TIRO_LIBRE_INDIRECTO,
            
            /////////////

            POSICIONES_ADELANTADAS, //Falta
            PENAL, //Falta
            TARJETA_AMARILLA,
            TARJETA_ROJA
        }


        public enum Criterio { 
            JUGADA_DEFENSIVA,
            JUGADA_OFENSIVA,
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
