namespace DomainModelLayer
{
    public class Customer : BaseModel
    {
        public virtual string Name { get; set; }

        public virtual string LastName { get; set; }

        public virtual int NumberOfPax { get; set; }

        public virtual Hotel CustomerHotel { get; set; } = new Hotel();
    }
}