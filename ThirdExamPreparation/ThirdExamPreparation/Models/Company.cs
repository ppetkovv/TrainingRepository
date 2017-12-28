using Bytes2you.Validation;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Models.Furnitures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FurnitureManufacturer.Models
{
    // Finish the class
    public class Company : ICompany
    {
        private readonly string name;
        private readonly string registrationNumber;
        private readonly ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            Guard.WhenArgument(name, "name").IsNull().Throw();
            Guard.WhenArgument(name.Length, "name length").IsLessThan(5).Throw();
            Guard.WhenArgument(registrationNumber, "registration number").IsNull().Throw();
            Guard.WhenArgument(registrationNumber.Length, "registration number length").IsNotEqual(10).Throw();
            if (!registrationNumber.All(currentDigit => Char.IsDigit(currentDigit)))
            {
                throw new ArgumentException();
            }
            this.name = name;
            this.registrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name => this.name;

        public string RegistrationNumber => this.registrationNumber;

        public ICollection<IFurniture> Furnitures => this.furnitures;

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public string Catalog()
        {
            var strBuilder = new StringBuilder();
            // Finish it

            strBuilder.AppendLine(string.Format("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber,this.furnitures.Count != 0 ? this.furnitures.Count.ToString() : "no", furnitures.Count != 1 ? "furnitures" : "furniture"));
            List<IFurniture> orderedFurnitures = this.furnitures.OrderByDescending(f => f.Price).ThenByDescending(f => f.Model).ToList();
            foreach (IFurniture furniture in orderedFurnitures)
            {
                strBuilder.AppendLine(furniture.ToString());
            }

            return strBuilder.ToString().Trim();
        }

        public IFurniture Find(string model)
        {
            return this.furnitures.Where(currentFurniture => currentFurniture.Model.Equals(model)).FirstOrDefault();
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }
    }
}