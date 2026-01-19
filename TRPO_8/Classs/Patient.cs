using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TRPO_8.Classs
{
    public class Patient : INotifyPropertyChanged
    {
        private int _iDPatient;
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
                OnPropertyChanged(nameof(FullName));
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
                OnPropertyChanged(nameof(FullName));
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
                OnPropertyChanged(nameof(FullName));
            }
        }


        private DateTime? _birthdayPatient;

        [JsonIgnore]
        public DateTime? BirthdayPatient
        {
            get => _birthdayPatient;
            set
            {
                _birthdayPatient = value;
                OnPropertyChanged();
            }
        }

        [JsonPropertyName("Birthday")]
        public string BirthdayJson
        {
            get => _birthdayPatient?.ToString("dd.MM.yyyy") ?? "";
            set
            {
                if (DateTime.TryParseExact(value, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out var date))
                {
                    _birthdayPatient = date;
                }
                else 
                {
                    _birthdayPatient = null;
                }
                OnPropertyChanged(nameof(BirthdayPatient));
            }
        }

        private DateTime? _lastAppointmentDate;

        public DateTime? LastAppointmentDate
        {
            get
            {
                if (AppointmentStories == null || !AppointmentStories.Any())
                    return null;

                return AppointmentStories.OrderByDescending(a => a.DateAppointment).FirstOrDefault()?.DateAppointment;
            }
        }


        private string _phonePatient = "";
        public string PhonePatient
        {
            get => _phonePatient;
            set
            {
                _phonePatient = new string(value.Where(char.IsDigit).ToArray());
                OnPropertyChanged();    
            }
        }


    



        private ObservableCollection<Appointment> _appointmentStories = new();
        public ObservableCollection<Appointment> AppointmentStories
        {
            get => _appointmentStories;
            set
            {
                _appointmentStories = value;


                _appointmentStories = value ?? new ObservableCollection<Appointment>();
                _appointmentStories.CollectionChanged += OnAppointmentStoriesChanged;
                OnPropertyChanged();
                OnPropertyChanged(nameof(LastAppointmentDate));
            }
        }

        private void OnAppointmentStoriesChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(LastAppointmentDate));
        }


        public string FullName => $"{NamePatient} {LastNamePatient} {MiddleNamePatient}".Trim();



        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
