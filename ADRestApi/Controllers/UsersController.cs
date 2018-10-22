using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ADRestApi.Models;


namespace ADRestApi.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        public Person[] Get()
        {
            ADHelper ad = new ADHelper();
            return ad.searchUsers("");
        }

        // GET: api/Users/5
        public Person[] Get(string searchstring)
        {
            ADHelper ad = new ADHelper();
            return ad.searchUsers(searchstring);
        }

        // POST: api/Users
        /*public void Post([FromBody]string value)
        {
        }*/

        // PUT: api/Users/5
        /*public void Put(int id, [FromBody]string value)
        {
        }*/

        // DELETE: api/Users/5
        /*public void Delete(int id)
        {
        }*/
    }
}
