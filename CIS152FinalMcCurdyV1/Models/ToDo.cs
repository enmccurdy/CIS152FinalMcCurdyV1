using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIS152FinalMcCurdyV1.Models
{
    public class ToDo
    {

        // Fields/attributes
        /*private int _toDoId;
        private DateTime _toDoDate;
        private Queue<Order> _ordersQueue;*/
        // See below navigation property needed a virtual ICollection
        // 'Orders' property to hold a List of all the Order
        // objects/entities associated w/ this ToDo entity/object.
        // ?? add Foreign key Orders w/ attribute and property
        //private List<Order> _orders;
        //private ICollection<Order> _orders;

        // Constructor(s)
        // Default constructor
        /*public ToDo()
        {
            //ToDoId = toDoId;
            // Set ToDoDate to today's date.
            ToDoDate = new DateTime();
            //OrdersQueue = ordersQueue;
            // Set OrdersQueue to empty Queue of Order objects. 
            OrdersQueue = new Queue<Order>();
        }*/

        // Parameterized Constructor(s)
        /*public ToDo(DateTime date, Queue<Order> ordersQueue)
        {
            //ToDoId = toDoId;
            //Date = date;
            ToDoDate = date;
            //ToDoDate = new DateTime();
            OrdersQueue = ordersQueue;
        }*/

        /*public ToDo(Queue<Order> ordersQueue)
        //public ToDo(DateTime date, Queue<Order> ordersQueue)
        {
            //ToDoId = toDoId;
            //Date = date;
            //ToDoDate = date;
            ToDoDate = new DateTime();
            OrdersQueue = ordersQueue;
        }*/

        // Properties
        /*// If using Entity Framework do not need to specify [Key] as 
        // the EF assigns Properties named w/ 'ClassnameId' syntax as the
        // Class's Primary Key automatically. 
        //[Key]
        public int ToDoId { get => _toDoId; set => _toDoId = value; }
        // DataType attribute for formatting DateTime object
        //[DataType(DataType.DateTime, ErrorMessage = "DateTime is invalid.")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy - hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime ToDoDate { get => _toDoDate; set => _toDoDate = value; }
        
        public Queue<Order>? OrdersQueue { get => _ordersQueue; set => _ordersQueue = value; }
        // ?? create where orders sorted by date time in ascending order so they are queued
        // in first come first order in the 'set' property

        // Navigation Property:
        // The navigation property needs a virtual ICollection 'Orders' property to hold a List of
        // all the Order objects/entities associated w/ this ToDo entity/object. One ToDo
        // entity/object can have multiple associated Order objects/entities - one-to-many -
        // EF interprets below 'Orders' property as a foreign key property for the collection of
        // OrderIds (since OrderId is the Order entity's/object's primary key).  
        [ForeignKey("Order")]
        //[ForeignKey(nameof(OrderId))]
        public virtual ICollection<Order> Orders { get; set; }*/

        // Methods
        /*public override bool Equals(object? obj)
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
            string ToDoOutput = $"ToDo Id: {ToDoId}; ToDo Date: {ToDoDate}; ";
            if (OrdersQueue != null)
            {
                
                ToDoOutput += $"Orders in Queue: {OrdersQueue.Count}/n Orders: /n";
                foreach (Order order in OrdersQueue)
                {
                    ToDoOutput += $"{order.ToString} /n";
                }
            }
            else
            {
                ToDoOutput += $"Orders in Queue: none;";
            }
            return ToDoOutput;
        }*/

    }
}
