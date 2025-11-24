using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KvizGenerator
{
    internal class kerdesek
    {
        public string KerdesTipus { get; set; }
        public string KerdesLeiras { get; set; }
        public string Valasz1 { get; set; }
        public string Valasz2 { get; set; }
        public string Valasz3 { get; set; }
        public string Valasz4 { get; set; }
        public int HelyesValasz { get; set; }
        public kerdesek(string x)
        {
            string[] temp = x.Split(';');
            KerdesTipus = temp[0];
            

            if (temp[0].ToUpper() == "I/H")
            {
                KerdesLeiras = "Igaz vagy hamis? \n"+ temp[1];
                Valasz1 = "Igaz";
                Valasz2 = "Hamis";
                Valasz3 = null;
                Valasz4 = null;
                HelyesValasz = int.Parse(temp[2].Trim());
            }
            else
            {
                KerdesLeiras = temp[1];
                Valasz1 = temp[2];
                Valasz2 = temp[3];
                Valasz3 = temp[4];
                Valasz4 = temp[5];
                HelyesValasz = int.Parse(temp[6].Trim());
            }

        }
    }
}
