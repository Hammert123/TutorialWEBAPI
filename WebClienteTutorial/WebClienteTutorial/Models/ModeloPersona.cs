using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace WebClienteTutorial.Models
{
    public class ModeloPersona
    {
        Uri urlapi;

        MediaTypeWithQualityHeaderValue media;

        public ModeloPersona()
        {
            this.urlapi = new Uri("http://localhost:61576/");
            media = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Persona>> GetPersonas()
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/Tutorial";

                cliente.BaseAddress = this.urlapi;
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(media);

                HttpResponseMessage respuesta = await cliente.GetAsync(peticion);

                if (respuesta.IsSuccessStatusCode)
                {
                    List<Persona> personas = await respuesta.Content.ReadAsAsync<List<Persona>>();

                    return personas;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<Persona> BuscarPersona(int id)
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/Tutorial/" + id;

                cliente.BaseAddress = this.urlapi;
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(media);

                HttpResponseMessage respuesta = await cliente.GetAsync(peticion);

                if (respuesta.IsSuccessStatusCode)
                {
                    Persona persona = await respuesta.Content.ReadAsAsync<Persona>();

                    return persona;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}