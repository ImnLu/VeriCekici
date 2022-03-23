using System;
using System.Net;

namespace SitedenVeriCekici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Örnek kullanım
            string veri = VeriCek("youtube.com", "<title>", "</title>");
            Console.WriteLine(veri);

            Console.ReadKey();
        }

        /* 
         * İlk değişkene siteyi, ikinci değişkene seçilecek ilk değeri,
         * üçüncü değişkene ise seçilecek son değer girildiğinde
         * arada kalan yazıları geri döndürür.
         */
        static string VeriCek(string site, string ilksecim, string sonsecim)
        {
            WebClient webClient = new WebClient();

            // Girilen sitenin başında "http://" yazmıyorsa girilen sitenin başına ekler.
            if (site.Substring(0, 7) != "http://")
            {
                site = "http://" + site;
            }

            // Siteden veri çekme işlemini başlatır.
            try
            {
                // Siteyi indirir.
                string VeriCekSiteVeri = webClient.DownloadString(site);

                // İlk değer ile son değer arasındaki değerleri seçer.
                int VeriCekBaslangic = VeriCekSiteVeri.IndexOf(ilksecim) + ilksecim.Length;
                int VeriCekBitis = VeriCekSiteVeri.Substring(VeriCekBaslangic).IndexOf(sonsecim);
                string VeriCekDeger = VeriCekSiteVeri.Substring(VeriCekBaslangic, VeriCekBitis);

                return VeriCekDeger;
            }
            catch
            {
                return "Site indirilemedi!";
            }
        }
    }
}

// Mali 22:32 23.03.2022
