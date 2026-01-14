using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TRPO_8.Classs
{
    public class Doctor
    {
        public int IDDoctor { get; set; }
        public string NameDoctor { get; set; } = "";
        public string LastNameDoctor { get; set; } = "";
        public string MiddleNameDoctor { get; set; } = "";
        public string SpecialisationDoctor { get; set; } = "";
        public string PasswordDoctor { get; set; } = "";

        [JsonIgnore]
        public string RepeatPasswordDoctor { get; set; } = "";
    }
}
