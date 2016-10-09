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
        string directorio = Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments) + "\\ScoreBoard";
        string appname = "ScoreBoardSaveFile.xml";
       
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

    
        void updatescoreboard()
        {
            score_home = score_visitors = 0;
            foreach (Jugada jug in  jugadas)
            {
                if (jug.clasificacion == Jugada.ClasificacionJugada.GOL && jug.equipo == Jugada.Equipo.HOME)
                {
                    score_home++;
                }
                if (jug.clasificacion == Jugada.ClasificacionJugada.GOL && jug.equipo == Jugada.Equipo.VISITOR)
                {
                    score_visitors++;
                }
            }

            lblhomescore.Text = Convert.ToString(score_home);
            lblvisitorscore.Text = Convert.ToString(score_visitors);
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                jugadas.Add(new Jugada(Jugada.Equipo.HOME, (Jugada.ClasificacionJugada)comboBox2.SelectedValue, (Jugada.Criterio)comboBox1.SelectedValue));
              //  if ((Jugada.ClasificacionJugada)comboBox2.SelectedValue==Jugada.ClasificacionJugada.GOL) 
               // {
               //     score_home++;
               // }
             //   dataGridView1.DataSource = jugadas;
            }
            else if (radioButton2.Checked)
            {
                jugadas.Add(new Jugada(Jugada.Equipo.VISITOR, (Jugada.ClasificacionJugada)comboBox2.SelectedValue, (Jugada.Criterio)comboBox1.SelectedValue));
           //     if ((Jugada.ClasificacionJugada) comboBox2.SelectedValue == Jugada.ClasificacionJugada.GOL)
            //    {
            //        score_visitors++;
             //   }
            //    dataGridView1.DataSource = jugadas;
            }
            updatescoreboard();
            updateDataGrid();
           
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

        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                savemyfile();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar el archivo");
            }
        }
        void updateDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = jugadas;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                jugadas = JugadaIO.LeerJugadas(System.IO.Path.Combine(directorio,appname));
                updateDataGrid();
                updatescoreboard();
                MessageBox.Show("Archivo cargado Exitosamente");
            }
            catch (Exception)
            {
                MessageBox.Show("Error al leer el archivo, es posible que este no exista");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Seguro que quiere borrar el registro?","Warning", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                jugadas.Clear();
                updateDataGrid();
                updatescoreboard();
            }
        }
        void savemyfile()
        {
            string fulldir = System.IO.Path.Combine(directorio, appname);
            if (System.IO.Directory.Exists(directorio))
            {
                JugadaIO.GuardarJugadas(fulldir, jugadas);
                MessageBox.Show("Datos Guardados Correctamente");
            }
            else
            {
                System.IO.Directory.CreateDirectory(directorio);
                savemyfile();

            }
        }
    }
}
