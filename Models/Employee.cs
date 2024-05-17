using System;

namespace FindMyLegalContact.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Employee Manager { get; set; }
    }
}