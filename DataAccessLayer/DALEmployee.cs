using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class DALEmployee
    {
        public static List<EntityEmployee> EmployeeList()
        {
            List<EntityEmployee> values = new List<EntityEmployee>();
            SqlCommand cmd1 = new SqlCommand("Select * from TBLBILGI", Connection.conn);
            if (cmd1.Connection.State != System.Data.ConnectionState.Open)
            {
                cmd1.Connection.Open();
            }
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                EntityEmployee emp = new EntityEmployee();
                emp.Id = int.Parse(dr["ID"].ToString());
                emp.Ad = dr["AD"].ToString();
                emp.Soyad = dr["SOYAD"].ToString();
                emp.Sehir = dr["SEHIR"].ToString();
                emp.Gorev = dr["GOREV"].ToString();
                emp.Maas = Convert.ToInt32(dr["MAAS"]);
                values.Add(emp);
            }
            dr.Close();
            return values;
        }

        public static int AddEmployee(EntityEmployee emp)
        {
            SqlCommand cmd2 = new SqlCommand("insert into TBLBILGI (AD,SOYAD,SEHIR,GOREV,MAAS) values (@p1,@p2,@p3,@p4,@p5)", Connection.conn);
            if (cmd2.Connection.State != System.Data.ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }
            cmd2.Parameters.AddWithValue("@p1", emp.Ad);
            cmd2.Parameters.AddWithValue("@p2", emp.Soyad);
            cmd2.Parameters.AddWithValue("@p3", emp.Sehir);
            cmd2.Parameters.AddWithValue("@p4", emp.Gorev);
            cmd2.Parameters.AddWithValue("@p5", emp.Maas);
            return cmd2.ExecuteNonQuery();
        }

        public static bool DeleteEmployee(int emp)
        {
            SqlCommand cmd3 = new SqlCommand("Delete from TBLBILGI where ID=@p1", Connection.conn);
            if (cmd3.Connection.State != System.Data.ConnectionState.Open)
            {
                cmd3.Connection.Open();
            }
            cmd3.Parameters.AddWithValue("@p1", emp);
            return cmd3.ExecuteNonQuery() > 0;
        }

        public static bool UpdateEmployee(EntityEmployee emp)
        {
            SqlCommand cmd = new SqlCommand("update TBLBILGI set AD=@P1 , SOYAD = @P2 , SEHIR = @P3 , GOREV = @P4 , MAAS = @P5 WHERE ID=@P6", Connection.conn);
            if (cmd.Connection.State != System.Data.ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            cmd.Parameters.AddWithValue("@P1", emp.Ad);
            cmd.Parameters.AddWithValue("@P2", emp.Soyad);
            cmd.Parameters.AddWithValue("@P3", emp.Sehir);
            cmd.Parameters.AddWithValue("@P4", emp.Gorev);
            cmd.Parameters.AddWithValue("@P5", emp.Maas);
            cmd.Parameters.AddWithValue("@P6", emp.Id);

            return cmd.ExecuteNonQuery() > 0;

        }
    }
}
