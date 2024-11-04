namespace ExpenseTracker.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool InBuilt { get; set; }
        public int? UserId { get; set; }
        public Users? User { get; set; }
    }
}
