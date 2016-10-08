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
        List<Jugada> jugadas = new List<Jugada>();

        private static List<Jugada.ClasificacionJugada> ofensiva = new List<Jugada.ClasificacionJugada>
        {
            Jugada.ClasificacionJugada.GOL, //Ofensiva
            Jugada.ClasificacionJugada.SAQUE_DE_META, //Ofensiva
            Jugada.ClasificacionJugada.TIRO_A_META, //Ofensiva
            Jugada.ClasificacionJugada.PASES, //Ofensiva
            Jugada.ClasificacionJugada.CENTROS, //Ofensiva
            Jugada.ClasificacionJugada.TIRO_LIBRE, //Ofensiva
            Jugada.ClasificacionJugada.SAQUE_DE_MANO,//Ofensiva
            Jugada.ClasificacionJugada.TIRO_DE_ESQUINA,//Ofensiva
            Jugada.ClasificacionJugada.TIRO_LIBRE_DIRECTO,//Ofensiva
            Jugada.ClasificacionJugada.TIRO_LIBRE_INDIRECTO//Ofensiva

        };
        private static List<Jugada.ClasificacionJugada> defensiva = new List<Jugada.ClasificacionJugada>
        {
            Jugada.ClasificacionJugada.ATAJO_DE_BALON, //Defensiva
            Jugada.ClasificacionJugada.ROBO, //Defensiva
            Jugada.ClasificacionJugada.DESPEJES, //Defensiva
            Jugada.ClasificacionJugada. BLOQUEOS,//Defensiva 
        };
        private static List<Jugada.ClasificacionJugada> falta = new List<Jugada.ClasificacionJugada>
        {
            Jugada.ClasificacionJugada.POSICIONES_ADELANTADAS, //Falta
            Jugada.ClasificacionJugada.PENAL, //Falta
            Jugada.ClasificacionJugada.TARJETA_AMARILLA,
            Jugada.ClasificacionJugada.TARJETA_ROJA
        };

        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(Jugada.Criterio));
            updatescoreboard();
            this.radioButton1.Select();
            dataGridView1.DataSource = jugadas;
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

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                jugadas.Add(new Jugada(Jugada.Equipo.HOME, (Jugada.ClasificacionJugada)comboBox2.SelectedValue, (Jugada.Criterio)comboBox1.SelectedValue));
                if ((Jugada.ClasificacionJugada)comboBox2.SelectedValue==Jugada.ClasificacionJugada.GOL) 
                {
                    score_home++;
                }
             //   dataGridView1.DataSource = jugadas;
            }
            else if (radioButton2.Checked)
            {
                jugadas.Add(new Jugada(Jugada.Equipo.VISITOR, (Jugada.ClasificacionJugada)comboBox2.SelectedValue, (Jugada.Criterio)comboBox1.SelectedValue));
                if ((Jugada.ClasificacionJugada) comboBox2.SelectedValue == Jugada.ClasificacionJugada.GOL)
                {
                    score_visitors++;
                }
            //    dataGridView1.DataSource = jugadas;
            }
            updatescoreboard();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = jugadas;
                MessageBox.Show("Jugada Insertada");
           
          }

   

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Jugada.Criterio)comboBox1.SelectedValue == Jugada.Criterio.JUGADA_DEFENSIVA)
            {
                comboBox2.DataSource = defensiva;
            }
            else if ((Jugada.Criterio)comboBox1.SelectedValue == Jugada.Criterio.JUGADA_OFENSIVA)
            {
                comboBox2.DataSource = ofensiva;
            }
            else if ((Jugada.Criterio)comboBox1.SelectedValue == Jugada.Criterio.FALTA)
            {
                comboBox2.DataSource = falta;
            }
        }

   
    }
}
