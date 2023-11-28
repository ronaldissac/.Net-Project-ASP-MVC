using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using CustomerPortal.Models;
using System.Data.SqlClient;

namespace CustomerPortal.Models
{
    public class Home : Customer
    {
        public List<Customer> GetDetails(string id)
        { 
            List<Customer> CustomerDetails = new List<Customer>();
            try
            {
                using (SqlConnection connection = new SqlConnection(server))
                {
                    string query = "SELECT CustomerName,CustomerEmail,CustomerPhone FROM Customer WHERE CustomerId ='" +id+"'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Customer customerList = new Customer
                        {
                            CustomerName = reader["CustomerName"].ToString(),
                            CustomerEmail = reader["CustomerEmail"].ToString(),
                            CustomerPhone = reader["CustomerPhone"].ToString(),
                            CustomerId = id,
                        };
                        CustomerDetails.Add(customerList);
                       
                    }
                    connection.Close();

                }
            } catch (Exception) 
            {
                return null;
            }
            return CustomerDetails;
        }    
        
    }
}