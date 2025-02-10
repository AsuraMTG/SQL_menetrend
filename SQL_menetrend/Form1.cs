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

namespace SQL_menetrend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public struct Idő
        {
            public int óra;
            public int perc;

            
        }
        public struct hajó
        {
            public string járat;
            public string honnan;
            public string hova;
            public Idő indul;
            public Idő érkezik;
            public override string ToString()
            {
                return járat + " " + honnan + " " + hova + " " + indul.óra + ":" + indul.perc + " " + érkezik.óra + ":" + érkezik.perc; 
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            hajó hajok = new hajó();
            List<hajó> menetrend = new List<hajó>();

            StreamReader olvas = new StreamReader("menetrendmod.txt");

            string elso;
            string[] resz;

            while (!olvas.EndOfStream)
            {
                string[] idopont;
                string[] idopont2;
                elso = olvas.ReadLine();
                
                resz = elso.Split(';');

                hajok.járat = resz[0];
                hajok.honnan = resz[1];
                hajok.hova = resz[2];

                idopont = resz[3].Split(':');
                hajok.indul.óra = Convert.ToInt32(idopont[0]);
                hajok.indul.perc = Convert.ToInt32(idopont[1]);

                idopont2 = resz[4].Split(':');
                hajok.érkezik.óra = Convert.ToInt32(idopont2[0]);
                hajok.érkezik.perc = Convert.ToInt32(idopont2[1]);

                menetrend.Add(hajok);

                for (int i = 0; i < menetrend.Count; i++)
                {
                    if (menetrend[i].járat == "J1")
                    {
                        label1.Text += "\n" + hajok.ToString();
                    }
                }
                
            }
        }
    }
}
