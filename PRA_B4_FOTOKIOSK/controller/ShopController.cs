using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRA_B4_FOTOKIOSK.controller
{
    public class ShopController
    {

        public static Home Window { get; set; }
            
        public void Start()
        {
            ShopManager shopManager = new ShopManager();

            // Vul de productlijst met producten
            ShopManager.Products.Add(new KioskProduct("Foto 10x15", 1, "test"));
            ShopManager.Products.Add(new KioskProduct("mok met foto", 2, "test"));
            ShopManager.Products.Add(new KioskProduct("shirt met foto", 3, "test"));

            // Foreach-loop om de prijslijst te genereren
            foreach (KioskProduct product in ShopManager.Products)
            {

                // Stel de prijslijst in aan de rechter kant.
                ShopManager.SetShopPriceList("Prijzen:\nFoto 10x15: €2.55\nmok met foto: €5\nshirt met foto €12");

                // Stel de bon in onderaan het scherm
                ShopManager.SetShopReceipt("Eindbedrag\n€");

         

                // Update dropdown met producten
                ShopManager.UpdateDropDownProducts();
            }
        
        }

        // Wordt uitgevoerd wanneer er op de Toevoegen knop is geklikt
        public void AddButtonClick()
        {
            
        }

        // Wordt uitgevoerd wanneer er op de Resetten knop is geklikt
        public void ResetButtonClick()
        {

        }

        // Wordt uitgevoerd wanneer er op de Save knop is geklikt
        public void SaveButtonClick()
        {
        }

    }
}
