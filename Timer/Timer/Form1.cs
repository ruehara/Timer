using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer.Properties;

namespace Timer
{
    public partial class Form1 : Form
    {
        #region Atributos e Propriedades

        public Stopwatch stopWatch = new Stopwatch();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion Atributos e Propriedades

        #region Componentes Visuais
        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;
            this.ShowInTaskbar = false;
            button3.Enabled = false;
        }

        #endregion Componentes Visuais

        #region Botão Fecha

        private void btnFecha_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFecha_MouseDown(object sender, MouseEventArgs e)
        {
            this.button1.Image = Resources._3;
        }

        private void btnFecha_MouseLeave(object sender, EventArgs e)
        {
            this.button1.Image = Resources._1;
        }

        private void btnFecha_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.button1.Image = Resources._3;
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.button1.Image = Resources._2;
        }

        #endregion Botão Fecha

        #region Botão Play

        private void btnPlay_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = true;
            stopWatch.Start();
        }

        #endregion Botão Play

        #region Botão Pause

        private void btnPause_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = false;
            stopWatch.Stop();
            //SystemSounds.Beep.Play();
            //Console.Beep();
        }

        #endregion Botão Pause

        #region Botão Stop

        private void btnStop_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = false;
            stopWatch.Restart();
            stopWatch.Stop();
            label1.Text =  String.Format("{0:hh\\:mm\\:ss}", stopWatch.Elapsed);

        }

        #endregion Botão Stop

        #region Panel

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Invalidate();
            label1.Text = String.Format("{0:hh\\:mm\\:ss}", stopWatch.Elapsed);
        }

        #endregion Panel

    }
}
