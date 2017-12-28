using System;
using FurnitureManufacturer.Interfaces;
using System.Text;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted;

        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs) : base(model, materialType, price, height, numberOfLegs)
        {
            this.isConverted = false;
        }

        public bool IsConverted => this.isConverted;

        public void Convert()
        {
            this.isConverted = true;
            this.Height = 0.10m;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(base.ToString());
            str.Append(string.Format(", State: {1}", this.NumberOfLegs, this.IsConverted ? "Converted" : "Normal"));
            return str.ToString();
        }
    }
}