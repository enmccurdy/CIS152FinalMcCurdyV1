using CIS152FinalMcCurdyV1.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace CIS152FinalMcCurdyV1.Models
{
    public class Drink
    {
        // Fields/attributes
        private int _drinkId;
        //private string _drinkName;
        // Switch to using enum for DrinkName options
        private DrinkName _drinkName;
        // consider creating enums for DrinkType and DrinkSize
        private string _drinkType;
        private string _drinkSize;
        //private string _drinkDescription;
        private string _drinkImageUrl;
        private decimal _drinkPrice;
        // ?attribute to hold associated foreign key for OrderID
        private int _orderId;
        // ??or does this just need a Property?? along w/ virtual Property
        // to attach to associated Order entity/object??

        // Constructor(s)
        // Default constructor
        public Drink()
        {
            //DrinkId = drinkId;
            //DrinkName = "";
            DrinkName = DrinkName.WhiteChocolateMocha;
            DrinkType = "";
            DrinkSize = "";
            //DrinkImageUrl = drinkImageUrl;
            DrinkPrice = -1m;
        }
        // Parameterized Constructor(s)
        public Drink(DrinkName drinkName, string drinkType, string drinkSize)
        //public Drink(string drinkName, string drinkType, string drinkSize)
        {
            //DrinkId = drinkId;
            DrinkName = drinkName;
            DrinkType = drinkType;
            DrinkSize = drinkSize;
            //DrinkImageUrl = drinkImageUrl;
            // Use below for now until switch to DrinkPrice w/ specific setter version 
            DrinkPrice = 1.49m;
            //DrinkPrice = this.DrinkPrice;
        }
        public Drink(DrinkName drinkName, string drinkType, string drinkSize, decimal price)
        //public Drink(string drinkName, string drinkType, string drinkSize, decimal price)
        {
            //DrinkId = drinkId;
            DrinkName = drinkName;
            DrinkType = drinkType;
            DrinkSize = drinkSize;
            //DrinkImageUrl = drinkImageUrl;
            DrinkPrice = price;
        }

        // Properties
        // If using Entity Framework do not need to specify [Key] as 
        // the EF assigns Properties named w/ 'ClassnameId' syntax as the
        // Class's Primary Key automatically. 
        //[Key]
        public int DrinkId { get => _drinkId; set => _drinkId = value; }
        //[Required(ErrorMessage = "DrinkName is required")]
        //public string? DrinkName { get => DrinkName1; set => DrinkName1 = value; }
        // If switch to using DrinkName enum rather than string.
        public DrinkName DrinkName { get => _drinkName; set => _drinkName = value; }
        //[Required(ErrorMessage = "DrinkType is required")]
        public string? DrinkType { get => _drinkType; set => _drinkType = value; }
        /*public string DrinkType
        {
            get { return _drinkType; }
            set
            {
                if (string.Equals(value,"coffee",StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "tea", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "soda", StringComparison.InvariantCultureIgnoreCase))
                {
                    _drinkType = value;
                }
                else
                {
                    // set default of 'coffee' if input doesn't match one of the three drink types
                    _drinkType = "coffee";
                }
            }
        }*/
        // Add '?' to datatype for DrinkSize to make it 'nullable'
        //[Required(ErrorMessage = "DrinkSize is required")]
        public string? DrinkSize { get => _drinkSize; set => _drinkSize = value; }
        /*public string? DrinkSize 
        {
            get { return _drinkSize; } 
            set
            {
                if (string.Equals(value, "small", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "regular", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "large", StringComparison.InvariantCultureIgnoreCase))
                {
                    _drinkSize = value;
                }
                else
                {
                    // set default DrinkSize of 'regular' if input doesn't match one fo the three sizes
                    _drinkSize = "regular";
                }
            } 
        }*/
        // Added '?' to datatype for DrinkImageUrl to make it 'nullable'
        //[Url]
        public string? DrinkImageUrl { get => _drinkImageUrl; set => _drinkImageUrl = value; }
        // Per learn.microsoft.com tutorial - decimal, int, float, DateTime
        // values types are 'inherently' required therefore do NOT need the
        // 'Required' attribute. 
        //[DisplayFormat(DataFormatString = "{C2, CultureInfo.CurrentCulture}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "(C2, CultureInfo.CurrentCulture)", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{D2}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "(D2)", ApplyFormatInEditMode = true)]
        //??[Column(TypeName = "decimal(18, 2)")]
        //[DataType(DataType.Currency, ErrorMessage = "Drink Price invalid, must be a positive value.")]
        //public decimal DrinkPrice { get => _drinkPrice; set => _drinkPrice = value; }
        public decimal DrinkPrice 
        { 
            get { return _drinkPrice; } 
            set
            {
                // Setting DrinkPrice based on DrinkType and DrinkSize
                if (string.Equals(DrinkType, "coffee", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (string.Equals(DrinkSize, "small", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 2.99m;
                    }
                    else if (string.Equals(DrinkSize, "regular", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 3.99m;
                    }
                    else if (string.Equals(DrinkSize, "large", StringComparison.InvariantCultureIgnoreCase))
                    {
                       value = 4.99m;
                    }
                }
                else if (string.Equals(DrinkType, "tea", StringComparison.InvariantCultureIgnoreCase) ) {
                    if (string.Equals(DrinkSize, "small", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 1.59m;
                    }
                    else if (string.Equals(DrinkSize, "regular", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 2.59m;
                    }
                    else if (string.Equals(DrinkSize, "large", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 3.59m;
                    }
                }
                else if (string.Equals(DrinkType, "soda", StringComparison.InvariantCultureIgnoreCase)) {
                    if (string.Equals(DrinkSize, "small", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 2.50m;
                    }
                    else if (string.Equals(DrinkSize, "regular", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 3.50m;
                    }
                    else if (string.Equals(DrinkSize, "large", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 4.50m;
                    }
                }
                _drinkPrice = value; 
            }
        }

        // ?attribute? too?? Property to hold associated foreign key for OrderID
        //[ForeignKey("Order")]
        //[ForeignKey(nameof(Order))]
        public int OrderId { get => _orderId; set => _orderId = value; }
        // ??or does this just need a Property?? along w/ virtual Property
        // to attach to associated Order entity/object??
        public virtual Order Order { get; set; }

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
            // Decide on DrinkPrice formatting if want '$' - and specify 2 decimal place output. 
            //string drinkOutput = $"Drink Id: {DrinkId}; Drink Type: {DrinkType}; Drink Name: {DrinkName}; Size: {DrinkSize}; Price: $ {DrinkPrice};";
            string drinkOutput = $"Drink Id: {DrinkId}; Drink Type: {DrinkType}; Drink Name: {DrinkName}; Size: {DrinkSize}; Price: $ {DrinkPrice}; Order Id: {OrderId}";
            //string drinkOutput = $"Drink Id: {DrinkId}; Drink Type: {DrinkType}; Drink Name: {DrinkName}; Size: {DrinkSize}; Price: $ {DrinkPrice}; Order Id: {Order.OrderId}";
            return drinkOutput;
        }


    }
}
