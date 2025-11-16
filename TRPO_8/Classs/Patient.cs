using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TRPO_8.Classs
{
    public class Patient : INotifyPropertyChanged
    {
        private int _iDPatient = 0;
        public int IDPatient
        {
            get => _iDPatient;
            set
            {
                _iDPatient = value;
                OnPropertyChanged();
            }
        }

        private string _namePatient = "";
        public string NamePatient
        {
            get => _namePatient;
            set
            {
                _namePatient = value;
                OnPropertyChanged();
            }
        }

        private string _lastNamePatient = "";
        public string LastNamePatient
        {
            get => _lastNamePatient;
            set
            {
                _lastNamePatient = value;
                OnPropertyChanged();
            }
        }


        private string _middleNamePatient = "";
        public string MiddleNamePatient
        {
            get => _middleNamePatient;
            set
            {
                _middleNamePatient = value;
                OnPropertyChanged();
            }
        }


        private string _birthdayPatient = "";
        public string BirthdayPatient
        {
            get => _birthdayPatient;
            set
            {
                _birthdayPatient = value;
                OnPropertyChanged();
            }
        }


        private string _phonePatient = "";
        public string PhonePatient
        {
            get => _phonePatient;
            set
            {
                _phonePatient = value;
                OnPropertyChanged();
            }
        }


        private List<Appointment> _appointmentStories = new();
        public List<Appointment> AppointmentStories
        {
            get => _appointmentStories;
            set
            {
                _appointmentStories = value;
                OnPropertyChanged();
            }
        }


        public string FullName => $"{NamePatient} {LastNamePatient} {MiddleNamePatient}".Trim();


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
