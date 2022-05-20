using CleanArchMvc.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category: Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            //Name = name;            //Name = name ?? throw new ArgumentException("name is invalid");
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            //Id = id;
            //Name = name;
            DomainExceptionValidation.When(Id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name);
        }
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name.Name minimum 3 charecters.");

            Name = name;
        }
    }
}
