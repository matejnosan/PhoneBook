using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Configuration;

namespace ADRestApi
{
    public class ADHelper
    {
        //ou=child, ou=parent, dc=domain, dc=com
        //string ldapAddress = "LDAP://marifarm.si:3268/ou=Users, ou=MF, dc=marifarm, dc=si";
        string ldapAddress = ConfigurationManager.AppSettings["ldapAddress"];

        public Models.Person[] searchUsers(string searchString)
        {

            DirectoryEntry de = new DirectoryEntry(ldapAddress);
            DirectorySearcher ds = new DirectorySearcher(de);

            // Set the properties to load.
            ds.PropertiesToLoad.Add("givenname");
            ds.PropertiesToLoad.Add("department");
            ds.PropertiesToLoad.Add("description");
            ds.PropertiesToLoad.Add("mail");
            ds.PropertiesToLoad.Add("telephoneNumber");
            ds.PropertiesToLoad.Add("mobile");
            ds.PropertiesToLoad.Add("sn");


            searchString = searchString + "*";

            ds.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(|(givenname={0})(sn={0})(department={0})(description={0})))", searchString );

            SearchResultCollection src = ds.FindAll();

            List<Models.Person> osebe = new List<Models.Person>();
            Models.Person oseba;

            foreach (SearchResult sr in src)
            {
                string ime = "";
                string priimek = "";
                string email = "";
                string oddelek = "";
                string telefon = "";
                string mobitel = "";
                string opis = "";
                oseba = new Models.Person();

                if (sr.GetDirectoryEntry().Properties["givenName"].Value != null)
                {
                    ime = sr.GetDirectoryEntry().Properties["givenName"].Value.ToString();
                }
                if (sr.GetDirectoryEntry().Properties["sn"].Value != null)
                {
                    priimek = sr.GetDirectoryEntry().Properties["sn"].Value.ToString();
                }
                if (sr.GetDirectoryEntry().Properties["mail"].Value != null)
                {
                    email = sr.GetDirectoryEntry().Properties["mail"].Value.ToString();
                }
                if (sr.GetDirectoryEntry().Properties["department"].Value != null)
                {
                    oddelek = sr.GetDirectoryEntry().Properties["department"].Value.ToString();
                }
                if (sr.GetDirectoryEntry().Properties["description"].Value != null)
                {
                    opis = sr.GetDirectoryEntry().Properties["description"].Value.ToString();
                }
                if (sr.GetDirectoryEntry().Properties["telephoneNumber"].Value != null)
                {
                    telefon = sr.GetDirectoryEntry().Properties["telephoneNumber"].Value.ToString();
                }
                if (sr.GetDirectoryEntry().Properties["mobile"].Value != null)
                {
                    mobitel = sr.GetDirectoryEntry().Properties["mobile"].Value.ToString();
                }
                oseba.name = ime;
                oseba.surname = priimek;
                oseba.email = email;
                oseba.department = oddelek;
                oseba.description = opis;
                oseba.phone = telefon;
                oseba.mobilePhone = mobitel;
                osebe.Add(oseba);
            }

            ds.Dispose();
            de.Dispose();
            return osebe.ToArray();
        }
    }
}
