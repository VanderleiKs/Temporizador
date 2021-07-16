using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temporizador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CancellationTokenSource exit = new CancellationTokenSource();
        bool runTask = true;

       async void Timer()
        {
            runTask = true;
            int second = (int)combSegundos.SelectedItem;
            int minut = (int)combMin.SelectedItem;
            int hour = (int)combHor.SelectedItem;
            TimeSpan t = new(hour, minut, second);
            lblTela.Text = t.ToString();
            await Task.Delay(1000);
            while (minut > 0 && runTask)
            {
                minut--;
                second = 59;
                while (second > -1 && runTask)
                {
                    t = new(hour, minut, second);
                    lblTela.Text = t.ToString();
                    await Task.Delay(1000);
                    second--;
                }
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            object[] horas = { 00, 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12 };

            object[] minutos = {00,01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,
                18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,
                41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59};

            object[] segundos = {00,01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,
                18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,
                41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59};

            combHor.Items.AddRange(horas);
            combHor.SelectedIndex = 0;

            combMin.Items.AddRange(minutos);
            combMin.SelectedIndex = 0;

            combSegundos.Items.AddRange(segundos);
            combSegundos.SelectedIndex = 0;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Timer();
            btnIniciar.Enabled = false;
            btnCancelar.Enabled = true;
            btnLimpar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Enabled = false;
            btnIniciar.Enabled = true;
            btnLimpar.Enabled = true;
            runTask = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lblTela.Text = "";
            btnCancelar.Enabled = false;
            btnIniciar.Enabled = true;
            btnLimpar.Enabled = false;
            combHor.SelectedIndex = 0;
            combMin.SelectedIndex = 0;
            combSegundos.SelectedIndex = 0;
        }
    }
}
