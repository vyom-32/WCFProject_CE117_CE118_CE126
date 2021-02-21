using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BlogManagementClient.ServiceReference1;
namespace BlogManagementClient
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Welcome to HappyBlogs :)";
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            BlogManagementClient.ServiceReference1.Service1Client pr = new BlogManagementClient.ServiceReference1.Service1Client("BasicHttpBinding_IService1");

            DataSet ds = pr.GetAllBlog();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BlogManagementClient.ServiceReference1.Service1Client pr = new BlogManagementClient.ServiceReference1.Service1Client("BasicHttpBinding_IService1");

            int ID = (int)e.Keys["Id"];
            pr.DeleteBlog(ID);
            
            BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            BlogManagementClient.ServiceReference1.Service1Client pr = new BlogManagementClient.ServiceReference1.Service1Client("BasicHttpBinding_IService1");
            int ID = (int)e.Keys["Id"];
            Blog b = new Blog();
            string title = (string)e.NewValues["title"];
            string description = (string)e.NewValues["description"];
            
            DateTime dar = DateTime.Parse((string)e.NewValues["dateofupload"]);
            
            b.ID = ID;
            b.Title =title;
            b.Description = description;
            b.DateOfUpload = dar;
            
            pr.UpdateBlog(b);
            GridView1.EditIndex = -1;
            BindData();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Addblog.aspx");
        }
    }
}