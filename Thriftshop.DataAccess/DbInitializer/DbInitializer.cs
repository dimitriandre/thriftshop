using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;

namespace Thriftshop.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        public void Initialize()
        {
            //migrations if they are not applied

            //create roles if not created

            //if roles are not created then we will create admin user as well

        }
    }
}
