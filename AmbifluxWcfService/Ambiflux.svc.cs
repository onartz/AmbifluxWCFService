using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.ServiceModel.Activation;

namespace AmbifluxWcfService
{
  [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "GetEmployees" à la fois dans le code, le fichier svc et le fichier de configuration.
    public class Ambiflux : IAmbiflux
    {
        //public List<EmployeeRecord> GetAllEmployeesMethod()
        //{
        //    List<EmployeeRecord> mylist = new List<EmployeeRecord>();

        //    using (SqlConnection conn = new SqlConnection("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux"))
        //    {
        //        conn.Open();

        //        string cmdStr = String.Format("Select firstname,lastname from vEmployee");
        //        SqlCommand cmd = new SqlCommand(cmdStr, conn);
        //        SqlDataReader rd = cmd.ExecuteReader();

        //        if (rd.HasRows)
        //        {
        //            while (rd.Read())
        //                mylist.Add(new EmployeeRecord(rd.GetString(0), rd.GetString(1)));
        //        }
        //        conn.Close();
        //    }

        //    return mylist;
        //}

   

        public EmployeeRecord GetEmployeeById(string resourceId)
        {
            EmployeeRecord emp = new EmployeeRecord();

            using (SqlConnection conn = new SqlConnection("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux"))
            {
                conn.Open();

                string cmdStr = String.Format("Select firstname,lastname from vEmployee where ResourceId=" + resourceId);
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    rd.Read();
                    emp.firstname = rd.GetString(0);
                    emp.lastname = rd.GetString(1);

                }
                conn.Close();
                return emp;
            }


        }

      //test
        public EmployeeRecord GetEmployee()
        {
            EmployeeRecord emp = new EmployeeRecord();

            DataClassesDataContext ctx = new DataClassesDataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux");

            return (from e in ctx.vEmployee
                    where e.ResourceID == 3
                    select new EmployeeRecord
                    {
                        firstname = e.FirstName,
                        lastname = e.LastName


                    }).SingleOrDefault();

        }


        public List<WorkOrderRecord> GetWorkorders(string status)
        {
            List<WorkOrderRecord> lWorkOrders = new List<WorkOrderRecord>();

            using (var ctx = new DataClassesDataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux"))
            {
                var listOfWorkOrders = from w in ctx.WorkOrder
                                       where w.WorkOrderStatusID == System.Convert.ToInt16(status)
                                       select new WorkOrderRecord
                                       {
                                           WorkOrderID = w.WorkOrderID,
                                           //StartDate=(DateTime)w.StartDate,
                                           //ModifiedDate=(DateTime)w.ModifiedDate,
                                           type = w.Type,
                                           WorkorderNo = w.WorkOrderNo,
                                           //WorkorderRoutings=w.WorkOrderRouting.ToList(),
                                           OrderHeader = new OrderHeaderRecord
                                           {
                                               OrderId = w.OrderHeader.OrderID,
                                               OrderNo = w.OrderHeader.OrderNo,
                                               CustomerFirstName = w.OrderHeader.Customer.Contact.FirstName,
                                               CustomerLastName = w.OrderHeader.Customer.Contact.LastName,
                                               ObjetDemandeExpress = w.OrderHeader.ObjetDemandeExpress
                                           },


                                           WorkorderRoutings = (from wor in w.WorkOrderRouting
                                                                select new WorkOrderRoutingRecord
                                                                {
                                                                    WorkOrderRoutingNo = wor.WorkOrderRoutingNo.TrimEnd(),
                                                                    Type = System.Convert.ToChar(wor.Type).ToString(),
                                                                    Location = new LocationRecord
                                                                    {
                                                                        LocationName = wor.Location.Name.TrimEnd()
                                                                    }
                                                                }).ToList()

                                       };
              

                return listOfWorkOrders.ToList();
            }
            //// List<WorkOrderRecord> l = new List<WorkOrderRecord>();
            //DataClassesDataContext ctx = new DataClassesDataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux");
            //var listOfWorkOrders = from w in ctx.WorkOrder
            //                       where w.WorkOrderStatusID == 3
            //                       select w;

            //return listOfWorkOrders.ToList();
            //foreach (WorkOrder wo in listOfWorkOrders.ToList())
            //{
            //    WorkOrderRecord wor = new WorkOrderRecord(wo.Type);
            //    l.Add(wor);
            //}
            //return l;

        }

        public ResourceRecord LogSRMA()
        {
            DataClassesDataContext ctx = new DataClassesDataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux");
            var srma = (from c in ctx.Resource where c.ResourceID == 9 select c).SingleOrDefault();
            if(srma!=null)
            {
                srma.DateModified = System.DateTime.Now;
                ctx.SubmitChanges();
            }


            return (from c in ctx.Resource where c.ResourceID == 9 select new ResourceRecord
                        {
                            Name=c.Name.TrimEnd(),

 
                           //DateModified=c.DateModified   
                        
                        }).SingleOrDefault();



            //return srma as ResourceRecord;

        }
        //public string NewSRMARequest()
       public string NewSRMARequest(string phoneNumber, string locationId)
        {
            if (phoneNumber == "") phoneNumber = "0000000000";
          
                //1- on regarde s'il existe un contact avec le numéro de tél
            
                DataClassesDataContext ctx = new DataClassesDataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux");

                var contact = (from c in ctx.Contact where c.Phone == phoneNumber select c).SingleOrDefault();
                if (contact != null)
                //on recherche le customer correspondant
                {
                    var customer = (from c in ctx.Customer where c.Contact == contact select c).SingleOrDefault();
                    //normalement on passe par là!
                    if (customer != null)
                    {
                        //Création d'un nouvel orderHeader
                        OrderHeader o = new OrderHeader();
                        o.Customer = customer;

                        var loc = (from l in ctx.Location where l.LocationID == System.Convert.ToInt32(locationId) select l).SingleOrDefault();
                        o.Location = loc;
                        //o.DeliveryLocationID = System.Convert.ToInt32(locationId);
                        o.OrderType = 'C';
                        o.Comment = "Demande effectuee par tél";
                        o.OrderStatusID = 1;
                        o.OrderDate = System.DateTime.Now;

                        ctx.OrderHeader.InsertOnSubmit(o);
                        ctx.SubmitChanges();

                        WorkOrder wo = new WorkOrder();
                        wo.OrderHeader = o;
                        wo.Type = "CAL";
                        wo.WorkOrderStatusID = 1;

                        wo.OrderHeader = o;

                        ctx.WorkOrder.InsertOnSubmit(wo);
                        //ctx.SubmitChanges();

                        //Wor Transport vers demandeur
                        WorkOrderRouting worT = new WorkOrderRouting();
                        worT.Location = loc;
                        worT.Type = 'T';
                        worT.OperationSequence = 10;
                        worT.StateID = 1;
                        worT.WorkOrderRoutingStatusId = 1;
                       

                        worT.WorkOrder = wo;

                        ctx.WorkOrderRouting.InsertOnSubmit(worT);
                        //wor chargement/dialogue avec demandeur
                        WorkOrderRouting worA = new WorkOrderRouting();
                        worA.Location = loc;
                        worA.Type = 'A';
                        worA.OperationSequence = 20;
                        worA.StateID = 1;
                        worA.WorkOrderRoutingStatusId = 1;

                        worA.WorkOrder = wo;

                        ctx.WorkOrderRouting.InsertOnSubmit(worA);

                        ctx.SubmitChanges();

                        return "ok";
                    }

                }





               /* return (from w in ctx.V_Order
                        where w.OrderID == System.Convert.ToInt32(orderHeaderId)
                        select new OrderHeaderRecord
                        {
                            OrderId = w.OrderID,
                            OrderNo = w.OrderNo,
                            ObjetDemandeExpress = w.ObjetDemandeExpress,
                            CustomerFirstName = w.CustomerFirstName,
                            CustomerLastName = w.CustomerLastName,
                            OrderDate = w.OrderDate.ToString()
                        }).SingleOrDefault();
               */


            /*

                SqlCommand cmd = new SqlCommand("insert into Workorder(Type) values(@Type)", conn);

                cmd.Parameters.AddWithValue("@Type", 'T');
                int result = cmd.ExecuteNonQuery();
                string Message;
                if (result == 1)
                {
                    Message = " Details inserted successfully";
                }
                else
                {
                    Message = " Details not inserted successfully";
                }

                //conn.Close();

                return Message;

            //}*/
                return "Pas OK";
        }



  

        public OrderHeaderRecord GetOrderHeaderById(string orderHeaderId)
        {
            DataClassesDataContext ctx = new DataClassesDataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux");

            return (from w in ctx.V_Order
                    where w.OrderID == System.Convert.ToInt32(orderHeaderId)
                    select new OrderHeaderRecord
                    {
                        OrderId = w.OrderID,
                        OrderNo = w.OrderNo,
                        ObjetDemandeExpress = w.ObjetDemandeExpress,
                        CustomerFirstName = w.CustomerFirstName,
                        CustomerLastName = w.CustomerLastName,
                        OrderDate = w.OrderDate.ToString()
                    }).SingleOrDefault();
        }

        public LocationRecord GetLocationById(string locationId)
        {
            DataClassesDataContext ctx = new DataClassesDataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux");

            return (from l in ctx.Location
                    where l.LocationID == System.Convert.ToInt32(locationId)
                    select new LocationRecord
                    {
                        LocationName = l.Name.TrimEnd(),
                        LocationID = System.Convert.ToInt32(locationId)
                      
                    }).SingleOrDefault();
        }

        public ResourceRecord GetResourceById(string resourceId)
        {
            DataClassesDataContext ctx = new DataClassesDataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux");

            return (from w in ctx.Resource
                    where w.ResourceID == System.Convert.ToInt32(resourceId)
                    select new ResourceRecord
                    {
                        Name = w.Name.TrimEnd(),
                       // DateModified=string.Format
                         DateModified = String.Format("{0:u}", w.DateModified),
                        //LocationId = w.Location.LocationID,
                        ResourceId = w.ResourceID


                        /*OrderId = w.OrderID,
                         OrderNo = w.OrderNo,
                         ObjetDemandeExpress = w.ObjetDemandeExpress,
                         CustomerFirstName = w.CustomerFirstName,
                         CustomerLastName = w.CustomerLastName,
                         OrderDate = w.OrderDate.ToString()*/
                    }).SingleOrDefault();

        }

        public EmployeeRecord GetEmployeeByCardId(string cardId)
        {
            DataClassesDataContext ctx = new DataClassesDataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux");

            return (from w in ctx.vEmployee
                    where w.CardID == cardId
                    select new EmployeeRecord
                    {
                        firstname = w.FirstName.TrimEnd(),
                        lastname = w.LastName.TrimEnd(),
                        cardID = w.CardID.TrimEnd(),
                        emailAddress = w.EmailAddress.TrimEnd()
                    }).SingleOrDefault();

        }

   /*     public LocationRecord GetLocationById(string locationId)
        {
            DataClassesDataContext ctx = new DataClassesDataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux");

            return (from w in ctx.Location
                    where w.LocationID == System.Convert.ToInt32(locationId)
                    select new LocationRecord
                    {
                        LocationName = w.Name.TrimEnd(),
                        // DateModified=string.Format
                       // DateModified = String.Format("{0:u}", w.DateModified),
                        //LocationId = w.Location.LocationID,
                       // ResourceId = w.ResourceID


                        /*OrderId = w.OrderID,
                         OrderNo = w.OrderNo,
                         ObjetDemandeExpress = w.ObjetDemandeExpress,
                         CustomerFirstName = w.CustomerFirstName,
                         CustomerLastName = w.CustomerLastName,
                         OrderDate = w.OrderDate.ToString()
                    }).SingleOrDefault();

        }*/



        public SRMARecord GetSRMA()
        {
            DataClassesDataContext ctx = new DataClassesDataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux");

            return (from w in ctx.Resource
                    where w.ResourceID == 9
                    select new SRMARecord
                    {
                        Name = (w.Name).TrimEnd(),
                        State = System.Convert.ToInt32(w.ResourceStateID),
                        Mode = System.Convert.ToInt32(w.ModeID)
                        //Task = System.Convert.ToInt32(w.TaskID)
                    }).SingleOrDefault();

        }
    }
        [DataContract]
        public class OrderHeaderRecord
        {
            int orderId = 0;
            string orderNo = "";
            string objetDemandeExpress = "";
            string customerFirstName = "";
            string customerLastName = "";
            string orderDate = "";
            //string orderType = "";


            public OrderHeaderRecord()
            {
                orderId = 0;
                orderNo = "";
                objetDemandeExpress = "";
                customerFirstName = "";
                customerLastName = "";
                orderDate = "";
            }


            [DataMember]
            public int OrderId
            {
                get { return orderId; }
                set { orderId = value; }
            }

            [DataMember]
            public string OrderNo
            {
                get { return orderNo; }
                set { orderNo = value; }
            }

            [DataMember]
            public string ObjetDemandeExpress
            {
                get { return objetDemandeExpress; }
                set { objetDemandeExpress = value; }
            }

            [DataMember]
            public string CustomerFirstName
            {
                get { return customerFirstName; }
                set { customerFirstName = value; }
            }

            [DataMember]
            public string CustomerLastName
            {
                get { return customerLastName; }
                set { customerLastName = value; }
            }
            [DataMember]
            public string OrderDate
            {
                get { return orderDate; }
                set { orderDate = value; }
            }
            //[DataMember]
            //public string EmplacementLivraison
            //{
            //    get { return emplacementLivraison; }
            //    set { emplacementLivraison = value; }
            //}

            //[DataMember]
            //public string OrderType
            //{
            //    get { return orderType; }
            //    set { orderType = value; }
            //}

        }

        [DataContract]
        public class ResourceRecord
        {
            int resourceId = 0;
            string name = "";
            int locationId = 0;
            string dateModified;


            public ResourceRecord()
            {
                resourceId = 0;
                name = "";
                locationId = 0;
                dateModified = String.Format("{0:u}", System.DateTime.Now);

            }


            public ResourceRecord(string pResourceId, string pName, string pLocationId)
            {
                resourceId = System.Convert.ToInt16(pResourceId);
                name = pName;
                locationId = System.Convert.ToInt16(pLocationId);
                dateModified = String.Format("{0:u}", System.DateTime.Now);
            }

            [DataMember]
            public int ResourceId
            {
                get { return resourceId; }
                set { resourceId = value; }
            }

            [DataMember]
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            [DataMember]
            public int LocationId
            {
                get { return locationId; }
                set { locationId = value; }
            }

            [DataMember]
            public string DateModified
            {
                get { return dateModified; }
                set { dateModified = value; }
            }
        }

        [DataContract]
        public class SRMARecord
        {
            int resourceId = 0;
            string name = "";
            int locationId = 0;
            int mode = 0;
            int state = 0;
            int task = 0;
            System.DateTime dateModified;


            public SRMARecord()
            {
                resourceId = 0;
                name = "";
                locationId = 0;
                mode = 0;
                state = 0;
                task = 0;
                dateModified = System.DateTime.Now;
            }


            public SRMARecord(string pResourceId, string pName, string pLocationId)
            {
                resourceId = System.Convert.ToInt16(pResourceId);
                name = pName;
                locationId = System.Convert.ToInt16(pLocationId);
                mode = 0;
                state = 0;
                task = 0;
                dateModified = System.DateTime.Now;

            }

            [DataMember]
            public int ResourceId
            {
                get { return resourceId; }
                set { resourceId = value; }
            }

            [DataMember]
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            [DataMember]
            public int Mode
            {
                get { return mode; }
                set { mode = value; }
            }
            [DataMember]
            public int State
            {
                get { return state; }
                set { state = value; }
            }
            [DataMember]
            public int Task
            {
                get { return task; }
                set { task = value; }
            }
            [DataMember]
            public DateTime DateModified
            {
                get { return dateModified; }
                set { dateModified = value; }
            }
        }

        [DataContract]
        public class EmployeeRecord
        {
            [DataMember]
            public string firstname { get; set; }
            [DataMember]
            public string lastname { get; set; }
            [DataMember]
            public string cardID { get; set; }
            [DataMember]
            public string emailAddress { get; set; }

            public EmployeeRecord(string first, string last, string cardID, string emailAddress)
            {
                firstname = first;
                lastname = last;
                this.cardID = cardID;
                this.emailAddress = emailAddress;

            }

            public EmployeeRecord(string first, string last)
            {
                firstname = first;
                lastname = last;
                cardID = "";
                emailAddress = "";
               

            }

            public EmployeeRecord()
            {
                firstname = "";
                lastname = "";
                cardID = "";
                emailAddress = "";
            }
        }

        [DataContract]
        public class SRMARequest
        {
            int locationId = 0;
            string phoneNumber="";
            string type = "";
           
    

            public SRMARequest(string pType)
            {
                type = pType;
            }

            public SRMARequest()
            {
                type = "";
            }

            [DataMember]
            public string PhoneNumber
            {
                get { return phoneNumber; }
                set { phoneNumber = value; }
            }

            [DataMember]
            public string Type
            {
                get { return type; }
                set { type = value; }
            }

            [DataMember]
            public int LocationId
            {
                get { return locationId; }
                set { locationId = value; }
            }

        }

        [DataContract]
        public class WorkOrderRecord
        {
            [DataMember]
            public int WorkOrderID { get; set; }
            [DataMember]
            public string StartDate { get; set; }
            [DataMember]
            public string ModifiedDate { get; set; }
            [DataMember]
            public OrderHeaderRecord OrderHeader { get; set; }
            [DataMember]
            public string type { get; set; }
            [DataMember]
            public string WorkorderNo { get; set; }
            [DataMember]
            public List<WorkOrderRoutingRecord> WorkorderRoutings { get; set; }

            public WorkOrderRecord(string pType)
            {

                type = pType;
            }

            public WorkOrderRecord()
            {
                type = "";
            }
        }
    }

[DataContract]
public class WorkOrderRoutingRecord
{

