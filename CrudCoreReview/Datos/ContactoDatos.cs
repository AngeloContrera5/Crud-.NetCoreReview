using System;
using System.Collections.Generic;
using System.Linq;
using CrudCoreReview.Models;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace CrudCoreReview.Datos
{
    public class ContactoDatos
    {

        public List<ContactoModel> List()
        {
            var oLista = new List<ContactoModel>();

            var cn = new Conexion();

            using(var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_list", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel()
                        {
                            idContacto = Convert.ToInt32(dr["idContacto"]),
                            nomContacto = dr["nomContacto"].ToString(),
                            telContacto = dr["telContacto"].ToString(),
                            correoContacto = dr["correoContacto"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public ContactoModel Get(int idContacto)
        {
            var oContacto = new ContactoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_get", conexion);
                cmd.Parameters.AddWithValue("@IdContacto", idContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.idContacto = Convert.ToInt32(dr["idContacto"]);
                        oContacto.nomContacto = dr["nomContacto"].ToString();
                        oContacto.telContacto = dr["telContacto"].ToString();
                        oContacto.correoContacto = dr["correoContacto"].ToString();
                    }
                }
            }
            return oContacto;
        }

        public bool save(ContactoModel oContacto)
        {
            bool response;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_save", conexion);
                    cmd.Parameters.AddWithValue("@NomContacto", oContacto.nomContacto);
                    cmd.Parameters.AddWithValue("@TelContacto", oContacto.telContacto);
                    cmd.Parameters.AddWithValue("@CorreoContacto", oContacto.correoContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                response = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                response = false;
            }

            return response;
        }

        public bool update(ContactoModel oContacto)
        {
            bool response;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_update", conexion);
                    cmd.Parameters.AddWithValue("@IdContacto", oContacto.idContacto);
                    cmd.Parameters.AddWithValue("@NomContacto", oContacto.nomContacto);
                    cmd.Parameters.AddWithValue("@TelContacto", oContacto.telContacto);
                    cmd.Parameters.AddWithValue("@CorreoContacto", oContacto.correoContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                response = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                response = false;
            }

            return response;
        }

        public bool delete(int idContacto)
        {
            bool response;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_delete", conexion);
                    cmd.Parameters.AddWithValue("@IdContacto", idContacto);                  
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                response = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                response = false;
            }

            return response;
        }

    }
}
