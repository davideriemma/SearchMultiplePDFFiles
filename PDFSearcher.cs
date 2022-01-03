using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchMultiplePDFFiles
{
    public partial class PDFSearcher : Form
    {
        public PDFSearcher()
        {
            InitializeComponent();
        }

        private void PDFSearcher_Load(object sender, EventArgs e)
        {
            if(System.IO.File.Exists("BitMiracle.Docotic.Pdf.dll") == false)
            {
                MessageBox.Show("Errore: il file \"BitMiracle.Docotic.Pdf.dll\" non é presente." +
                    "Tale file é necessario per gestire e manipolare i file PDF." +
                    "Assicurarsi che sia presente nella stessa cartella del programma.", "Errore",
                    MessageBoxButtons.OK);
                Close();
            }
        }

        private void PDFListBox_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(PDFListBox.SelectedItem.ToString());
        }

        private void PDFListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            openFileButton.Enabled = true;
        }

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView.CurrentCell.ColumnIndex == 0) //la cella contiene un nome di file
            {
                System.Diagnostics.Process.Start(dataGridView.CurrentCell.Value.ToString());
            }
        }
    }
}
