using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_8.Classs
{
    public class Appointment
    {
        public string Date { get; set; } = DateTime.Today.ToString("dd.MM.yyyy");
        public int DoctorId { get; set; } = 0;
        public string Diagnosis { get; set; } = "";
        public string Recomendations { get; set; } = "";
    }
}