        [DataMember]
        public string WorkOrderRoutingNo { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public LocationRecord Location { get; set; }
}

[DataContract]
public class LocationRecord
{
    [DataMember]
    public string LocationName { get; set; }
    [DataMember]
    public int LocationID { get; set; }
}


//public Resource GetResourceById(string resourceId)
/* {
     Resource resource = new Resource();

     using (SqlConnection conn = new SqlConnection("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux"))
     {
         conn.Open();

         string cmdStr = String.Format("Select Name,ResourceType,LocationId, ResourceStatusId from Resource where ResourceId=" + resourceId);
         SqlCommand cmd = new SqlCommand(cmdStr, conn);
         SqlDataReader rd = cmd.ExecuteReader();

         if (rd.HasRows)
         {
             rd.Read();
             resource.Name = rd.GetString(0);
             //resource.ResourceType = (char)rd.GetString(1);
             resource.LocationID = rd.GetInt16(2);
             resource.ResourceStatusID = rd.GetInt16(3);
         }
         conn.Close();
         return resource;
     }


 }*/

/*     public string InsertNewWorkOrder(WorkOrderRecord workOrder)
       {
           using (SqlConnection conn = new SqlConnection("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux"))
           {
               conn.Open();

               SqlCommand cmd = new SqlCommand("insert into Workorder(Type) values(@Type)", conn);

               cmd.Parameters.AddWithValue("@Type", workOrder.type);
               int result = cmd.ExecuteNonQuery();
               string Message;
               if (result == 1)
               {
                   Message = " Details inserted successfully";
               }
               else
               {
                   Message = " Details not inserted successfully";

               }

               conn.Close();

               return Message;

           }
       }
       */