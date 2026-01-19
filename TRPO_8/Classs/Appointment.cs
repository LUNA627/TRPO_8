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

        private DateTime _dateAppointment;
        public DateTime DateAppointment
        {
            get => _dateAppointment;
            set { _dateAppointment = value; OnPropertyChanged(); }
        }
        public int DoctorId { get; set; } = 0;
        public string Diagnosis { get; set; } = "";
        public string Recomendations { get; set; } = "";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
