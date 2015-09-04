using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testWCFAmbiflux
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            //str = NewSRMARequest("+33683140214", "20");
            Resource r = LogSRMA();
            
          
        }

        public static string NewSRMARequest(string phoneNumber, string locationId)
        {
            //using (SqlConnection conn = new SqlConnection("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux"))
            //{
            //conn.Open();

            //1- on regarde s'il existe un contact avec le numéro de tél
            DataClasses1DataContext ctx = new DataClasses1DataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux");

           // DataClassesDataContext ctx = new DataClassesDataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux");

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

                    ctx.OrderHeader.InsertOnSubmit(o);
                    //ctx.SubmitChanges();

                    WorkOrder wo = new WorkOrder();
                    wo.OrderHeader = o;
                    wo.Type = "CAL";
                    wo.WorkOrderStatusID = 1;

                    wo.OrderHeader = o;

                    ctx.WorkOrder.InsertOnSubmit(wo);
                    //ctx.SubmitChanges();


                    WorkOrderRouting wor = new WorkOrderRouting();
                    wor.Location=loc;
                    wor.Type = 'T';
                    wor.OperationSequence = 10;

                    wor.WorkOrder = wo;

                    ctx.WorkOrderRouting.InsertOnSubmit(wor);

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

        public static Resource LogSRMA()
        {
            DataClasses1DataContext ctx = new DataClasses1DataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux");

           // DataClassesDataContext ctx = new DataClassesDataContext("Data Source=AIP-SQLAIPL;Initial Catalog=Aipl;User ID=ambiflux;Password=ambiflux");
            var srma = (from c in ctx.Resource where c.ResourceID == 9 select c).SingleOrDefault();
            if (srma != null)
            {
                srma.DateModified = System.DateTime.Now;
                ctx.SubmitChanges();
            }
            return null;


          /*  return (from c in ctx.Resource
                    where c.ResourceID == 9
                    select new ResourceRecord
                    {
                        LocationId = (int)c.LocationID,
                        Name = c.Name,
                        DateModified = c.DateModified

                    }).SingleOrDefault();*/



            //return srma as ResourceRecord;

        }

    }


}
