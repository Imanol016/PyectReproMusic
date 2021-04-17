using PReproductorMusica.clases;
using PReproductorMusica.listacircular;
using PReproductorMusica.ListaDoble;
using PReproductorMusica.NewFolder1.obListaOrdenada;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PReproductorMusica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool play = false;
        String[] ArchivosMP3;
        String[] RutasArchMP3;

        NodoListCir nuevo;

        OpenFileDialog EncontrarArchivos = new OpenFileDialog();
        ListaOrdenada parametro = new ListaOrdenada();
        clsListaDoble ListaD = new clsListaDoble();
        ListaCircular ListaC = new ListaCircular();

        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Cerrar app.
            this.Close();
        }

        private void listBoxMusica_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            EncontrarArchivos.Multiselect = true;

            if (ListaGeneral.SelectedIndex != -1)
            {
                axWindowsMediaPlayer1.URL = EncontrarArchivos.FileNames[ListaGeneral.SelectedIndex];
                int Index = ListaGeneral.SelectedIndex;
                nuevo = new NodoListCir(EncontrarArchivos.FileNames[Index]);
                timer1.Start();
                //trackBar1.Value = 20;
                //lbl_volumen.Text = trackBar1.Value.ToString() + "%";
            }
        }
        private void buttonAgregar_Click(object sender, EventArgs e)
        {            
            EncontrarArchivos.Multiselect = true;

            if(EncontrarArchivos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for(int i=0; i<EncontrarArchivos.FileNames.Length; i++)
                {
                    ListaD.insertarCabezaLista(EncontrarArchivos.FileNames[i]);
                    ListaC.insertar(EncontrarArchivos.FileNames[i]);
                    ListaGeneral.Items.Add(EncontrarArchivos.SafeFileNames[i]);                    
                }

                axWindowsMediaPlayer1.URL = EncontrarArchivos.FileNames[0];
                ListaGeneral.SelectedIndex = 0;

                int pausa;
                pausa = 0;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(ListaGeneral.SelectedIndex > 0)
            {
                ListaGeneral.SelectedIndex = ListaGeneral.SelectedIndex - 1;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            switch (play)
            {
                case true:
                    {
                        axWindowsMediaPlayer1.Ctlcontrols.pause();
                        pictureBox3.Image = Properties.Resources.icons8_youtube_play_64;
                        play = false;
                        break;
                    }
                case false:
                    {
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                        pictureBox3.Image = Properties.Resources.icons8_pausa_en_círculo_64;
                        play = true;
                        break;
                    }
                    
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            pictureBox3.Image = Properties.Resources.icons8_air_play_50;
            play = false;
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Multiselect = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ArchivosMP3 = ofd.SafeFileNames;
                RutasArchMP3 = ofd.SafeFileNames;

                for (int i = 0; i < ArchivosMP3.Length; i++)
                {
                    ListaGeneral.Items.Add(ArchivosMP3[i]);
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if(ListaGeneral.SelectedIndex < ListaGeneral.Items.Count - 1)
            {
                ListaGeneral.SelectedIndex = ListaGeneral.SelectedIndex + 1;
            }
            else
            {
                recorrer();
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            parametro.eliminar(ListaGeneral.SelectedIndex);

            ListaGeneral.Items.Remove(ListaGeneral.SelectedItem);
            axWindowsMediaPlayer1.Ctlcontrols.stop();

            int pausa;
            pausa = 0;
        }

        public void recorrer()
        {

            if (nuevo != null)
            {
                nuevo = ListaC.lc.enlace; 
                                          
                while (nuevo == ListaC.lc.enlace)
                {
                    if (ListaGeneral.SelectedIndex < ListaGeneral.Items.Count - 1)
                    {
                        ListaGeneral.SelectedIndex += 1;
                        //recorrer();
                        nuevo = nuevo.enlace;
                    }
                    else
                    {

                        axWindowsMediaPlayer1.URL = EncontrarArchivos.FileNames[0];
                        ListaGeneral.SelectedIndex = 0;
                        nuevo = nuevo.enlace;
                    }

                    nuevo = nuevo.enlace;
                }
            }
            else
            {
                MessageBox.Show("\t Lista Circular vacía.");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Random Ran = new Random();
            int a = Ran.Next(ListaGeneral.Items.Count - 1);
            axWindowsMediaPlayer1.URL = EncontrarArchivos.FileNames[a];
            ListaGeneral.SelectedIndex = a;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            //if(axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            //{
            //    progressBar1.Maximum = (int)axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration;
            //    progressBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressBar1.Maximum = (int)axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration;
                progressBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            }

            lbl_track_start.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
            lbl_track_end.Text = axWindowsMediaPlayer1.Ctlcontrols.currentItem.durationString.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
            lbl_volumen.Text = trackBar1.Value.ToString();
        }
    }
}