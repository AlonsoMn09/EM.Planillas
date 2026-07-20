using EM.Planilla.Domain.Enums;
using EM.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public IdentityDocument Document { get; private set; }
        public string Email { get; private set; }
        public EmployeeStatus Status { get; private set; }
        public Employee()
        {
            
        }
        private Employee(string name, string lastName, IdentityDocument document, string email)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be null or empty", nameof(name));
            if(string.IsNullOrEmpty(lastName)) throw new ArgumentException("LastName cannot be null or empty", nameof(lastName));
            if(document == null) throw new ArgumentNullException(nameof(document), "Document cannot be null");
            if(string.IsNullOrEmpty(email)) throw new ArgumentException("Email cannot be null or empty", nameof(email));

            Name = name;
            LastName = lastName;
            Document = document;
            Email = email;
            Status = EmployeeStatus.Active;
        }
        public static Employee Create(string name, string lastName, IdentityDocument document, string email)
        {
            return new Employee(name, lastName, document, email);
        }

        public void UpdateStatus(EmployeeStatus newStatus)
        {
            //TODO: Validate if the new status is different from the current status
            Status = newStatus;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
