﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace MetaSet
{
    public partial class Form1 : Form
    {
        public Form1(string[] args)
        {
            InitializeComponent();
            MetaSet.MainForm = this;
            if (args.Length > 0)
            {
                if (args[0] != "-s")
                {
                    try
                    { 
                        Functions.OpenFile(args[0]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid argument!", "MetaSet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        int a = Convert.ToInt32(args[1]);
                        int b = Convert.ToInt32(args[2]);
                        this.StartPosition = FormStartPosition.Manual;
                        this.Location = new Point(a, b);
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Invalid arguments!", "MetaSet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }    
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions.OpenFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://donationalerts.com/r/emildalalyan");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            Functions.SaveFile();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions.CloseFile();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            MetaSet.File.Tag.Title = this.textBox1.Text;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MetaSet.AboutProgram();
        }

        private void createNewInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MetaSet.CreateInstance();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            Functions.OpenFile(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
        }

        private void playATrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            System.Diagnostics.Process.Start(MetaSet.File.Name);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            MetaSet.File.Tag.AlbumArtists = new string[1] { this.textBox2.Text };
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            MetaSet.File.Tag.Album = this.textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            try
            {
                MetaSet.File.Tag.Year = Convert.ToUInt16(this.textBox4.Text);
            }
            catch(Exception)
            {
                this.textBox4.Text = "";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            
            try { 
                MetaSet.File.Tag.Track = Convert.ToUInt16(this.textBox5.Text);
            }
            catch(Exception)
            {
                this.textBox5.Text = "";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            MetaSet.File.Tag.Genres = new string[1] { this.textBox6.Text };
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            MetaSet.File.Tag.Lyrics = this.textBox7.Text;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            MetaSet.File.Tag.Copyright = this.textBox9.Text;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            MetaSet.File.Tag.Composers = new string[1] { this.textBox8.Text };
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;

            try {
                MetaSet.File.Tag.Disc = Convert.ToUInt16(this.textBox10.Text);
            }
            catch(Exception)
            {
                this.textBox10.Text = "";
            }
        }

        private void extractACoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            Functions.ExtractCover();
        }

        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!Functions.IsOpened()) return;
            switch (e.ClickedItem.Name)
            {
                case "changepict":
                    {
                        Functions.ChangeACover();
                        break;
                    }
                case "dthecov":
                    {
                        Functions.DeleteACover();
                        break;
                    }
                case "copyimg":
                    {
                        Functions.CopyTheCover();
                        break;
                    }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void repositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/emil0911/MetaSet");
        }

        private void copyInformationAboutTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            Functions.CopyInfoAboutTrack();
        }

        private void checkAPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            new TrackProperties().ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            if (Functions.WeMayToGetTag()) ((TagLib.Id3v2.Tag)MetaSet.File.GetTag(TagLib.TagTypes.Id3v2)).SetTextFrame("TCMP", (this.checkBox1.Checked) ? "1" : "0");
            else
            {
                MessageBox.Show("This file doesn't support it.", "MetaSet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            MetaSet.File.Tag.Performers = this.textBox11.Text.Split(',');
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.IsOpened()) return;
            try
            {
                MetaSet.File.Tag.BeatsPerMinute = Convert.ToUInt32(this.textBox12.Text);
            }
            catch(Exception)
            {
                this.textBox12.Text = "";
            }
        }
    }
}