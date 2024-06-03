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
    public class PictureController
    {
        // De window die we laten zien op het scherm
        public static Home Window { get; set; }

        // De lijst met fotos die we laten zien
        public List<KioskPhoto> PicturesToDisplay = new List<KioskPhoto>();

        // Start methode die wordt aangeroepen wanneer de foto pagina opent.
        public void Start()
        {
            var now = DateTime.Now;
            int day = (int)now.DayOfWeek;

            // Initializeer de lijst met fotos
            // WAARSCHUWING. ZONDER FILTER LAADT DIT ALLES!
            // foreach is een for-loop die door een array loopt
            foreach (string dir in Directory.GetDirectories(@"../../../fotos"))
            {
                // Pak de mapnaam, bijvoorbeeld "0_Zondag"
                string dirName = Path.GetFileName(dir);
                // Splits de mapnaam om het dagnummer te verkrijgen
                string[] dirParts = dirName.Split('_');

                // Controleer of de eerste deel een getal is en vergelijk met de huidige dag
                if (int.TryParse(dirParts[0], out int dirDay) && dirDay == day)
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        // Voeg alleen de fotos van de huidige dag toe
                        PicturesToDisplay.Add(new KioskPhoto() { Id = 0, Source = file });
                    }
                }
            }

            // Update de fotos
            PictureManager.UpdatePictures(PicturesToDisplay);
        }

        // Wordt uitgevoerd wanneer er op de Refresh knop is geklikt
        public void RefreshButtonClick()
        {
            // Je kunt hier dezelfde code aanroepen als in Start() om te verversen
            Start();
        }
    }
}
