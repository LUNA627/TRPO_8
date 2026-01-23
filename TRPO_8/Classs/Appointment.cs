using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_8.Classs
{
    public class Appointment : INotifyPropertyChanged
    {

        private string _date = DateTime.Today.ToString("dd.MM.yyyy");
        public string Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(); }
        }

        public int DaysSinceAppointment
        {
            get
            {
                if (DateTime.TryParseExact(Date, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out var date))
                    return (DateTime.Today - date).Days;

                return -1; 
            }
        }
        public int DoctorId { get; set; } = 0;
        public string Diagnosis { get; set; } = "";
        public string Recomendations { get; set; } = "";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
