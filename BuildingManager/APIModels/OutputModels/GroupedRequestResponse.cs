using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels.OutputModels
{
    public class GroupedRequestResponse
    {
        //nombre de usuario de mantenimiento o edificio
        public string Name { get; set; }
        public int OpenedRequests { get; set; }
        public int ClosedRequests { get; set; }

        public int AttendingRequests { get; set; }



        public GroupedRequestResponse()
        {


        }


    }
}