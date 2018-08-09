using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Prueba.Models;

namespace Prueba.Controllers
{
    public class CancionController : Controller
    {
        ///String de coneccin a la Base de datos.
        String sqlString = "Data Source=FISICA\\SQLEXPRESS;Initial Catalog=Examen;Integrated Security=SSPI;";

        /// <summary>
        /// Metodo Para listar la tabla Canciones.
        /// </summary>
        /// <returns>Retorna un Objeto de tipo Lista<Cancion> </returns>
        public List<Cancion> Listar()
        {
            List<Cancion> Lista = new List<Cancion>();

            try
            {
                SqlConnection sqlConeccion = new SqlConnection(sqlString);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Cancion", sqlConeccion);
                sqlConeccion.Open();

                using (var ls = sqlCommand.ExecuteReader())
                {
                    while (ls.Read())
                    {
                        Cancion cancion = new Cancion();
                        cancion.Id = Convert.ToInt32(ls["cancionId"]);
                        cancion.nombre = Convert.ToString(ls["nombre"]);
                        Lista.Add(cancion);
                    }



                }
            }
            catch (SqlException t)
            {
                Console.WriteLine("Error en la Coneccion de Base de datos" + t);
            }

            return Lista;
        }

        /// <summary>
        /// Metodo Index que muestra la tabla Canciones.
        /// </summary>
        /// <returns>Retorana una lista de tipo Cancion.</returns>
        public ActionResult Index()
        {
            List<Cancion> listaCancion = new List<Cancion>();
            listaCancion = Listar().ToList();
            return View(listaCancion);
        }

        /// <summary>
        /// Metodo que Inserta una nueva cancion en la tabla.
        /// </summary>
        /// <param name="cancion"></param>
        /// <returns>Retorna una vista.</returns>
        public ActionResult Crear(Cancion cancion)
        {
            try
            {
                SqlConnection sqlConeccion = new SqlConnection(sqlString);
                sqlConeccion.Open();
                SqlCommand sqlCommand = new SqlCommand("EXEC spr_AgregarCancion @p0, @p1;", sqlConeccion);
                sqlCommand.Parameters.AddWithValue("@p0", Convert.ToInt32(cancion.Id));
                sqlCommand.Parameters.AddWithValue("@p1", cancion.nombre);
                sqlCommand.ExecuteNonQuery();
                sqlConeccion.Close();


            }
            catch (SqlException t)
            {
                Console.WriteLine("Error en la Coneccion de Base de datos" + t);
            }

            return View();
        }

        /// <summary>
        /// Metodo para eliminar una Cancion de la Tabla.
        /// </summary>
        /// <param name="cancion"></param>
        /// <returns>Retorna una vista.</returns>
        public ActionResult Eliminar(Cancion cancion)
        {

            try
            {

                SqlConnection con = new SqlConnection(sqlString);
                con.Open();
                SqlCommand consulta = new SqlCommand("DELETE FROM Cancion WHERE ID = @p0;", con);
                consulta.Parameters.AddWithValue("@p0", Convert.ToInt32(cancion.Id));
                consulta.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {


            }

            return View();
        }
    }
}
