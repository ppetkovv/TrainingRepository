using System;
using Bytes2you.Validation;
using FurnitureManufacturer.Interfaces;
using System.Text;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, string materialType, decimal price, decimal height, decimal length, decimal width) : base(model, materialType, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length { get => this.length; private set { this.length = value; } }
        public decimal Width { get => this.width; private set { this.width = value; } }
        public decimal Area => this.Length * this.Width;

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(base.ToString());
            str.Append(string.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area));
            return str.ToString();
        }
    }
}