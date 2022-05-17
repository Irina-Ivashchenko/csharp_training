using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace WebAddressbookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allInformation;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Id { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }


        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ ()-]", "") + "\r\n";
        }

        public string AllPhones
        {
            get {
                if (allPhones !=null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)).Trim();
                }
            }

            set {
                allPhones = value;
            }
        }

        public string FullHomePhone(string homePhone)
        {
            if (homePhone == null || homePhone == "")
            {
                return "";
            }
            return "H: " + homePhone + "\r\n";
        }

        public string FullMobilePhone(string mobilePhone)
        {
            if (mobilePhone == null || mobilePhone == "")
            {
                return "";
            }
            return "M: " + mobilePhone + "\r\n";
        }

        public string FullWorkPhone(string workPhone)
        {
            if (workPhone == null || workPhone == "")
            {
                return "";
            }
            return "W: " + workPhone + "\r\n";
        }

        private string FullPhones(string homePhone, string mobilePhone, string workPhone)
        {
            if ((homePhone == null || homePhone == "") && (mobilePhone == null || mobilePhone == "")
                    && (workPhone == null || workPhone == ""))
            {
                return "";
            }
            return "\r\n" + FullHomePhone(HomePhone) + FullMobilePhone(MobilePhone) + FullWorkPhone(WorkPhone);
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }      

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string FullEmails(string email, string email2, string email3)
        {
            if ((email == null || email == "") && (email2 == null || email2 == "")
                    && (email3 == null || email3 == ""))
            {
                return "";
            }
            return "\r\n" + CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3);
        }

        private string CleanUpAddress(string address)
        {
            if (address == null || address == "")
            {
                return "";
            }
            return address + "\r\n";
        }

        private string CleanUpFullName(string firstname, string lastname)
        {
            if ((firstname == null || firstname == "") && (lastname == null || lastname == ""))
            {
                return "";
            }
            return (Firstname + " " + Lastname).Trim() + "\r\n";
        }

        public string AllInformation
        { 
            get
            {
                if (allInformation != null)
                {
                    return allInformation;
                }
                else
                {
                    return (CleanUpFullName(Firstname, Lastname) + CleanUpAddress(Address) 
                        + FullPhones(HomePhone, MobilePhone, WorkPhone)
                        + FullEmails(Email, Email2, Email3)).Trim();
                }
            }
            set
            {
                allInformation = value;
            }
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() * 31 + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname=" + Firstname + "\nLastname=" + Lastname + "\nAddress=" + Address;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int result = Lastname.CompareTo(other.Lastname);
            if (result != 0)
            {
                return result;
            }
            else
            {
                return Firstname.CompareTo(other.Firstname);
            }
        }
    }
}
