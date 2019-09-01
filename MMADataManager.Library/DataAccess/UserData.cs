using MMADataManager.Library.Internal.DataAccess;
using MMADataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMADataManager.Library.DataAccess
{
    public class UserData
    {

        public List<UserModel> GetUserById(string id)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var p = new { Id = id };

            var output = sqlDataAccess.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "DefaultConnection");

            return output;
        }

    }
}
