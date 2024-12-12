using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{

    public partial class Form1 : Form
    {

        string playerX = "";
        string playerO = "";
        bool cambio = true;
        int empate = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OnOffBtn(false);
        }

        //Funcionalidad a cada cuadro para marcar signo
        private void OnOffBtn(bool onoff)
        {
            a1.Enabled = onoff;
            a2.Enabled = onoff;
            a3.Enabled = onoff;
            b1.Enabled = onoff;
            b2.Enabled = onoff;
            b3.Enabled = onoff;
            c1.Enabled = onoff;
            c2.Enabled = onoff;
            c3.Enabled = onoff;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void Ingresar()
        {
            //Cuando ninguno de los jugadores ingresa un nombre
            if (txtUser1.Text == "" && txtUser2.Text == "")
            {
                //Mensaje de advertencia
                MessageBox.Show("El nombre de los jugadores no puede ser null", "Nombre invalido"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }

            //En caso de que cada usuario no ingrese un nombre
            else
            {
                if (txtUser1.Text == "")
                {
                    MessageBox.Show("El nombre del Player1 no puede ser null", "Nombre invalido"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                }
                if (txtUser2.Text == "")
                {
                    MessageBox.Show("El nombre del Player2 no puede ser null", "Nombre invalido"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                }
            }

            //Cuando el usuario ingresa un nombre
            if (txtUser1.Text != "" && txtUser2.Text != "")
            {
                //Seleccion de X a Player1 y O a Player 2
                if (RbUser1X.Checked && RbUser2O.Checked)
                {
                    //Iguala el signo a cada jugador
                    playerX = txtUser1.Text;
                    playerO = txtUser2.Text;

                    //Desactiva el otro signo que no se escogio
                    RbUser1O.Enabled = false;
                    RbUser2X.Enabled = false;

                    //Inicializar
                    PlayGame();
                }

                //Seleccion de O a Player1 y X a Player 2
                if (RbUser1O.Checked && RbUser2X.Checked)
                {
                    //Iguala el signo a cada jugador
                    playerO = txtUser1.Text;
                    playerX = txtUser2.Text;

                    //Desactiva el otro signo que no se escogio
                    RbUser1X.Enabled = false;
                    RbUser2O.Enabled = false;
                }


                //En caso de que seleccionen X
                if (RbUser1X.Checked && RbUser2X.Checked)
                {
                    //Mensaje de advertencia
                    MessageBox.Show("Solo un jugador puede escoger la letra X", "Escoja una letra diferente"
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Information);
                }

                //En caso de que seleccionen O
                if (RbUser1O.Checked && RbUser2O.Checked)
                {
                    //Mensaje de advertencia
                    MessageBox.Show("Solo un jugador puede escoger la letra O", "Escoja una letra diferente"
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Information);
                }


                //En caso de no seleccionar signo, primer escenario
                if (RbUser1X.Checked == false && RbUser2O.Checked == false || RbUser2X.Checked == false && RbUser1O.Checked == false)
                {
                    //Mensaje de advertencia
                    MessageBox.Show("Cada jugador debe seleccionar una letra", "Escoja una letra"
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Information);
                }
            }
        }

        //Agrega nombre a los jugadores
        private void PlayGame()
        {
            Player1.Text = txtUser1.Text;
            Player2.Text = txtUser2.Text;

            groupBox1.Text = "Score";

            btnLimpiar.Visible = true;
            btnReiniciar.Visible = true;

            btnNewGame.Visible = false;
            txtUser1.Visible = false;
            txtUser2.Visible = false;

            //Mensaje de advertencia
            MessageBox.Show("Empieza " + playerX, "Informacion"
           , MessageBoxButtons.OK
           , MessageBoxIcon.Information);

            OnOffBtn(true);
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {

        }

        //Representa todos los botones
        private void Buttons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (cambio)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            cambio = !cambio;
            b.Enabled = false;
            Partida();
        }

        private void Partida()
        {
            //Formas de Ganar Horizontal
            if ((a1.Text == a2.Text) && (a2.Text == a3.Text) && (!a1.Enabled))
            {
                MessageBox.Show("Winner!");
            }
            else if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled))
            {
                MessageBox.Show("Winner!");
            }
            else if ((c1.Text == c2.Text) && (c2.Text == c3.Text) && (!c1.Enabled))
            {
                MessageBox.Show("Winner!");
            }

            //Formas de Ganar Vertical
            if ((a1.Text == b1.Text) && (b1.Text == c1.Text) && (!a1.Enabled))
            {
                MessageBox.Show("Winner!");
            }
            else if ((a2.Text == b2.Text) && (b2.Text == c2.Text) && (!a2.Enabled))
            {
                MessageBox.Show("Winner!");
            }
            else if ((a3.Text == b3.Text) && (b3.Text == c3.Text) && (!a3.Enabled))
            {
                MessageBox.Show("Winner!");
            }

            //Formas de Ganar Diagonal
            if ((a1.Text == b2.Text) && (b2.Text == c3.Text) && (!a1.Enabled))
            {
                MessageBox.Show("Winner!");
            }
            else if ((a3.Text == b2.Text) && (b2.Text == c1.Text) && (!a3.Enabled))
            {
                MessageBox.Show("Winner!");
            }

            //Empate
            empate++;
            if (empate == 9)
            {
                MessageBox.Show("Es un Empate!!", "Empate"
                , MessageBoxButtons.OK
                , MessageBoxIcon.Information);

                OnOffBtn(true);
                empate = 0;
            }

        }
    }
}
