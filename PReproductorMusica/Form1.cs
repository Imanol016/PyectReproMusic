using PReproductorMusica.clases;
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

        OpenFileDialog EncontrarArchivos = new OpenFileDialog();
        ListaOrdenada parametro = new ListaOrdenada();

        //public void Archivos()
        //{
        //    EncontrarArchivos.Multiselect = true;

        //    if(EncontrarArchivos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        ArchivosMP3 = EncontrarArchivos.SafeFileNames;
        //        RutasArchMP3 = EncontrarArchivos.FileNames;

        //        foreach(string ArchivosMP3 in ArchivosMP3)
        //        {
        //            ListaGeneral.Items.Add(ArchivosMP3);
        //        }

        //        axWindowsMediaPlayer1.URL = RutasArchMP3[0];
        //        ListaGeneral.SelectedIndex = 0;

        //    }
        //}
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

            }
        }
        private void buttonAgregar_Click(object sender, EventArgs e)
        {            
            EncontrarArchivos.Multiselect = true;

            if(EncontrarArchivos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for(int i=0; i<EncontrarArchivos.FileNames.Length; i++)
                {
                    parametro.insertaOrden(EncontrarArchivos.FileNames[i]);
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
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            parametro.eliminar(ListaGeneral.SelectedIndex);

            ListaGeneral.Items.Remove(ListaGeneral.SelectedItem);
            axWindowsMediaPlayer1.Ctlcontrols.stop();

            int pausa;
            pausa = 0;
        }
    }
}
