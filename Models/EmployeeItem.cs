using System.Text;
using System.Text.RegularExpressions;

namespace FirstWidget.ITMS.WebApi
{
    public class EmployeeItem
    {
        //employee social security number
        public string SSN { get; set; }

        //Best practices call for 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public EmployeeItem(
            string ssn,
            string firstName,
            string lastName,
            string address,
            string city,
            string state
        )
        {
            this.SSN = ssn;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.City = city;
            this.State = state;
        }
        public static bool ValidateSSN(string ssn)
        {
            return Regex.Match(ssn, @"\d{9}", RegexOptions.IgnoreCase).Success;
        }

        public bool ValidateEmployeeData(out string response)
        {
            var sbResponse = new StringBuilder();
            var valid = ValidateSSN(SSN);
            if (!valid) 
            {
                sbResponse.Append("Invalid SSN. Must be exactly 9 digits");
            }
            valid &= ValidateEmployeeField(FirstName, "First Name",sbResponse);
            valid &= ValidateEmployeeField(LastName, "Last Name",sbResponse);
            valid &= ValidateEmployeeField(Address, "Address",sbResponse);
            valid &= ValidateEmployeeField(City, "City",sbResponse);
            valid &= ValidateEmployeeField(State, "State",sbResponse);

            response = sbResponse.ToString();
            return valid;
        }

        private bool ValidateEmployeeField(string value, string fieldName, StringBuilder sbResponse)
        {
            bool invalid = string.IsNullOrWhiteSpace(value);
            if (invalid)
            {
                sbResponse.Append($"{fieldName} must not be empty; ");
            }
            return invalid == false;
        }
    }
}