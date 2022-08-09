using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medicalclinic_back
{
    public class Calendar
    {
        private int id;
        private string date;
        private string time;

        public int Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string Time { get => time; set => time = value; }


    }
}
