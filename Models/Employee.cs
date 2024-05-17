namespace FindMyLegalContact.Models
{
    public class Employee
    {
        Guid Id { get; set; }
        Employee Manager { get; set; }
    }
}