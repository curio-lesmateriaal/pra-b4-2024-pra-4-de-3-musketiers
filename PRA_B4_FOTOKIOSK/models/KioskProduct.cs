using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRA_B4_FOTOKIOSK.models
{
    public class KioskProduct
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public KioskProduct(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public KioskProduct()
        {
        }
    }
}
public class OrderedProduct
{
    public int PhotoNumber { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    public OrderedProduct(int photoNumber, string productName, int quantity, decimal unitPrice)
    {
        PhotoNumber = photoNumber;
        ProductName = productName;
        Quantity = quantity;
        TotalPrice = quantity * unitPrice;
    }

    public override string ToString()
    {
        return $"{ProductName} (Foto {PhotoNumber}): {Quantity} x €{TotalPrice / Quantity:C2} = €{TotalPrice:C2}";
    }
}
