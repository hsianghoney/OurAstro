using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MemberFactory
    {
        private List<Member> queryBySql(string sql,List<SqlParameter> paras)
        {
            List<Member> list = new List<Member>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source =.; Initial Catalog = OurAstro; Integrated Security = True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (paras != null)
                cmd.Parameters.AddRange(paras.ToArray());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Member member = new Member()
                {
                    mID = (int)reader["mID"],
                    MemberID = (int)reader["MemberID"],
                    MemberName = reader["MemberName"].ToString(),
                    MemberSex = (bool)reader["MemberSex"],
                    MemberBirth = (DateTime)reader["MemberBirth"],
                    MemberBirthTime = (DateTime)reader["MemberBirthTime"],
                    MemberBirthPlace = reader["MemberBirthPlace"].ToString(),
                    MemberPhone = reader["MemberPhone"].ToString(),
                    MemberEmail = reader["MemberEmail"].ToString(),
                    MemberPWD = reader["MemberPWD"].ToString(),
                    MemberAccount = reader["MemberAccount"].ToString()
                };
                list.Add(member);
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

        public void create(Member m)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            string sql = "insert into MemberForm (";
            sql += " MemberName,";
            sql += " MemberSex,";
            sql += " MemberBirth,";
            sql += " MemberBirthTime,";
            sql += " MemberBirthPlace,";
            sql += " MemberPhone,";
            sql += " MemberEmail,";
            sql += " MemberPWD,";
            sql += " MemberAccount";
            sql += ") values (";
            sql += " @M_MEMBERNAME,";
            sql += " @M_MEMBERSEX,";
            sql += " @M_MEMBERBIRTH,";
            sql += " @M_MEMBERBIRTHTIME,";
            sql += " @M_MEMBERBIRTHPLACE,";
            sql += " @M_MEMBERPHONE,";
            sql += " @M_MEMBEREMAIL,";
            sql += " @M_MEMBERPWD), ";
            sql += " @M_MEMBERACCOUNT) ";

            paras.Add(new SqlParameter("M_MEMBERNAME", m.MemberName));
            paras.Add(new SqlParameter("M_MEMBERSEX", m.MemberSex));
            paras.Add(new SqlParameter("M_MEMBERBIRTH", m.MemberBirth));
            paras.Add(new SqlParameter("M_MEMBERBIRTHTIME", m.MemberBirthTime));
            paras.Add(new SqlParameter("M_MEMBERBIRTHPLACE", m.MemberBirthPlace));
            paras.Add(new SqlParameter("M_MEMBERPHONE", m.MemberPhone));
            paras.Add(new SqlParameter("M_MEMBEREMAIL", m.MemberEmail));
            paras.Add(new SqlParameter("M_MEMBERPWD", m.MemberPWD));
            paras.Add(new SqlParameter("M_MEMBERACCOUNT", m.MemberAccount));
            executeSql(sql, paras);
        }

        public void update(Member m)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            string sql = "update MemberForm set MemberName=@M_MEMBERNAME, MemberSex=@M_MEMBERSEX, MemberBirth=@M_MEMBERBIRTH, MemberBirthTime=@M_MEMBERBIRTHTIME, MemberBirthPlace=@M_MEMBERBIRTHPLACE, MemberPhone=@M_MEMBERPHONE, MemberEmail=@M_MEMBEREMAIL, MemberPWD=@M_MEMBERPWD where mID=@M_MID;";
            paras.Add(new SqlParameter("M_MID", m.mID));
            paras.Add(new SqlParameter("M_MEMBERNAME", m.MemberName));
            paras.Add(new SqlParameter("M_MEMBERSEX", m.MemberSex));
            paras.Add(new SqlParameter("M_MEMBERBIRTH", m.MemberBirth));
            paras.Add(new SqlParameter("M_MEMBERBIRTHTIME", m.MemberBirthTime));
            paras.Add(new SqlParameter("M_MEMBERBIRTHPLACE", m.MemberBirthPlace));
            paras.Add(new SqlParameter("M_MEMBERPHONE", m.MemberPhone));
            paras.Add(new SqlParameter("M_MEMBEREMAIL", m.MemberEmail));
            paras.Add(new SqlParameter("M_MEMBERPWD", m.MemberPWD));
            paras.Add(new SqlParameter("M_MEMBERACCOUNT", m.MemberAccount));

            executeSql(sql, paras);
        }

        public void delete(int mID)
        {
            string sql = "delete from tCustomer where mID=@K_MID";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@K_MID", mID));
            executeSql(sql, paras);
        }
    }
}