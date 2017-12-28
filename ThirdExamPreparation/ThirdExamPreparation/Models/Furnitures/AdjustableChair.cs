using System;
using FurnitureManufacturer.Interfaces;
using System.Text;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs) : base(model, materialType, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            if(height < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.Height = height;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}