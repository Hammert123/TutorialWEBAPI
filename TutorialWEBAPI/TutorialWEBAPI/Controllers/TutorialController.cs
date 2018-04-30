using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using TutorialWEBAPI.Models;

namespace TutorialWEBAPI.Controllers
{
    public class TutorialController : ApiController
    {
        String cadenaconexion;

        public TutorialController()
        {
            //CADENA DE CONEXIÓN PARA ACCEDER A LA BBDD ALOJADA EN AZURE
            cadenaconexion = @"Data Source=sqltajamarmmp1.database.windows.net;Initial Catalog=WebAPITutorial;User ID=;Password=";
        }

        [HttpGet]
        // GET: api/Tutorial
        public List<Persona> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexion;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM PERSONAS";
            sqlCmd.Connection = myConnection;

            myConnection.Open();
            reader = sqlCmd.ExecuteReader();

            List<Persona> personas = new List<Persona>();

            while (reader.Read())
            {
                Persona per = new Persona();

                per.Id = Convert.ToInt32(reader.GetValue(0));
                per.Nombre = reader.GetValue(1).ToString();
                per.Apellido = reader.GetValue(2).ToString();

                personas.Add(per);
            }

            myConnection.Close();

            return personas;
        }

        [HttpGet]
        // GET: api/Tutorial/5
        public Persona Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexion;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM PERSONAS WHERE ID=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            Persona per = null;

            while (reader.Read())
            {
                per = new Persona();

                per.Id = Convert.ToInt32(reader.GetValue(0));
                per.Nombre = reader.GetValue(1).ToString();
                per.Apellido = reader.GetValue(2).ToString();
            }

            myConnection.Close();

            return per;

        }
    }
}
