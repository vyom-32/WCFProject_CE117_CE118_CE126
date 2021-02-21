using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace BlogManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        //blog start from here

        [OperationContract]
        bool AddBlog(Blog b);

        [OperationContract]
        [FaultContract(typeof(MyException))]
        Blog UpdateBlog(Blog b);
        
        [OperationContract]
        [FaultContract(typeof(MyException))]
        bool DeleteBlog(int id);
        
        [OperationContract]
        [FaultContract(typeof(MyException))]
        Blog GetBlog(int id);
        
        [OperationContract]
        DataSet GetAllBlog();


        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "BlogManagement.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class Blog
    {
        int id;
        string title;
        string description;
        DateTime dateofupload;


        [DataMember]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        [DataMember]
        public DateTime DateOfUpload
        {
            get { return dateofupload; }
            set { dateofupload = value; }
        }
    }

    
    [DataContract]
    public class MyException
    {
        private string strReason= "Some error occured!";
        
        [DataMember]
        public string Reason
        {
            get { return strReason; }
            set { strReason = value; }
        }
    }
}
