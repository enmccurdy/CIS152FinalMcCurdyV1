using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIS152FinalMcCurdyV1.Models
{
    public class Order
    {
        // Fields/attributes
        // Primary key - OrderId
        private int _orderId;
        // ?? consider seperating out Date and Time into two separate attributes??
        private DateTime _orderDate;
        // Use foreign key CustomerId to associate specific customer w/ this Order 
        // object/entity rather than using below attribute/property combo. 
        //private Customer _customer;

        // Use the one-to-many collection of Drink objects/entities for this
        // Order entity/object - couldn't get to work using private attributes/fields
        // with a public Property - had to create List of Drink objects using 
        // the virtual ICollection<Drink> navigation property below (see Navigation
        // properties sections). 
        //private List<Drink> _drinks;
        //private virtual List<Drink> _drinks;
        //private ICollection<Drink> _drinks;

        private decimal _orderTotal;
        // ?attribute to hold associated foreign key for DrinkID
        //private int _drinkId;
        // Since the Order entity/object can have many associated Drink objects
        // which are linked to using the DrinkId foreign key ?? Have ICollection
        // virtual list of the DrinkIds for this Order entity/object vs
        // the Drinks List above??

        // ?attribute to hold associated foreign key for CustomerID
        // ?? rather than _customer??
        private int _customerId;
        private int _toDoId;

        // ?? eliminate the ToDo model and move the Orders queue data structure
        // into the Order model. ??


        // Constructor(s)
        // Default constructor
        public Order()
        {
            //OrderId = orderId;
            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            //Customer = null;
            // Create an empty List of Drink objects. 
            Drinks = new List<Drink>();
            // Set OrderDate to today's date.
            OrderDate = new DateTime();
            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
        }
        // Parameterized Constructor(s)
        public Order(int customerId)
        //public Order(Customer customer)
        {
            //OrderId = orderId;
            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            //Customer = customer;
            CustomerId = customerId;
            // Create an empty List of Drink objects. 
            Drinks = new List<Drink>();
            // Set OrderDate to today's date.
            OrderDate = new DateTime();
            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
        }
        
        public Order(int customerId, List<Drink> drinks)
        //public Order(Customer customer, List<Drink> drinks)
        {
            //OrderId = orderId;
            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            //Customer = customer;
            CustomerId = customerId;
            Drinks = drinks;
            // Set OrderDate to today's date.
            OrderDate = new DateTime();
            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
        }

        // Properties
        // If using Entity Framework do not need to specify [Key] as 
        // the EF assigns Properties named w/ 'ClassnameId' syntax as the
        // Class's Primary Key automatically. 
        //[Key]
        public int OrderId { get => _orderId; set => _orderId = value; }
        // DataType attribute for formatting DateTime object
        //[DataType(DataType.DateTime, ErrorMessage = "DateTime is invalid.")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy - hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }
        //public Customer? Customer { get => _customer; set => _customer = value; }
        //public List<Drink> Drinks { get => _drinks; set => _drinks = value; }

        //[DataType(DataType.Currency, ErrorMessage = "Drink Price invalid, must be a positive value.")]
        //[DisplayFormat(DataFormatString = "{C2, CultureInfo.CurrentCulture}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "(C2, CultureInfo.CurrentCulture)", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{D2}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "(D2)", ApplyFormatInEditMode = true)]
        //??[Column(TypeName = "decimal(18, 2)")]
        public decimal OrderTotal { get => _orderTotal; set => _orderTotal = value; }
        //public int DrinkId { get => _drinkId; set => _drinkId = value; }
        //[ForeignKey(nameof(CustomerId))]
        //[ForeignKey("Customer")]
        public int CustomerId { get => _customerId; set => _customerId = value; }
        //[ForeignKey("ToDo")]
        //[ForeignKey(nameof(ToDoId))]
        public int? ToDoId { get => _toDoId; set => _toDoId = value.Value; }

        // Navigation Properties: 
        // MS learn tutorial on EF MVC used below to hold multiple rows of data associated
        // w/ this class entity's primary key value - i.e. Drinks property of an Order entity
        // would chold all the 'Drink' entities/objects related this this Order entity -
        // so if this Order entity has multiple related Drink rows (Drink rows w/ this Order
        // entity's/object's primary key in the Drink rows OrderId foreign key column).
        // Uses keyword 'virtual' so 'Navigation Properties' can take advantage of EF functionality
        // - necessary d/t need a List (such as ICollection) to be able to do CRUD operations
        // on a navaigation property which holds multiple entities (such as w/ many-to-many &
        // one-to-many type relationships). 
        //public virtual ICollection<Drink> Drinks { get; set; }

        // Since the Order entity/object can have many associated Drink objects
        // which are linked to using the DrinkId foreign key ?? Have ICollection
        // virtual list of the DrinkIds for this Order entity/object vs
        // the Drinks List above??
        public virtual ICollection<Drink> Drinks { get; set; }
        // DrinkId property is a foreign key w/ the corresponding 'navigation property' of Order.Drinks.
        // This Order entity/object 'Drinks' List/collection can hold many associated Drink entities/objects. 
        //public virtual Drink Drink { get; set; }

        // Navigation Properties: 
        // CustomerId property is a foreign key w/ the corresponding 'navigation property' of Customer.
        // This Order entity/object can only be associated w/ one Customer entity/object. 
        public virtual Customer Customer { get; set; }
        //[ForeignKey("ToDo")]
        //[ForeignKey(nameof(ToDoId))]
        [NotMapped]
        public virtual ToDo? ToDo { get; set; }
        

        // Methods
        public decimal CalcTotal()
        {
            decimal total = 0m;
            if (Drinks != null)
            {
                foreach (Drink drink in Drinks)
                {
                    total += drink.DrinkPrice;
                }
            }

            return total;
        }

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
            //return $"Order Id: {OrderId}; Order Date: {OrderDate}; Customer Id: {Customer.CustomerId}; Customer Name: {Customer.FirstName} {Customer.LastName}; ";
            string orderOutput = $"Order Id: {OrderId}; Order Date: {OrderDate}; Customer Id: {Customer.CustomerId}; Customer Name: {Customer.FirstName} {Customer.LastName}; /n";
            orderOutput += $"Drinks: /n";
            if (Drinks != null)
            {
                //orderOutput += $"Drinks: /n";
                foreach (Drink drink in Drinks)
                {
                    orderOutput += $"{drink.ToString} /n";
                }
            }
            else
            {
                //orderOutput += "Drinks: No drinks in this order. /n";
                orderOutput += "No drinks in this order. /n";
            }
            // Decide on OrderTotal formatting if want '$' - and specify 2 decimal place output.
            orderOutput += $"Order Total: $ {OrderTotal}";
            return orderOutput;
        }
    }
}
