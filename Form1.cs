using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Registro_de_datos_de_un_estudiante
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {


            //BOTONES
            btn_Agregar.Enabled = true;

            btn_Eliminar.Enabled = false;
            btn_Guardar.Enabled = true;

            txt_Matricula.Clear();
            txt_Direccion.Clear();
            txt_MaestroTitular.Clear();
            txt_Telefono.Clear();
            txt_Email.Clear();
            txt_Nombre.Clear();


        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            btn_Guardar.Enabled = true;

            btn_Guardar.Enabled = false;
            btn_Eliminar.Enabled = true;
            btn_Agregar.Enabled = true;
            btn_Nuevo.Enabled = true;

            DialogResult resultado = dlg_Guardar.ShowDialog();

            // Verificar si el usuario presionó el botón Guardar
            if (resultado == DialogResult.OK)
            {

                string ruta_archivo = dlg_Guardar.FileName;
                string crea_texto = ruta_archivo;

                using (StreamWriter archivo = File.CreateText(ruta_archivo))
                {
                    archivo.Write(txt_Matricula.Text); archivo.Write(txt_Nombre.Text); archivo.Write(cb_Curso.Text); archivo.Write(cb_Seccion.Text); archivo.Write(cb_AreaTecnica.Text);
                    foreach (DataGridViewRow fila in dgv_Datos.Rows)
                    {
                        // Obtiene los valores de las celdas (supongamos que son 4 columnas)
                        string valorColumna1 = fila.Cells[0].Value?.ToString() ?? "";
                        string valorColumna2 = fila.Cells[1].Value?.ToString() ?? "";
                        string valorColumna6 = fila.Cells[6].Value?.ToString() ?? "";
                        string valorColumna7 = fila.Cells[7].Value?.ToString() ?? "";
                        string valorColumna8 = fila.Cells[8].Value?.ToString() ?? "";

                        // Escribe los valores en el archivo de texto
                        archivo.WriteLine($"{valorColumna1}, {valorColumna2}, {valorColumna6},{valorColumna7},{valorColumna8}");


                    }
                }

            }
        

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            DialogResult resultado;

            resultado = MessageBox.Show("Desea salir de la aplicacion?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Close();
            }
        }

        private void dgv_Datos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            btn_Eliminar.Enabled = true;


            string genero;

            if (rb_Masculino.Checked)
            {
                genero = "Maculino";
            }
            else
            {
                genero = "Femenino";
            }
            dgv_Datos.Rows.Add(txt_Nombre.Text, txt_Matricula.Text, txt_Direccion.Text, txt_Telefono.Text, genero, cb_Curso.Text, cb_Seccion.Text, cb_AreaTecnica.Text, txt_MaestroTitular.Text);
        }

        private void dgv_Datos_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Datos.Rows.Count == 0)
            {
                MessageBox.Show("Debe selecionar una fila para eliminar", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int fila;
                fila = dgv_Datos.CurrentRow.Index;
                DialogResult respuesta;
                respuesta = MessageBox.Show("Desea eliminar este registro?", "Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    dgv_Datos.Rows.RemoveAt(fila);
                    MessageBox.Show("Registro eliminado");

                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_Matricula_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
