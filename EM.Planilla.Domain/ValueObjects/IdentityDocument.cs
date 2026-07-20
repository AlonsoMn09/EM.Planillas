using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.ValueObjects
{
    public class IdentityDocument
    {
        public string Type { get; init; }
        public string Number { get; init; }
        public IdentityDocument() { }
        public IdentityDocument(string type, string number) {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Type cannot be null or empty.", nameof(type));
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Number cannot be null or empty.", nameof(number));
            Type = type;
            Number = number;
        }
        public static IdentityDocument Create(string type, string number) 
        { 
            return new IdentityDocument(type, number);
        }
    }
}