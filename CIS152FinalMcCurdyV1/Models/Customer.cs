using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace CIS152FinalMcCurdyV1.Models
{
    // public class Customer : IdentityUser
    public class Customer 
    {
        // Fields/attributes
        private int _customerId;
        // Data Annotations - for data validation rules ?? place on 
        // attributes/fields or properties better practice??
        //[Required(ErrorMessage = "First name required")]
        //[StringLength(50, ErrorMessage = "Invalid First Name: name cannot be longer than 50 characters.")]
        // Can use a RegularExpression to add validation to make sure characters are only in alphabet
        // no spaces/numbers or special characters.
        // Below version ensures frist letter is capitalized and rest are letters of the alphabet.
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        // ?? version if just want alphabetic letters but capitalization doesn't matter??
        //[RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        // ?? consider adding date object
        // to hold date when customer first
        // created to use as 'joined'/'customer since xxxx' data.

        // ?? create an attribute to hold all customers - in a sorted order? Or which
        // can then be sorted/searched??

        // Constructor(s)
        // Default constructor
        public Customer()
        {
            //CustomerId = customerId;
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
        }

        // Parameterized Constructor(s)
        public Customer(string firstName, string lastName, string email, string phone)
        {
            //CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        // Properties
        // If using Entity Framework do not need to specify [Key] as 
        // the EF assigns Properties named w/ 'ClassnameId' syntax as the
        // Class's Primary Key automatically. 
        //[Key]
        public int CustomerId { get => _customerId; set => _customerId = value; }
        // Data Annotations - for data validation rules ?? place on 
        // attributes/fields or properties better practice??
        //[Required(ErrorMessage = "First name required")]
        //[StringLength(50, ErrorMessage = "Invalid First Name: name cannot be longer than 50 characters.")]
        // Can use a RegularExpression to add validation to make sure characters are only in alphabet
        // no spaces/numbers or special characters.
        // Below version ensures frist letter is capitalized and rest are letters of the alphabet.
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        // ?? version if just want alphabetic letters but capitalization doesn't matter??
        //[RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        public string FirstName { get => _firstName; set => _firstName = value; }
        // ?? version if just want alphabetic letters but capitalization doesn't matter??
        //[RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        //[Required(ErrorMessage = "Last name required")]
        //[StringLength(50, ErrorMessage = "Invalid First Name: name cannot be longer than 50 characters.")]
        public string LastName { get => _lastName; set => _lastName = value; }
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage = "Email address is invalid")]
        public string? Email { get => _email; set => _email = value; }
        //[DataType(DataType.PhoneNumber)]
        // ??[RegularExpression(@"^\d{3}-\d{3}-\d{4}$")] string phone)
        //[Phone(ErrorMessage = "Phone number is invalid")]
        public string? Phone { get => _phone; set => _phone = value; }


        // Methods
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            //return base.ToString();
            return $"Customer Id: {CustomerId}; Customer Name: {FirstName} {LastName}; Email: {Email}; Phone: {Phone}";
        }
    }
}
