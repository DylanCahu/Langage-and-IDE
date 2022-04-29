using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.CodeDom.Compiler;

namespace CodeFicherGraphique
{
    public partial class Form1 : Form
    {

        public string pathFolder = Directory.GetCurrentDirectory();
        public string pathFile = Directory.GetCurrentDirectory() + "\\file.temp";
        public Form1()
        {
            InitializeComponent();

            if (File.Exists(pathFile))
            {
                richTextBox1.LoadFile(pathFile, RichTextBoxStreamType.PlainText);
                textBox1.Text = "Autoload : " + pathFile;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {//open
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = "Open : " + openFileDialog1.FileName;
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {//save

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = "Save : " + saveFileDialog1.FileName;
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        { //Run

            textBox1.Text = "Run : Code ";

            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(pathFile, 1024))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(richTextBox1.Text);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

            //Vide la console actuel
            richTextBox3.Text = " ";

            Parser.Compiler(pathFile);
            // Parser.Compiler(openFileDialog1.FileName);
            // Parser.leProgramme.afficher();
            Parser.leProgramme.executer();


        }
        private bool checkConnection()
        {
            //return ping google.com
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            try
            {
                System.Net.NetworkInformation.PingReply reply = ping.Send("google.com");
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        private void button4_Click(object sender, EventArgs e)
        {//help

            if (checkConnection())
            {
                System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "https://www.youtube.com/watch?v=dQw4w9WgXcQ");
                
            }
            else
            {
                richTextBox3.LoadFile(Directory.GetCurrentDirectory() + "\\..\\help.txt", RichTextBoxStreamType.PlainText);
            }

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void clear() //nettoyer la console
        {
            richTextBox1.Text = " ";
        }
        public void write(string str) //afficher dans la console
        {
            richTextBox1.Text += str;
        }
        public void newLine() //afficher dans la console
        {
            richTextBox1.Text += "\n";
        }
        public void error(string str) //afficher dans la console
        {
            richTextBox1.Text += str + "\n";
        }
        public void writeLn(string str) //afficher dans la console avec un saut de ligne
        {
            newLine();
            write(str);
        }
        public void write2(string str)
        {
            richTextBox3.Text += str + "\n";
        }

        public void writeln2(string str)
        {
            richTextBox3.Text += str + "\n";
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
