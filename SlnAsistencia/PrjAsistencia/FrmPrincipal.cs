using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjAsistencia
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            
        }
        
        public static int gcontal;
        public static int gconcur;
        public static int gconasis;
        public static int gcontaluasis;
        public static string[,] galumno = new string[500, 500];
        public static string[,] gcurso = new string[500, 500];
        public static string[,] gasistencia = new string[500, 500];
        public static string[,] gasisalu = new string[500, 500];

        private void comboBox1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Pnldocente.Visible = false;
            Pnlalu.Visible = false;
            PnlAsistencia.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Pnldocente.Visible = true;
            Grpdocente.Enabled = false;
            Btnguardar.Enabled = false;
            Btnlimpiar.Enabled = false;
            Btnmodificar.Enabled = false;
            Btnnuevo.Focus();
            PnlAsistencia.Visible = false;
            Pnlalu.Visible=false;
        }

        private void Btnlimpiar_Click(object sender, EventArgs e)
        {
            Txtapellido.Text = "";
            Txtcodigo.Text = "";
            Txtdireccion. Text = "";
            Txtnombre.Text = "";
            Txtnumero.Text = "";
            Txtpass.Text = "";
            Cmbcargo.ResetText();
        }

        private void Btnnuevo_Click(object sender, EventArgs e)
        {
            Grpdocente.Enabled = true;
            Cmbcargo.Items.Add("docente");
            Cmbcargo.Items.Add("director");
            Cmbcargo.Items.Add("Contratado");
            Cmbcargo.Items.Add("Tutor");
            Cmbcargo.Items.Add("Tiempor Completo");
            Txtcodigo.Focus();
            Btnguardar.Enabled = true;
            Btnlimpiar.Enabled = true;
            Btnmodificar.Enabled = true;
            /////
            Btnnuevo.Enabled = false;
        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
           /////
            Ejer01.gcontdoc++;
            MessageBox.Show(Convert.ToString(Ejer01.gcontdoc));
            Ejer01.gdocente[Ejer01.gcontdoc, 0] = Txtcodigo.Text;
            Ejer01.gdocente[Ejer01.gcontdoc, 1] = Txtnombre.Text;
            Ejer01.gdocente[Ejer01.gcontdoc, 2] = Txtapellido.Text;
            Ejer01.gdocente[Ejer01.gcontdoc, 3] = Txtdireccion.Text;
            Ejer01.gdocente[Ejer01.gcontdoc, 4] = Txtnumero.Text;
            Ejer01.gdocente[Ejer01.gcontdoc, 5] = Cmbcargo.SelectedItem.ToString ();
            Ejer01.gdocente[Ejer01.gcontdoc, 6] = Txtpass .Text ;
            Btnnuevo.Enabled = true;
            Grpdocente.Enabled = false;

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Pnlalu.Visible = true;
            Grpalumno.Enabled = false;
            Btnguardaralu .Enabled = false;
            Btnlimpiaralu.Enabled = false;
            Btnmodificaralu.Enabled = false;
            Btnnuevoalu.Focus();
           // PnlAsistencia.Visible = true;
            Pnldocente.Visible = false;
            PnlAsistencia.Visible = false;
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            Cmbcargo.ResetText();
            string layudame = Txtbuscar.Text; int lvalor=0;
            for (int li = 0; li <= Ejer01.gcontdoc; li++)
            {// sim deseo agregar el operador or y el 
                if (layudame.Equals(Ejer01.gdocente[li, 0]) ) // layudame.Equals(Ejer01.gdocente[li, 2])\\  )
                {
                   lvalor = 1;
                   Txtcodigo.Text = Ejer01.gdocente[li, 1];
                      Txtnombre .Text   = Ejer01.gdocente[li, 2];
                      Txtapellido.Text = Ejer01.gdocente[li, 3];
                    Txtdireccion .Text =Ejer01 .gdocente[li,3];
                    Txtnumero.Text = Ejer01.gdocente[li, 4];
                    Txtpass.Text = Ejer01.gdocente[li, 6];
                    Cmbcargo.SelectedText = Ejer01.gdocente[li, 5];
                    break;
                }
            }
            if (lvalor == 0)
            {
                MessageBox.Show("no  hay  nadie");
            }
        }

        private void Btnmodificar_Click(object sender, EventArgs e)
        {
            for (int li = 0; li <= Ejer01.gcontdoc; li++)
            {
                if (Txtcodigo.Text.Equals(Ejer01.gdocente[li, 0]))
                {
                    Ejer01.gdocente[li,1] = Txtnombre.Text ;
                    Ejer01.gdocente[li,2] = Txtapellido.Text;
                    Ejer01.gdocente[li,3] = Txtdireccion.Text;
                    Ejer01.gdocente[li,4] = Txtnumero.Text;
                    Ejer01.gdocente[li,5] = Cmbcargo.SelectedItem.ToString(); 
                    Ejer01.gdocente[li,6] = Txtpass .Text ;

                }
            }
        }

        private void Btnnuevoalu_Click(object sender, EventArgs e)
        {
            Grpalumno.Enabled = true;
            MtdLlenarCbocurso();
            Btnguardaralu.Enabled = true;
            Btnlimpiaralu.Enabled = true;
           Txtcodigoalumno.Focus();
            Btnnuevoalu.Enabled = false;
            //Cbocurso.Items.Add("docente");
            //Cbocurso.Items.Add("director");
            //Cbocurso.Items.Add("Contratado");
           // Cbocurso.Items.Add("Tutor");
            //Cbocurso.Items.Add("Tiempor Completo");
            //Txtcodalu.Focus();
        }

        private void MtdLlenarCbocurso()
        {
            Cbocurso.Items.Add("SI-261");
            Cbocurso.Items.Add("SI-262");
        }

        private void Btnlimpiaralu_Click(object sender, EventArgs e)
        {
            MtdLimpiarcajaalu();
            MtdLimpiarcurso();
            Txtcodigoalumno.Text = "";
            Txtmailalu.Text = "";
            Txtcodigoalumno.Focus();
        }

        private void MtdLimpiarcurso()
        {
            Lstalumno .Items .Clear ();
            Lstcurso.Items.Clear();
        }

        private void MtdLimpiarcajaalu()
        {
            Txtnomalu.Text = "";
        }

        private void Btnguardaralu_Click(object sender, EventArgs e)
        {
            galumno[gcontal, 0] = Txtcodigoalumno.Text;
            galumno[gcontal, 1] = Txtnomalu.Text;
            galumno[gcontal, 2] = Txtmailalu.Text;
            gcontal++;
            Lstalumno.Items.Add(Txtnomalu.Text);
            Btnnuevoalu.Enabled = true;
        }

        private void Cbocurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbocurso.SelectedItem.ToString().Equals("SI-261"))
            {
                Txtcodcurso.Text = "Calculo I";
                //Txtbuscarasis.Text = Cbocurso.SelectedItem.ToString();
            }
            if (Cbocurso.SelectedItem.ToString().Equals("SI-262"))
            {
                Txtcodcurso.Text = "Matematica Discreta";
                //Txtbuscarasis.Text = Cbocurso.SelectedItem.ToString();
            }
        }

        private void Btnguardarcurso_Click(object sender, EventArgs e)
        {

            gcurso[gconcur, 0] = Cbocurso.SelectedItem.ToString();
            gcurso[gconcur, 1] = Txtcodcurso.Text;
            gcurso[gconcur, 2] = Txtcodigoalumno.Text;
            gcurso[gconcur, 3] = Txtnomalu.Text;

            Lstcurso.Items.Add(Txtcodcurso.Text);
            gconcur++;
        }

        private void Buscarasis_Click(object sender, EventArgs e)
        {
            MessageBox.Show(""+gconcur);
            for (int li = 0; li <= gconcur; li++)
            {
                if (Txtbuscarasis.Text.Equals(gcurso[li,0]))
                {
                    Lstaluasis.Items.Add(gcurso[li, 3]);
                }
            }
        }

        private void Btnguardarasis_Click(object sender, EventArgs e)
        {
            // Contador alumnos que se ha tomado asistencia
            int layuda = Lstaluasis.Items.Count;

            gconasis++;
            gasistencia[gconasis, 0] = DtpFecha.Text;
            gasistencia[gconasis, 1] = Txtcodcurso.Text;

            for (int li = 0; li <= layuda; li++)
            {
                gasisalu[gconasis, 0] = Lstaluasis.Items[li].ToString();
                if (Rdbpresente.Checked == true)
                {
                    gasisalu[gconasis, 1] = "Presente"; 
                }
                if (Rdbtarde.Checked == true)
                {
                    gasisalu[gconasis, 1] = "Tarde";
                }
                if (Rdbausente.Checked == true)
                {
                    gasisalu[gconasis, 1] = "Ausente";
                }
            }


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pnlalu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PnlAsistencia.Visible = true;
            
            Pnlalu.Visible = false;
            Pnldocente.Visible = false;
        }

        private void Cmbcargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Txtbuscarasis_TextChanged(object sender, EventArgs e)
        {
           // Txtbuscarasis.Text = Cbocurso.SelectedItem.ToString();
        }

        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Btnbuscaralu_Click(object sender, EventArgs e)
        {
            for (int li = 0; li <= gcontal; li++)
            {
                if (Txtbuscaralu.Text.Equals(galumno[li, 0]))
                {
                    Txtcodigoalumno.Text = galumno[li, 0];
                    Txtnomalu.Text = galumno[li, 1];
                    Txtmailalu.Text = galumno[li, 2];
                   // Cbocurso.SelectedItem = gcurso[gconcur, 0];
                    Cbocurso.SelectedItem = gcurso[li, 0];
                }
            
            }
        }

        private void Txtnomalu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                    if (Char.IsControl(e.KeyChar))
                    {
                        e.Handled = false;

                    }
                    else
                    {
                        e.Handled = true;
                    }
        }

        private void Txtcodigoalumno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
        }

        private void Txtcodigoalumno_TextChanged(object sender, EventArgs e)
        {

        }

        private void Rdbpresente_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("as");
            Lstpresente.Items.Add(Lstaluasis.SelectedItem.ToString());
            Rdbpresente.Checked = false;
            Lstaluasis.Items.Remove(Lstaluasis.SelectedItem);
        }

        private void Rdbtarde_Click(object sender, EventArgs e)
        {
            Lsttarde.Items.Add(Lstaluasis.SelectedItem.ToString());
            Rdbtarde.Checked = false;
            Lstaluasis.Items.Remove(Lstaluasis.SelectedItem);
        }

        private void Rdbausente_Click(object sender, EventArgs e)
        {
            Lstausente.Items.Add(Lstaluasis.SelectedItem.ToString());
            Rdbausente.Checked = false;
            Lstaluasis.Items.Remove(Lstaluasis.SelectedItem);
        }

        private void PnlAsistencia_Paint(object sender, PaintEventArgs e)
        {
           // Lstaluasis.Items.Add("123");
            //Lstaluasis.Items.Add("123a");
           // Lstaluasis.Items.Add("12b3");
           // Lstaluasis.Items.Add("123c");


        }
    }
}
