using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are You Sure Your Want to Quit");
            
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rec.Text = File.ReadAllText(openFileDialog.FileName);
            }*/
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|All Files (*.*)|*.*",
                Title = "Open File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Determine file type and load content
                if (Path.GetExtension(filePath).ToLower() == ".rtf")
                {
                    rec.LoadFile(filePath, RichTextBoxStreamType.RichText);
                }
                else
                {
                    rec.Text = File.ReadAllText(filePath);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, rec.Text);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rec.SelectedText.Length > 0)
            {
                rec.Cut();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Do you want to save changes to the current file?",
        "Save File",
        MessageBoxButtons.YesNoCancel,
        MessageBoxIcon.Warning);

            // Handle the user's choice
            if (result == DialogResult.Yes)
            {
                // Save the file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|All Files (*.*)|*.*",
                    Title = "Save File"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Save based on file type
                    if (Path.GetExtension(filePath).ToLower() == ".rtf")
                    {
                        rec.SaveFile(filePath, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        File.WriteAllText(filePath, rec.Text);
                    }
                }

                // Clear the editor for the new file
                rec.Clear();
            }
            else if (result == DialogResult.No)
            {
                // Just clear the editor for the new file
                rec.Clear();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, rec.Text);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rec.SelectedText.Length > 0)
            {
                rec.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                rec.Paste();
            }
        }




       
    

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rec.CanUndo)
            {
                rec.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rec.CanRedo)
            {
                rec.Redo();
            }
        }

    }
}
