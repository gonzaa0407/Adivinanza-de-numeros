using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adivinanza_de_numeros
{
    public partial class Form1 : Form
    {
        int numerosecreto;
        int intentos;
        public Form1()
        {
            InitializeComponent();
            ReiniciarJuego();
        }

        private void btnAdivinar_Click(object sender, EventArgs e)
        {
            // Comprobamos si el usuario ingreso un número válido
            int numeroUsuario;
            if (int.TryParse(txtNumero.Text, out numeroUsuario))
            {
                intentos++;

                // Comparar el número del usuario con el número secreto
                if (numeroUsuario == numerosecreto)
                {
                    lblResultado.Text = $"¡Correcto! Adivinaste el número en {intentos} intentos.";
                    btnAdivinar.Enabled = false;  // Desactivar el botón para no seguir jugando
                }
                else if (numeroUsuario < numerosecreto)
                {
                    lblResultado.Text = "El número es mayor.";
                }
                else
                {
                    lblResultado.Text = "El número es menor.";
                }
            }
            else
            {
                lblResultado.Text = "Por favor, ingresa un número válido.";
            }

        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            ReiniciarJuego();
        }
        private void ReiniciarJuego()
        {
            // Genera un número aleatorio del 1 y 100
            Random random = new Random();
            numerosecreto = random.Next(1, 101);
            intentos = 0;

            lblResultado.Text = "Adivina un número entre 1 y 100.";
            txtNumero.Text = "";
            btnAdivinar.Enabled = true;  // Se vuelve a habilitar el botón de adivinanza
        }

    }
}
