using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitMiracle.Docotic.Pdf;

namespace SearchMultiplePDFFiles
{
    public partial class PDFSearcher : Form
    {
        private void selectPDFfiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPDFFile = new OpenFileDialog()
            {
                Filter = "pdf files (.pdf) | *.pdf",
                Multiselect = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                RestoreDirectory = true
            };

            if (openPDFFile.ShowDialog() == DialogResult.OK)
            {
                //save filenames
                fileNames = openPDFFile.FileNames;

                PDFListBox.Items.AddRange(fileNames);
    
                removeFromSelectionButton.Enabled = true;

            }
        }

        private void pulisciPDFlist_Click(object sender, EventArgs e)
        {
            PDFListBox.Items.Clear();
            removeFromSelectionButton.Enabled = false;
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            foreach (var element in PDFListBox.CheckedItems)
            {
                System.Diagnostics.Process.Start(element.ToString());
            }
        }

        private void removeFromSelectionButton_Click(object sender, EventArgs e)
        {
            Array staticListOfCheckedItems = Array.CreateInstance(typeof(object), PDFListBox.CheckedItems.Count);
            PDFListBox.CheckedItems.CopyTo(staticListOfCheckedItems, 0);

            foreach (var element in staticListOfCheckedItems)
            {
                PDFListBox.Items.Remove(element);
            }
        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            //search each pdf

            searchProgressBar.Maximum = PDFListBox.Items.Count;

            //reset view
            dataGridView.Rows.Clear();

            foreach(var element in PDFListBox.Items)
            {
                var pdfText = new PdfDocument(element.ToString());

                string documentText = pdfText.GetText().Trim();

                //add text to result box
                List<object> list = FindAllOf(documentText, searchTextBox.Text);

                searchProgressBar.Increment(1);

                dataGridView.Rows.Add(element.ToString(), list.ToArray().Length);

                dataGridView.Refresh();

            }

            searchProgressBar.Value = 0; //reset search bar
        }

        private void ClearSearchButton_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
