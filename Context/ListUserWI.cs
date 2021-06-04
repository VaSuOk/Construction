using Construction.HttpRequests;
using Construction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Construction.Context
{
    public class ListUserWI
    {
        public List<UserWorkInformation> userWorkInformation { get; set; }
        public ListUserWI()
        {
            userWorkInformation = new List<UserWorkInformation>();
            userWorkInformation = UserWorkInformationRequest.GetAllUserWI();
        }
        //filtr
    }
}
