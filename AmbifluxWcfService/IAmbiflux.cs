using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AmbifluxWcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IGetEmployees" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IAmbiflux
    {
        [OperationContract]
        //attribute for returning JSON format
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "json/employees")]
        List<EmployeeRecord> GetAllEmployeesMethod();

        //Employee GetEmployeeById(string resourceId);
        [OperationContract]
        [WebGet(UriTemplate = "json/employees/{resourceId}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        EmployeeRecord GetEmployeeById(string resourceId);

         [OperationContract]
        [WebGet(UriTemplate = "json/employeeByCardId/{cardId}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        EmployeeRecord GetEmployeeByCardId(string cardId);
        

        [OperationContract]
        [WebGet(UriTemplate = "json/employee", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        EmployeeRecord GetEmployee();

        [OperationContract]
        [WebGet(UriTemplate = "json/resource/{resourceId}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        ResourceRecord GetResourceById(string resourceId);

        [OperationContract]
        [WebGet(UriTemplate = "json/location/{locationId}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        LocationRecord GetLocationById(string locationId);

        [OperationContract]
        [WebGet(UriTemplate = "json/orderheader/{orderHeaderId}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        OrderHeaderRecord GetOrderHeaderById(string orderHeaderId);

        [OperationContract]
        [WebGet(UriTemplate = "json/SRMA", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        SRMARecord GetSRMA();

        [OperationContract]
        [WebGet(UriTemplate = "json/LogSRMA", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        ResourceRecord LogSRMA();

        [OperationContract]
        [WebGet(UriTemplate = "json/updateWorkorderRouting/{workorderRoutingNo}/{statusId}/{stateId}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string UpdateWorkorderRouting(string workorderRoutingNo, string statusId, string stateId);

       /* [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "json/updateWorkorderRouting/{workorderRoutingNo}/{statusId}/{stateId}")]
        string UpdateWorkorderRouting(string workorderRoutingNo, string statusId, string stateId);*/

        [OperationContract]
        [WebGet(UriTemplate = "json/updateWorkorder/{workorderId}/{statusId}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string UpdateWorkorder(string workorderId, string statusId);

        [OperationContract]
        [WebGet(UriTemplate = "json/Workorders/{status}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<WorkOrderRecord> GetWorkorders(string status);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "json/NewSRMARequest")]     
        string NewSRMARequest(string phoneNumber, string locationId);

      

      
    }
}
