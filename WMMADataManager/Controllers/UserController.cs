using MMADataManager.Library.DataAccess;
using MMADataManager.Library.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WMMADataManager.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
       
        public string Get(int id)
        {
            return "value";
        }

        public List<UserModel> GetById()
        {
            // Recupération des données de user connecté
            string userId = RequestContext.Principal.Identity.GetUserId();

            UserData userData = new UserData();

            var user = userData.GetUserById(userId);

            return user;
        }
    }
}
