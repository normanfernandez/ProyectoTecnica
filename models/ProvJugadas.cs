using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ProyectoTecnica.utils
{
     class ProvJugadas
    {
        public ProvJugadas()
        {

        }
        string[] jugadas = new string[]
        {
           "SAQUE_DE_MANO",
           "TIRO_DE_ESQUINA",
           "TIRO_LIBRE_DIRECTO",
           "TIRO_LIBRE_INDIRECTO",
            /////////////
            
            "ATAJO_DE_BALON", //Defensiva
            "ROBO", //Defensiva
            "DESPEJES", //Defensiva

            "SAQUE_DE_META", //Ofensiva
            "TIRO_A_META", //Ofensiva
            "PASES", //Ofensiva
            "CENTROS", //Ofensiva
            "TIRO_LIBRE", //Ofensiva

            
            "POSICIONES_ADELANTADAS", //Falta
            "PENAL" //Falta
        };
    }
}
