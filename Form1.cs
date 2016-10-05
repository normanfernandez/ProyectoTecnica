using ProyectoTecnica.models;
using ProyectoTecnica.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTecnica
{
    public partial class Form1 : Form
    {
        int score_visitors = 0; 
        int score_home = 0; 
         
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(Jugada.Criterio));
            updatescoreboard();
            this.radioButton1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            /*List<Jugada> jugadas = new List<Jugada>();
            jugadas.Add(new Jugada(Jugada.Equipo.HOME,
                Jugada.ClasificacionJugada.CENTROS,
                Jugada.Criterio.JUGADA_OFENSIVA));
            
            jugadas.Add(new Jugada(Jugada.Equipo.HOME,
                Jugada.ClasificacionJugada.TIRO_A_META,
                Jugada.Criterio.ANOTACION)); 
            
            jugadas.Add(new Jugada(Jugada.Equipo.VISITOR,
                 Jugada.ClasificacionJugada.SAQUE_DE_META,
                 Jugada.Criterio.JUGADA_OFENSIVA));*/

            //JugadaIO.LeerJugadas("jugadas.xml");
        }
        void updatescoreboard()
        {
            lblhomescore.Text = Convert.ToString(score_home);
            lblvisitorscore.Text = Convert.ToString(score_visitors);
        }
    }
}
