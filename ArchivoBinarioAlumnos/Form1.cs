using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchivoBinarioAlumnos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            try
            {
                ClsAlumnosR objRegistrar = new ClsAlumnosR(Convert.ToInt32(txt_numero.Text), txt_nombre.Text, txt_apellido.Text, txt_apellidoMaterno.Text, txt_numeroTel.Text, txt_correo.Text, Convert.ToChar(cbo_Genero.SelectedItem.ToString()), Convert.ToString(cbo_Carrera.SelectedItem.ToString()));
                objRegistrar.RegistratDatos();
                txt_numero.Clear();
                txt_nombre.Clear();
                txt_apellido.Clear();
                txt_apellidoMaterno.Clear();
                txt_correo.Clear();
                txt_numeroTel.Clear();
                cbo_Genero.Text = " ";
                cbo_Carrera.Text = " ";
            }
            catch (Exception error)
            {
                MessageBox.Show("Ocurrio un error" + error);
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            ///buscar archivo
            try
            {
                ClsAlumnosR objBuscar = new ClsAlumnosR();
                ClsAlumnosR objBuscarapellidos = new ClsAlumnosR();
                if (objBuscar.BuscarAlumno(Convert.ToInt32(txt_numero.Text)))
                {
                    richTextBox1.Clear();
                    richTextBox1.Text = objBuscar.ToString();
                    MessageBox.Show("Se encontro alumno con exito");
                }
                if (objBuscarapellidos.BuscarAlumnoApellido(Convert.ToString(txt_apellido.Text)))
                {
                    richTextBox1.Clear();
                    richTextBox1.Text = objBuscarapellidos.ToString();
                    MessageBox.Show("Se encontro alumno con exito");
                }
                 if (objBuscar.BuscarAlumnoCarrera(Convert.ToString(cbo_Carrera.SelectedIndex.ToString())))
                {
                    richTextBox1.Clear();
                    richTextBox1.Text = objBuscar.ToString();
                    MessageBox.Show("Se encontro alumno con exito");
                }
                else 
                {
                    MessageBox.Show("Lo sentimos no esta registrado");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Genero error");
            }
        }

        private void btn_Leer_Click(object sender, EventArgs e)
        {
            ClsAlumnosR objLeer = new ClsAlumnosR();
            richTextBox1.Clear();
            objLeer.leerElregistro();
            richTextBox1.Text = objLeer.ToString();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClsAlumnosR objMostrarInformacion = new ClsAlumnosR();
            dataGridView1.DataSource = objMostrarInformacion.LeerDatosAlumnosData();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClsAlumnosR objMostrarInformacion = new ClsAlumnosR();
            dataGridView1.DataSource = objMostrarInformacion.LeerDatosAlumnosData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClsAlumnosR objMostrarInformacion = new ClsAlumnosR();

            dataGridView1.DataSource = objMostrarInformacion.LeerDatosAlumnosData();
        }

        private void cbo_buscarCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsAlumnosR objMostrarInformacion = new ClsAlumnosR();
            //            Ingenieria en sistemas
            //ingenieria en gestion
            //ingenieria civil
            //ingenieria industrial
            //ingenieria en electronica
            //ingenieria en mecatronica
            //contador publico

            switch (cbo_buscarCarrera.SelectedIndex)
            {


                case 0:
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = objMostrarInformacion.LeerDatosCarreras(Convert.ToString(cbo_buscarCarrera.SelectedItem.ToString()));
                    break;
                case 1:
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = objMostrarInformacion.LeerDatosCarreras(Convert.ToString(cbo_buscarCarrera.SelectedItem.ToString()));
                    break;
                case 2:
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = objMostrarInformacion.LeerDatosCarreras(Convert.ToString(cbo_buscarCarrera.SelectedItem.ToString()));
                    break;
                case 3:
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = objMostrarInformacion.LeerDatosCarreras(Convert.ToString(cbo_buscarCarrera.SelectedItem.ToString()));
                    break;

                case 4:
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = objMostrarInformacion.LeerDatosCarreras(Convert.ToString(cbo_buscarCarrera.SelectedItem.ToString()));
                    break;
                case 5:
                    
                    dataGridView1.DataSource = objMostrarInformacion.LeerDatosCarreras(Convert.ToString(cbo_buscarCarrera.SelectedItem.ToString()));
                    break;
                case 6:
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = objMostrarInformacion.LeerDatosCarreras(Convert.ToString(cbo_buscarCarrera.SelectedItem.ToString()));
                    break;

            }
        }
    }
}