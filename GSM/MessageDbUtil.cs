using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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
            string query = "SELECT * FROM message";
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
                                string sender = dr["sender"].ToString();
                                string code = dr["code"].ToString();
                                messages.Add(new Message(sender, code));
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
                string query = "INSERT INTO message VALUES(@sender, @code);";
                using (SqlConnection conn = new SqlConnection(cnUrl))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.Add("@sender", SqlDbType.VarChar);
                            cmd.Parameters.Add("@code", SqlDbType.VarChar);

                            cmd.Parameters["@sender"].Value = message.Sender;
                            cmd.Parameters["@code"].Value = message.Code;

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
