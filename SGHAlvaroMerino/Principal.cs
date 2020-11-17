using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGHAlvaroMerino
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToString("dd:MM:yyyy");
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'hospitalDataSet.pacientes' Puede moverla o quitarla según sea necesario.
            this.pacientesTableAdapter.Fill(this.hospitalDataSet.pacientes);
            // TODO: esta línea de código carga datos en la tabla 'hospitalDataSet.especialidades' Puede moverla o quitarla según sea necesario.
            this.especialidadesTableAdapter.Fill(this.hospitalDataSet.especialidades);
            // TODO: esta línea de código carga datos en la tabla 'hospitalDataSet.atencsmedicas' Puede moverla o quitarla según sea necesario.
            this.atencsmedicasTableAdapter.Fill(this.hospitalDataSet.atencsmedicas);
            // TODO: esta línea de código carga datos en la tabla 'hospitalDataSet.atencsmedicas' Puede moverla o quitarla según sea necesario.
            this.atencsmedicasTableAdapter.Fill(this.hospitalDataSet.atencsmedicas);
            // TODO: esta línea de código carga datos en la tabla 'hospitalDataSet.medicos' Puede moverla o quitarla según sea necesario.
            this.medicosTableAdapter.Fill(this.hospitalDataSet.medicos);
            timerHora.Enabled = true;

            cmbEspecialidades.Items.Clear();
            especialidadesTableAdapter.Fill(hospitalDataSet.especialidades);
            for (int i = 0; i < hospitalDataSet.especialidades.Count; i++)
            {
                cmbEspecialidades.Items.Add(hospitalDataSet.especialidades[i].especialidad);
            }
            cmbEspecialidades.Text = cmbEspecialidades.Items[0].ToString();
        }

        private void medicosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.medicosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hospitalDataSet);

        }

        private void fillByImagenToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.medicosTableAdapter.FillByImagen(this.hospitalDataSet.medicos);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.especialidadesTableAdapter.FillBy(this.hospitalDataSet.especialidades);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.especialidadesTableAdapter.FillBy1(this.hospitalDataSet.especialidades);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnAñadirCita_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cita Añadidia", "Cita añadida", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fillByEspecialidadesToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.especialidadesTableAdapter.FillByEspecialidades(this.hospitalDataSet.especialidades);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void cmbEspecialidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbMedico.Enabled = true;
            cmbMedico.Items.Clear();
            medicosTableAdapter.Fill(hospitalDataSet.medicos);
            for (int i = 0; i < hospitalDataSet.medicos.Count; i++)
            {
                cmbMedico.Items.Add(hospitalDataSet.medicos[i].nombre);
            }
            cmbMedico.Text = cmbMedico.Items[0].ToString();
        }

        private void cmbMedico_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbPaciente.Enabled = true;
            cmbPaciente.Items.Clear();
            pacientesTableAdapter.Fill(hospitalDataSet.pacientes);
            for (int i = 0; i < hospitalDataSet.pacientes.Count; i++)
            {
                cmbPaciente.Items.Add(hospitalDataSet.pacientes[i].nombre);
            }
            cmbPaciente.Text = cmbPaciente.Items[0].ToString();
        }

        private void cmbPaciente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnAñadirCita.Enabled = true;
        }
    }
    
}
