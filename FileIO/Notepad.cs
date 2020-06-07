using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace FileIO
{
    public partial class Notepad : Form
    {
        FileOperations file;
        SpeechSynth speech;

        public Notepad()
        {
            InitializeComponent();
            file = new FileOperations();
            if (textBox1.WordWrap==true)
            {
                wordWrapToolStripMenuItem.Checked = true;
            }
            else
            {
                wordWrapToolStripMenuItem.Checked = false;
            }
            


        }

        

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show("A Simple NotePad By\nAurojit Das", "About", buttons, MessageBoxIcon.Information);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file.checkFilePathExists())
            {
                file.writeFileBylines(textBox1.Lines); 
            }
            else
            {
                SaveFileDialog saveFile = new SaveFileDialog()
                {
                    Title = "Save",
                    DefaultExt = "txt",
                    Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",                  
                    CheckPathExists = true
                };
                saveFile.ShowDialog();
                file.setPath(saveFile.FileName);

                if (file.checkFilePathExists())
                {
                    file.writeFileBylines(textBox1.Lines);
                }

            }

        }

        private void OpenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog browse = new System.Windows.Forms.OpenFileDialog
            {
                Title = "Open",
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                CheckFileExists = true,
                CheckPathExists = true
            };
            
            browse.ShowDialog();

            file.setPath(browse.FileName);

            try
            {
                if (file.checkFilePathExists())
                {
                    textBox1.Lines = file.readFileBylines();
                    this.Text = "Notepad - "+file.getFilePath();
                    
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
           
        }

        private void WordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked==true)
            {
                textBox1.WordWrap = false;
                wordWrapToolStripMenuItem.Checked = false;
            }
            else
            {
                textBox1.WordWrap = true;
                wordWrapToolStripMenuItem.Checked = true;
            }
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FontForm fontBox = new FontForm(this);
            fontBox.Show();

            

        }


        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (speech==null)
            {
                speech = new SpeechSynth();
            }

          
            if (textBox1.Text=="")
            {
                speech.startReading("No Text Selected.");
            }
            else
            {               
                speech.startReading(textBox1.Text);
            }
           
        }

        private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            speech.pauseOrResume();
        }

        private void ResumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            speech.resume();
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            speech.stop();
        }
    }
}
