using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProFactory
    {
        private List<Pro> queryBySql(string sql, List<SqlParameter> paras)
        {
            List<Pro> list = new List<Pro>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source =.; Initial Catalog = OurAstro; Integrated Security = True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (paras != null)
                cmd.Parameters.AddRange(paras.ToArray());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Pro pro = new Pro()
                {
                    pID = (int)reader["mID"],
                    ProID = (int)reader["ProID"],
                    ProName = reader["ProName"].ToString(),
                    ProSex = (bool)reader["ProSex"],
                    ProExperience = reader["ProExperience"].ToString(),
                    ProSkill = reader["ProSkill"].ToString(),
                    ProCost = (int)reader["ProCost"],
                    ProSelect = reader["ProSelect"].ToString(),
                    ProPhone = reader["ProPhone"].ToString(),
                    ProEmail = reader["ProEmail"].ToString(),
                    ProPassword = reader["ProPassword"].ToString(),
                    ProAccount = reader["ProAccount"].ToString(),
                    ProAddress = reader["ProAddress"].ToString()
                };
                list.Add(pro);
            }
            con.Close();
            return list;
        }

        private void executeSql(string sql, List<SqlParameter> paras)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source =.; Initial Catalog = OurAstro; Integrated Security = True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (paras != null)
                cmd.Parameters.AddRange(paras.ToArray());
            cmd.ExecuteNonQuery();
        }

        public void create(Pro p)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            string sql = "insert into ProForm (";
            sql += " ProName,";
            sql += " ProSex,";
            sql += " ProExperience,";
            sql += " ProSkill,";
            sql += " ProCost,";
            sql += " ProSelect,";
            sql += " ProPhone,";
            sql += " ProEmail,";
            sql += " ProPassword";
            sql += " ProAccount,";
            sql += " ProAddress";
            sql += ") values (";
            sql += " @P_PRONAME,";
            sql += " @P_PROSEX,";
            sql += " @P_PROEXPERIENCE,";
            sql += " @P_PROSKILL,";
            sql += " @P_PROCOST,";
            sql += " @P_PROSELECT,";
            sql += " @P_PROPHONE,";
            sql += " @P_PROEMAIL,";
            sql += " @P_PROPASSWORD,";
            sql += " @P_PROACCOUNT,";
            sql += " @P_PROADDRESS) ";

            paras.Add(new SqlParameter("P_PRONAME", p.ProName));
            paras.Add(new SqlParameter("P_PROSEX", p.ProSex));
            paras.Add(new SqlParameter("P_PROEXPERIENCE", p.ProExperience));
            paras.Add(new SqlParameter("P_PROSKILL", p.ProSkill));
            paras.Add(new SqlParameter("P_PROCOST", p.ProCost));
            paras.Add(new SqlParameter("P_PROSELECT", p.ProSelect));
            paras.Add(new SqlParameter("P_PROPHONE", p.ProPhone));
            paras.Add(new SqlParameter("P_PROEMAIL", p.ProEmail));
            paras.Add(new SqlParameter("P_PROPASSWORD", p.ProPassword));
            paras.Add(new SqlParameter("P_PROACCOUNT", p.ProAccount));
            paras.Add(new SqlParameter("P_PROADDRESS", p.ProAddress));
            executeSql(sql, paras);
        }

        public void update(Pro p)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            string sql = "update ProForm set ProName=@P_PRONAME, ProSex=@P_PROSEX, ProExperience=@P_PROEXPERIENCE, ProSkill=@P_PROSKILL, ProCost=@P_PROCOST, ProSelect=@P_PROSELECT, ProPhone=@P_PROPHONE,ProEmail=@P_PROEMAIL, ProPassword=@P_PROPASSWORD, ProAccount=@P_PROACCOUNT, ProAddress=@P_PROADDRESS where pID=@P_PID;";
            paras.Add(new SqlParameter("P_PID", p.pID));
            paras.Add(new SqlParameter("P_PRONAME", p.ProName));
            paras.Add(new SqlParameter("P_PROSEX", p.ProSex));
            paras.Add(new SqlParameter("P_PROEXPERIENCE", p.ProExperience));
            paras.Add(new SqlParameter("P_PROSKILL", p.ProSkill));
            paras.Add(new SqlParameter("P_PROCOST", p.ProCost));
            paras.Add(new SqlParameter("P_PROSELECT", p.ProSelect));
            paras.Add(new SqlParameter("P_PROPHONE", p.ProPhone));
            paras.Add(new SqlParameter("P_PROEMAIL", p.ProEmail));
            paras.Add(new SqlParameter("P_PROPASSWORD", p.ProPassword));
            paras.Add(new SqlParameter("P_PROACCOUNT", p.ProAccount));
            paras.Add(new SqlParameter("P_PROADDRESS", p.ProAddress));
            executeSql(sql, paras);
        }

        public void delete(int pID)
        {
            string sql = "delete from tCustomer where pID=@P_PID";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@P_PID", pID));
            executeSql(sql, paras);
        }
    }
}