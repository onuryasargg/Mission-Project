namespace Mission_Project.Models
{
    public class Technology
    {
        public string? Text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class Person
    {
        public byte Age { get; set; }
        public List<Technology>? Technologies { get; set; }
        public long IdentificationNumber { get; set; }
        public byte Experience { get; set; }
    }
}
