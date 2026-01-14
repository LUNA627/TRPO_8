using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TRPO_8.Classs;

namespace TRPO_8.Data
{
    public class DataWork
    {
        private readonly Dictionary<int, Doctor> _doctors = [];

        private readonly Random rand = new();
        private HashSet<int> _patientId = new();

        public DataWork()
        {
            LoadAllDoctors();
        }

        private void LoadAllDoctors()
        {
            _doctors.Clear();

            string[] filesDoctor = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "D_*.json");

            foreach (string file in filesDoctor)
            {
                string jsonFileRead = File.ReadAllText(file);
                Doctor? doctor = JsonSerializer.Deserialize<Doctor>(jsonFileRead);

                if (doctor != null)
                {
                    _doctors[doctor.IDDoctor] = doctor;
                }
            }
        }


        public void SaveDoctor(Doctor doctor)
        {

            doctor.IDDoctor = GenDoctorId();

            string filePath = $"D_{doctor.IDDoctor}.json";
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            string jsonFileWrite = JsonSerializer.Serialize(doctor, options);
            File.WriteAllText(filePath, jsonFileWrite);
            _doctors[doctor.IDDoctor] = doctor;

            LoadAllDoctors();
        }


        public bool CheckDoctorLogin(int id, string password)
        {
            if (_doctors.TryGetValue(id, out Doctor? doctor))
            {
                if (doctor.PasswordDoctor == password)
                {
                    return true;
                }
            }
            return false;
        }


        public Doctor? GetDoctorById(int id)
        {
            return _doctors.GetValueOrDefault(id);
        }



        public int GenDoctorId()
        {
            int min = 10000;
            int max = 100000;

            int idDoctor;
            do
            {
                idDoctor = rand.Next(min, max);
            }
            while (_doctors.ContainsKey(idDoctor));

            return idDoctor;
        }



        public void SavePatient(Patient patient)
        {
            patient.IDPatient = GenPatientId();

            string filePath = $"P_{patient.IDPatient}.json";
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string jsonFileWriter = JsonSerializer.Serialize(patient, options);
            File.WriteAllText(filePath, jsonFileWriter);

        }



        public void SavePatientNoId(Patient patient)
        {

            string filePath = $"P_{patient.IDPatient}.json";
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string jsonFileWriter = JsonSerializer.Serialize(patient, options);
            File.WriteAllText(filePath, jsonFileWriter);
        }





        public Patient LoadPatientId(int idPatient)
        {
            string filePath = $"P_{idPatient}.json";

            string jsonFileRead = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Patient>(jsonFileRead);

        }

        public List<Patient> LoadAllPatients()
        {
            var patients = new List<Patient>();
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "P_*.json");
            foreach (string file in files)
            {
                string json = File.ReadAllText(file);
                Patient? patient = JsonSerializer.Deserialize<Patient>(json);
                if (patient != null)
                {
                    patients.Add(patient);
                }
            }
            return patients;
        }


        public int GenPatientId()
        {
            int min = 1000000;
            int max = 10000000;

            int idPatient;
            do
            {
                idPatient = rand.Next(min, max);
            }
            while (_patientId.Contains(idPatient));

            return idPatient;
        }



        public void DeletePatient(int patientId)
        {
            string fileName = $"P_{patientId}.json";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            File.Delete(filePath);

        }




        public int CountFileDoctor()
        {
            string[] filePath = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, $"D_*.json");
            return filePath.Length;
        }

        public int CountFilePatient()
        {
            string[] filePath = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "P_*.json");
            return filePath.Length;
        }

    }
}
