using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstname;
        private string lastname;
        /* private string middlename = "";
           private string photo = "";
           private string title = "";
           private string company = "";
           private string address = "";
           private string home = "";
           private string mobile = "";
           private string work = "";
           private string fax = "";
           private string email = "";
           private string email2 = "";
           private string email3 = "";
           private string homepage = "";
           private string bday = "";
           private string bmonth = "";
           private string byear = "";
           private string aday = "";
           private string amonth = "";
           private string ayear = "";
           private string new_group = "";
           private string address2 = "";
           private string phone2 = "";
           private string nickname = "";
           private string notes = ""; */


        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }

        }

        /* Here you can enter values ​​for optional parameters ContactData

         public string Nickname
         {
             get
             {
                 return nickname;
             }
             set
             {
                 nickname = value;
             }

         }

         public string Notes
         {
             get
             {
                 return notes;
             }
             set
             {
                 notes = value;
             }

         } */


    }
}
