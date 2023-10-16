using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerPortal.Models
{
    public class Customer
    {
         public  string server = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerId { get; set; }
        public string CustomerPassword { get; set; }
      
      public List<Customer> NewCustomer()
       {

                return new List<Customer>();
       }
        public bool Validation()
        {
            try
            {
                bool isValid = false;
                using (SqlConnection connection = new SqlConnection(server))
                {
                    SqlCommand command = new SqlCommand("ValidateCustomer", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@customerid", CustomerId);
                    command.Parameters.AddWithValue("@customerpass", CustomerPassword);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isValid = (bool)reader["IsValid"];
                            
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                    connection.Close();
                    if (isValid is true)
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
               
               
               
            } 
            catch (Exception ex)
            {
                return false;
            }
               
              
       }
        
    }
}