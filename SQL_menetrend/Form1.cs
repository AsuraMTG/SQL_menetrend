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
        public readonly struct Fraction
        {
            private readonly int num;
            private readonly int den;

            public Fraction(bool v1, bool v2) : this()
            {
                V1 = v1;
                V2 = v2;
            }

            public bool V1 { get; }
            public bool V2 { get; }

            public static Fraction operator <(Fraction a, Fraction b)
            {
                return new Fraction(a.num < b.num, a.den < b.den);
            }

            public static Fraction operator >(Fraction a, Fraction b)
            {
                return new Fraction(a.num > b.num, a.den > b.den);
            }
        }
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


        Dictionary<string, string> kikotő = new Dictionary<string, string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            hajó hajok = new hajó();
            List<hajó> menetrend = new List<hajó>();

            StreamReader olvas = new StreamReader("menetrendmod.txt");

            // a e  n
            //   L E A N
            // 1 2 3 4 5
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

            }
            for (int i = 0; i < menetrend.Count; i++)
            {
                if (menetrend[i].járat == "J1")
                {
                    //label1.Text += "\n" + hajok.ToString();
                }
            }
            //balatonfuredrol indulo hajojaratok 11:30 12:30
            //List<string> beerkezokSzama = new List<string>();
            Dictionary<string, int> beerkezokSzama = new Dictionary<string, int>();


            for (int i = 0; i < menetrend.Count; i++)
            {
                if (!beerkezokSzama.Keys.Contains(menetrend[i].hova))
                {
                    beerkezokSzama.Add(menetrend[i].hova, 0);
                }
            }
            label2.Text = "";
            for (int i = 0; i < menetrend.Count; i++)
            {
                if (beerkezokSzama.ContainsKey(menetrend[i].hova))
                {
                    


                }
            }

            for (int i = 0; i < beerkezokSzama.Count; i++)
            {
                //label2.Text += $"\n{beerkezokSzama[i][i]}";
            }


            for (int i = 0; i < menetrend.Count; i++)
            {
                if (menetrend[i].honnan == "Balatonfüred" && menetrend[i].indul.óra >= 11 && menetrend[i].indul.óra <= 12)
                {
                    label1.Text += "\n" + menetrend[i].honnan + " " + menetrend[i].hova  + " "+ menetrend[i].indul.óra + ":" + menetrend[i].indul.perc;
                }
            }

            //string[] beerkezokSzama = new string[menetrend.Count];
            

        }
    }
}
