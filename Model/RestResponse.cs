using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MyAPITestProject.Model
{
    public class RestResponse
    {
        private int statusCode;
        private string responseData;
        // to initialize the above constructor we use below constructor

        public RestResponse(int StatusCode, string responseData)
        {
            this.statusCode = statusCode;
            this.responseData = responseData;
        }

        //adding a Getter property to return the status & responsedata vaues

        public int Status
        { get 
            { return statusCode; } 
        }

        public string ResponseContent
        { get 
            { return responseData; } 
        }

        public string Content { get; internal set; }

        //to return the status & data in desired format

        public override string ToString()
        {
            return string.Format("StatusCode : {0}, ResponseData : {1}", statusCode, responseData);
        }
    }
}
