using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen.Models;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;

namespace Examen.Controllers
{
    public class PersonaController : Controller
    {


        String conexion = "Data Source=FISICA\\SQLEXPRESS; Initial Catalog=Base1; Integrated Security=true;";

        public List<Persona> Listado()
        {

            List<Persona> Lista = new List<Persona>();

            using (SqlConnection con = new SqlConnection(conexion))
            {

                var select = new SqlCommand("SELECT * FROM Datos", con);
                con.Open();

                using (var ls = select.ExecuteReader())
                {

                    while (ls.Read())
                    {

                        Persona persona = new Persona();
                        persona.ID = Convert.ToInt32(ls["ID"]);
                        persona.Nombre = Convert.ToString(ls["Nombre"]);
                        persona.Apellido = Convert.ToString(ls["Apellido"]);
                        persona.DPI = Convert.ToInt32(ls["DPI"]);
                        persona.Ciudad = Convert.ToString(ls["Ciudad"]);
                        Console.WriteLine("Agregar una Nueva fila");
                        Lista.Add(persona);
                    }
                }
            }

            return Lista;
        }
        public ActionResult Index() 
        {
            List<Persona> listpersona = new List<Persona>();
            listpersona = Listado().ToList();
            return View(listpersona);
        }

        public ActionResult Agregar(Persona persona) {
         
            try
            {
                    SqlConnection con = new SqlConnection(conexion);
                    
                    con.Open();
                    SqlCommand query = new SqlCommand("INSERT INTO Datos(ID,Nombre,Apellido,DPI,Ciudad) VALUES (@p0, @p1, @p2, @p3, @p4);", con);
                    query.Parameters.AddWithValue("@p0", Convert.ToInt32(persona.ID));
                    query.Parameters.AddWithValue("@p1", persona.Nombre);
                    query.Parameters.AddWithValue("@p2", persona.Apellido);
                    query.Parameters.AddWithValue("@p3", Convert.ToInt32(persona.DPI));
                    query.Parameters.AddWithValue("@p4", persona.Ciudad);

                    query.ExecuteNonQuery();
                    con.Close();         
                
            }
            catch (SqlException ex)
            {
                
            
            }

            return View(persona);

        }

        public ActionResult Eliminar(Persona persona) {

            try {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand consulta = new SqlCommand("DELETE FROM Datos WHERE ID = @p0;", con);
                consulta.Parameters.AddWithValue("@p0",Convert.ToInt32(persona.ID));
                consulta.ExecuteNonQuery();
                con.Close();
            }catch(SqlException ex){
            
            
            }

            return View();
        }


        public ActionResult Modificar(Persona persona) {
            try {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand query = new SqlCommand("UPDATE Datos SET Nombre=@p1, Apellido=@p2, DPI=@p3, Ciudad=@p4 WHERE ID=@p0;", con);
                query.Parameters.AddWithValue("@p0", Convert.ToInt32(persona.ID));
                query.Parameters.AddWithValue("@p1", persona.Nombre);
                query.Parameters.AddWithValue("@p2", persona.Apellido);
                query.Parameters.AddWithValue("@p3", Convert.ToInt32(persona.DPI));
                query.Parameters.AddWithValue("@p4", persona.Ciudad);
                query.ExecuteNonQuery();
                con.Close();


            }
            catch (SqlException ex)
            {
            
            }


            return View();        
        }
          
      

    }
}
