using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdCliente : Form
    {

        public Cliente _Cliente { get; set; }

        public mdCliente()
        {
            InitializeComponent();
        }

        private void mdCliente_Load(object sender, EventArgs e)
        {
            //foreach (DataGridViewColumn columna in dgvdata.Columns)
            //{
            //   cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            //}

            //cbobusqueda.DisplayMember = "Texto";
            //cbobusqueda.ValueMember = "Valor";
            //cbobusqueda.SelectedIndex = 0;

            List<Cliente> lista = new CN_Cliente().Listar();

            foreach (Cliente item in lista)
            {
                if (item.Estado)
                    dgvdata.Rows.Add(new object[] { item.Documento, item.NombreCompleto });
            }

        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            if (iRow >= 0 && iColum >= 0)
            {
                _Cliente = new Cliente()
                {
                    Documento = dgvdata.Rows[iRow].Cells["Documento"].Value.ToString(),
                    NombreCompleto = dgvdata.Rows[iRow].Cells["NombreCompleto"].Value.ToString()
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            //string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            //if (dgvdata.Rows.Count > 0)
            //{
            //    foreach (DataGridViewRow row in dgvdata.Rows)
            //    {

            //        if (row.Cells["NombreCompleto"].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
            //            row.Visible = true;
            //        else
            //            row.Visible = false;
            //    }
            //}


            if (dgvdata.Rows.Count > 0)
            {
                string searchText = txtbusqueda.Text.Trim().ToUpper();

                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    bool matchFound = false;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().ToUpper().Contains(searchText))
                        {
                            matchFound = true;
                            break;
                        }
                    }

                    row.Visible = matchFound;
                }
            }

        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            //Cliente cliente = new Cliente();
            //cliente.NombreCompleto = txtbusqueda.Text;

            //// Llama al método para consultar las categorías
            //CN_Cliente.ConsultarClientes(cliente);

            //// Asigna el resultado al origen de datos del DataGridView
            //dgmodalcliente.DataSource = CN_Cliente.ds;
            //dgmodalcliente.DataMember = "CargarClientes";
        }
    }
}
