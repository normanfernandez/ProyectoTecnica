using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTecnica.models;

namespace ProyectoTecnica.utils
{
    public class JugadaManager
    {
        /// <summary>
        /// Método utilizado para crear la lista de jugadas. Por si
        /// solo saca que equipo recibe la pelota primero, luego se delega el 
        /// trabajo a la función JugadasPseudoRandom para tener más ordern.
        /// </summary>
        /// <returns>La lista de todas las jugadas de la partida.</returns>
        public static List<Jugada> CrearJugadas() {
            List<Jugada> jugadas = new List<Jugada>(); //Lista de todas las jugadas.
            Random randomizer = new Random(); //Randomizer para los eventos.

            //Se decide que equipo obtiene la pelota 50-50
            if (randomizer.Next(0, 1) == 0)
                jugadas.Add(new Jugada(Jugada.Equipo.HOME, Jugada.ClasificacionJugada.CENTROS));
            else
                jugadas.Add(new Jugada(Jugada.Equipo.VISITOR, Jugada.ClasificacionJugada.CENTROS));

            JugadasPseudoRandom(jugadas);
            
            return jugadas;
        }

        /// <summary>
        /// Método que llena la lista de jugadas que se le pase. Asume una jugada por minuto. (90 minutos de juego.)
        /// </summary>
        /// <param name="jugadas">La lista con la primera jugada</param>
        /// <returns>Una lista con todas las jugadas de ese partido.</returns>
        private static List<Jugada> JugadasPseudoRandom(List<Jugada> jugadas){
            Random randomizer = new Random();
            
            for (int i = 0; i < 90; i++) { 
                Jugada ultimaJugada = jugadas.ElementAt(i);


            }
            
            return jugadas;
        }
    }
}
