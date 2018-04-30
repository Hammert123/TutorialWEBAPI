using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClienteTutorial.Models
{
    public class Persona
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("NOMBRE")]
        public String Nombre { get; set; }
        [JsonProperty("APELLIDO")]
        public String Apellido { get; set; }
    }
}