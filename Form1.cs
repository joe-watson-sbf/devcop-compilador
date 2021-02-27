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

namespace devcop
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        string referenciaArchivo, lineaActual;

        public Form1()
        {
            InitializeComponent();
            inputConsola.Hide();
            inputArchivo.Show();
            listBox1.Hide();

            this.Width = 845;
            this.Height = 486;
        }

        // Boton para cerrar la app
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // La opción "CARGAR POR CONSOLA "
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked)// SI EL USUARIO ELIGE ESA OPCIÓN, ENTONCES CAMBIAMOS LA GRAFICA
            {
                inputConsola.Show();
                inputArchivo.Hide();
                inputArchivo.ResetText();

                this.Width = 845;
                this.Height = 486;
                btnCarga.Location = new Point(336, 333);
                panel3.Location = new Point(39, 498);
            }
            
        }

        // La opción "CARGAR POR ARCHIVO "

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked) // SI EL USUARIO ELIGE ESA OPCIÓN, ENTONCES CAMBIAMOS LA GRAFICA
            {
                btnCarga.Location = new Point(656, 10);
                this.Width = 845;
                this.Height = 486;
                inputArchivo.Show();
                inputConsola.Hide();
                this.Location = new Point(537, 277);
            }
            
        }


        // button CARGAR
        /*
         * Ese buton va hacer 2 trabajos diferentes
         * 1° - Cuando el usuario montar un archivo, entonces ejecuta el metodo "openfile"
         * 2° - Si el usuario ingresa datos por consola, ejecuta el metodo "readconsole" 
         */
        private void btnCarga_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                onpenfile();
                inputArchivo.Text = referenciaArchivo;
                if (inputArchivo.Text.Length > 0)
                {
                    panel3.Location = new Point(145, 165);
                    listBox1.Show();
                }
            }
            else if(radioButton2.Checked)
            {

                readconsole();

                this.Width = 845; this.Height = 778;
                listBox1.Show();
                this.Location = new Point(537, 177);
                panel3.Location = new Point(142, 484);
            }
            else
            {
                MessageBox.Show("Por favor selecciona una opción", "DEV COP",MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            
        }



       
        /*
         * METODO PARA ABRIR EL ARCHIVO
         */
        private void onpenfile()
        {
            try
            {
                openFileDialog.Filter = "Text Files(.txt)| *.txt"; // mostrarme solo los archivos .txt
                listBox1.Items.Clear();
                // OpenFileDialog.ShowDialog() nos ayuda a abrir una ventana para buscar el archivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    referenciaArchivo = openFileDialog.FileName; // obtener la referencia del archivo
                    StreamReader streamReader = new StreamReader(referenciaArchivo);  // leer el archivo
                    int contador = 1; // un contador que me permite a imprimir el numero de cada linea de texto del archivo
                    while (true)
                    {
                        lineaActual = streamReader.ReadLine(); // retorna la linea actual
                        listBox1.Items.Add(contador + "->" + lineaActual); // imprimir en el formato requerido : Numero de la linea con los datos

                        if (streamReader.EndOfStream) // si termina de leer el archivo completamente, parame el Stream y dale un break al Bucle While
                        {
                            streamReader.Close();
                            break;
                        }
                        contador++;
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Se ocurre un error...\nIntente de nuevo!", "DEV COP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /*
        * METODO PARA LEER LA ENTRADA POR CONSOLA
        */
        private void readconsole()
        {
            listBox1.Items.Clear();
            string[] data = inputConsola.Text.Split('\n');
            int contador = 1;
            foreach( string lineaActual in data)
            {
                listBox1.Items.Add(contador + "->" + lineaActual); // imprimir en el formato requerido : Numero de la linea con los datos
                contador++;
            }
        }
    }
}
