using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            // Agrego elementos al combobox
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }

        // Cerrar
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Limpiar
        private void Limpiar()
        {
            lblResultado.ResetText();
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.ResetText();
        }
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            // Llamo al metodo dentro del evento
            Limpiar();
        }

        // Operar
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);


            double bufferAux;

            bufferAux = Calculadora.Operar(num1, num2, operador);

            return bufferAux;
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            // El resultado de la operacion se muestra en el texto del label
            lblResultado.Text = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }


        // Convertir a Binario
        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            // El texto del label contiene el resultado de la operacion
            // Convierto el resultado a binario
            // Si la conversion es exitosa, el resultado existe, por lo tanto lo muestro por label
            if (Numero.DecimalBinario(lblResultado.Text) != "Valor inválido")
            {
                lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            }
            else // Si el resultado es invalido muestro un alert con el mensaje de error
            {
                MessageBox.Show(Numero.DecimalBinario(lblResultado.Text));
            }
        }

        // Convertir a Decimal
        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (Numero.BinarioDecimal(lblResultado.Text) != "Valor inválido")
            {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            }
            else
            {
                MessageBox.Show(Numero.BinarioDecimal(lblResultado.Text));
            }
        }


    }
}
