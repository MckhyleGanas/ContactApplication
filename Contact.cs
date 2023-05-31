namespace ContactManager
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName => $"{Name} ({PhoneNumber})";

        public Contact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
