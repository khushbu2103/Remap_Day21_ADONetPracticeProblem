using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Remap_Day21_ADONetPracticeProblem
{
    public class Customer
    {
        public static  SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=CustomerServiceDB;Integrated Security=True");

        public static void InsertData()
        {
            try
            {
                CustomerDetails customer = new CustomerDetails();
                Console.WriteLine("Enter Name : ");
                customer.Customer_Name = Console.ReadLine();
                Console.WriteLine("Enter Phone Number : ");
                customer.Phone = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Address : ");
                customer.Address = Console.ReadLine();
                Console.WriteLine("Enter Country : ");
                customer.Country = Console.ReadLine();
                Console.WriteLine("Enter Salary : ");
                customer.Salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Pincode : ");
                customer.Pincode = Convert.ToInt32(Console.ReadLine());
                sqlConnection.Open();
                string query = "insert into Customer values('" + customer.Customer_Name + "'," + customer.Phone + ",'" + customer.Address + "','" + customer.Country + "'," + customer.Salary + "," + customer.Pincode + ")";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                Console.WriteLine("Inserted Data Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error is :" + e.Message);
            }
        }
        public static void GetAllCustomerDetails()
        {
            try
            {
                //Customer model = new Customer();
                // SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                string query = "select * from Customer";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        int Customer_Id = sqlReader.GetInt32(0);
                        string Customer_Name = sqlReader.GetString(1);
                        long phone = sqlReader.GetInt64(2);
                        string Address = sqlReader.GetString(3);
                        string Country = sqlReader.GetString(4);
                        long Salary = sqlReader.GetInt64(5);
                        long Pincode = sqlReader.GetInt64(6);

                        Console.WriteLine($"{Customer_Id}\t\t{Customer_Name}\t{phone}\t{Address}\t{Country}\t{Salary}\t{Pincode}");
                    }
                }
                else
                {
                    Console.WriteLine("No customer data are present ");
                }
                sqlReader.Close();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error is : " + e.Message);
            }

        }
        public static void DeleteData()
        {
            try
            {
                sqlConnection.Open();
                string query = "delete from Customer Where Customer_Name='Thia'";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data is Deleted From Table");
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error is : " + e.Message);
            }
        }
        public static void UpdateData()
        {
            try
            {
                sqlConnection.Open();
                string query = "Update Customer Set Salary = 70000 Where Customer_Name='Khushi'";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data is Updated");
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error is : " + e.Message);
            }
        }
    } 
}
