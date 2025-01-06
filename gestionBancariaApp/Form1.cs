using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestionBancariaApp
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = "1000";
            txtCantidad.Text = "0";
        }


        private void btOperar_Click(object sender, EventArgs e)
        {
            string operacion = "";
            double cantidad = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número


            gestionBancaria cuenta = new gestionBancaria(Int32.Parse(txtSaldo.Text));

            if (rbReintegro.Checked)
                operacion = "R";

            if (radioButton1.Checked)
                operacion = "I";

            switch (operacion)
            {

                case "R":
                    cuenta.realizarReintegro(cantidad);
                    break;

                case "I":
                    cuenta.realizarIngreso(cantidad);
                    break;
                default:
                    cuenta.mostrarError(2);
                break;

            }

            txtSaldo.Text = cuenta.obtenerSaldo().ToString();
        }


    }
}
