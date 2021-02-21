using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace BlogManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public bool AddBlog(Blog b)
        {


            SqlConnection cnn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=blogmanagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "insert into blog(title,description,dateofupload) values (@title,@description,@dateofupload)";
            SqlParameter para = new SqlParameter("@title", b.Title);
            SqlParameter para1 = new SqlParameter("@description", b.Description);
            SqlParameter para2 = new SqlParameter("@dateofupload", b.DateOfUpload);

            cmd.Parameters.Add(para);
            cmd.Parameters.Add(para1);
            cmd.Parameters.Add(para2);
           
            cnn.Open();
            int reader = cmd.ExecuteNonQuery();
            cnn.Close();
            if (reader == 0)
            {
                return false;
            }
            return true;
        }

        public bool DeleteBlog(int id)
        {

            SqlConnection cnn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=blogmanagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "delete from blog where id=@id";
            SqlParameter para = new SqlParameter("@id", id);

            cmd.Parameters.Add(para);
            cnn.Open();
            int reader = cmd.ExecuteNonQuery();
            cnn.Close();
            if (reader == 0)
            {
                MyException m = new MyException();
                m.Reason = "No record found with given ID";
                throw new FaultException<MyException>(m);
            }
            return true;
            
 
        }

        public DataSet GetAllBlog()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from blog",
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=blogmanagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            DataSet ds = new DataSet();
            da.Fill(ds, "blog");
            return ds;
        }

        public Blog GetBlog(int id)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=blogmanagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select * from blog where id=@id";
            SqlParameter p = new SqlParameter("@id", id);
            cmd.Parameters.Add(p);
            cnn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Blog b = new Blog();
            if (reader.Read())
            {
                b.ID = reader.GetInt32(0);
                b.Title = reader.GetString(1);
                b.Description = reader.GetString(2);
                b.DateOfUpload = reader.GetDateTime(3);

            }
            else
            {
                MyException m = new MyException();
                m.Reason = "No record found with given ID";
                throw new FaultException<MyException>(m);
            }
            reader.Close();
            cnn.Close();
            return b;
        }

        public Blog UpdateBlog(Blog b)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=blogmanagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "update blog set title=@title,description=@description,dateofupload=@dateofupload where id=@id";
            
            SqlParameter para = new SqlParameter("@id", b.ID);
            SqlParameter para1 = new SqlParameter("@title", b.Title);
            SqlParameter para2 = new SqlParameter("@description", b.Description);
            SqlParameter para3 = new SqlParameter("@dateofupload", b.DateOfUpload);

            cmd.Parameters.Add(para);
            cmd.Parameters.Add(para1);
            cmd.Parameters.Add(para2);
            cmd.Parameters.Add(para3);
            
            cnn.Open();
            int reader = cmd.ExecuteNonQuery();
            cnn.Close();
            if (reader == 0)
            {
                MyException m = new MyException();
                m.Reason = "Some issue found in updating the blog please try after some time!!";
                throw new FaultException<MyException>(m);
            }
            return b;
        }














        //this is by default generated code
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

       
    }
}
