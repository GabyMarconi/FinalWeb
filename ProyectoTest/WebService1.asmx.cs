using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProyectoTest
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string RegistrarDetalleTarjeta(int idCompra, string tipoTarjeta, string nombreTitular, string numeroTarjeta, string vigencia, string cvv)
        {
            try
            {
                // Validación básica
                if (string.IsNullOrEmpty(tipoTarjeta) || string.IsNullOrEmpty(nombreTitular) ||
                    string.IsNullOrEmpty(numeroTarjeta) || string.IsNullOrEmpty(vigencia) ||
                    string.IsNullOrEmpty(cvv))
                {
                    return "Error: Todos los campos son obligatorios.";
                }

                // Solo almacenar los últimos 4 dígitos del número de tarjeta por seguridad
                string ultimosDigitos = numeroTarjeta.Substring(numeroTarjeta.Length - 4);

                // Conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(ProyectoTest.Logica.Conexion.CN))
                {
                    connection.Open();

                    string query = "INSERT INTO DETALLE_TARJETA (IdCompra, TipoTarjeta, NombreTitular, NumeroTarjeta, Vigencia, FechaRegistro) " +
                                   "VALUES (@IdCompra, @TipoTarjeta, @NombreTitular, @NumeroTarjeta, @Vigencia, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdCompra", idCompra);
                        cmd.Parameters.AddWithValue("@TipoTarjeta", tipoTarjeta);
                        cmd.Parameters.AddWithValue("@NombreTitular", nombreTitular);
                        cmd.Parameters.AddWithValue("@NumeroTarjeta", ultimosDigitos);
                        cmd.Parameters.AddWithValue("@Vigencia", vigencia);

                        cmd.ExecuteNonQuery();
                    }
                }

                return "Detalle de tarjeta registrado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al registrar detalle de tarjeta: " + ex.Message;
            }
        }
    }
}
