using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PRA_B4_FOTOKIOSK.controller
{
    public class ShopController
    {

        public static Home Window { get; set; }
        private List<OrderedProduct> orderedProducts = new List<OrderedProduct>();

        public void Start()
        {

            ShopManager shopManager = new ShopManager();

            // Vul de productlijst met producten
            ShopManager.Products.Add(new KioskProduct() { Name = "Foto 10x15", Price = (int)2.55 });

            ShopManager.Products.Add(new KioskProduct() { Name = "Mok met foto", Price = (int)5 });

            ShopManager.Products.Add(new KioskProduct() { Name = "Shirt met foto", Price = (int)12 });
            

            // Foreach-loop om de prijslijst te genereren

            foreach (KioskProduct product in ShopManager.Products)

            {

                // Stel de prijslijst in aan de rechter kant.

                ShopManager.SetShopPriceList("Prijzen:\nFoto 10x15: €2\nmok met foto: €5\nshirt met foto €12");

                // Stel de bon in onderaan het scherm

                ShopManager.SetShopReceipt("Eindbedrag\n€");


                // Update dropdown met producten

                ShopManager.UpdateDropDownProducts();

            }

        }

        // Wordt uitgevoerd wanneer er op de Toevoegen knop is geklikt
        private double CalculateGrandTotal(string receipt)
        {
            double grandTotal = 0.0;
            string[] lines = receipt.Split('\n');
            foreach (string line in lines)
            {
                if (line.Contains('='))
                {
                    string[] parts = line.Split('=');
                    if (parts.Length == 2 && double.TryParse(parts[1].Replace("€", "").Trim(), out double lineTotal))
                    {
                        grandTotal += lineTotal;
                    }
                }
            }
            return grandTotal;
        }

        public void AddButtonClick()
        {
            // Haal het geselecteerde product, foto-id en aantal op
            var selectedProduct = ShopManager.GetSelectedProduct();
            var fotoId = ShopManager.GetFotoId();
            var amount = ShopManager.GetAmount();

            // Check of alle vereiste gegevens zijn ingevuld
            if (selectedProduct != null && fotoId.HasValue && amount.HasValue && amount > 0)
            {
                // Bereken het totaalbedrag voor dit product

                decimal total = selectedProduct.Price * amount.Value;

                // Voeg de productinformatie en het totaalbedrag toe aan de bon
                string receiptLine = $"{selectedProduct.Name} (Foto {fotoId}): {amount} x €{selectedProduct.Price} = €{total}\n";
                ShopManager.AddShopReceipt(receiptLine);

                // Bereken het eindbedrag en update de bon
                string currentReceipt = ShopManager.GetShopReceipt();
                double grandTotal = CalculateGrandTotal(currentReceipt);
                ShopManager.SetShopReceipt(currentReceipt + $"\nEindbedrag: €{grandTotal}");
            }
            else
            {
                // Toon een foutmelding als de gegevens niet correct zijn ingevuld
                MessageBox.Show("Vul alle velden correct in.");
            }
        }


        // Wordt uitgevoerd wanneer er op de Resetten knop is geklikt
        public void ResetButtonClick()
        {
            // Reset de bon en het invoerformulier
            ShopManager.SetShopReceipt("Eindbedrag\n€");
            Window.tbFotoId.Text = "";
            Window.tbAmount.Text = "";
            Window.cbProducts.SelectedIndex = -1;
        }

        // Wordt uitgevoerd wanneer er op de Save knop is geklikt
        public void SaveButtonClick()
        {
            {
                // Haal de huidige bon op
                string receipt = ShopManager.GetShopReceipt();

                // Definieer het pad van het bestand waar de bon zal worden opgeslagen
                string filePath = "receipt.txt";

                // Schrijf de inhoud van de bon naar het bestand
                File.WriteAllText(filePath, receipt);

                // Toon een bericht dat de bon is opgeslagen
                MessageBox.Show("Bon is opgeslagen.");
            }
        }


    }

}
