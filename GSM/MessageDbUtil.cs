using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using GSM.ADO.NETModels;

namespace GSM
{
    class MessageDbUtil
    {
        private static MessageDbUtil instance = null;
        private string cnUrl;

        private MessageDbUtil(string cnUrl)
        {
            this.cnUrl = cnUrl;
        }

        public static MessageDbUtil getInstance(string cnUrl)
        {
            if (instance == null)
            {
                instance = new MessageDbUtil(cnUrl);
            }
            return instance;
        }

        public List<Message> getMessages()
        {
            string query = "SELECT * FROM Messages";
            List<Message> messages = new List<Message>();
            using (SqlConnection conn = new SqlConnection(cnUrl))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                int id = Int32.Parse(dr["Id"].ToString());
                                string sender = dr["Sender"].ToString();
                                string code = dr["Code"].ToString();
                                DateTime dateReceived = Convert.ToDateTime(dr["DateReceived"].ToString());
                                messages.Add(new Message() { Code = code, DateReceived = dateReceived, Id = id, Sender = sender })  ;
                            }
                            return messages;
                        }
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e);
                    conn.Close();
                    return null;
                }
            }
        }

        public void addMessage(Message message)
        {
            try
            {
                string query = "INSERT INTO Messages (Sender, Code, DateReceived) VALUES(@Sender, @Code, @DateReceived);";
                using (SqlConnection conn = new SqlConnection(cnUrl))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.Add("@Sender", SqlDbType.VarChar);
                            cmd.Parameters.Add("@Code", SqlDbType.VarChar);
                            cmd.Parameters.Add("@DateReceived", SqlDbType.DateTime);

                            cmd.Parameters["@Sender"].Value = message.Sender;
                            cmd.Parameters["@Code"].Value = message.Code;
                            cmd.Parameters["@DateReceived"].Value = message.DateReceived;

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        conn.Close();
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine (e);
            }

        }
    }
}
