using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickShop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Definerar variabler som ska användas
            string butiksinformation = "Välkommen till Hans-Johnnys online-butik!\r\nFaktureringsadress är Sidoväg 19.\r\nBesöksadress är Ovangatan 9000.\r\nOm du har frågor kan du ringa oss på 000-00 00 00.\r\nNu kommer våran lagerinforamtion skrivas ut! Tack för att du besöker vår onlinebutik!\r\n \r\n";
            string[] movieNames = new string[25];
            string[] movieDirectors = new string[25];
            string[] movieRatings = new string[25];
            string[] movieRelease = new string[25];
            int[] movieRuntime = new int[25];
            int[] moviePrice = new int[25];
            int[] priceArray = new int[] { 59, 99, 129, 159, 199 };
            string[] albumNames = new string[25];
            string[] albumArtists = new string[25];
            string[] albumRatings = new string[25];
            string[] albumRelease = new string[25];
            int albumRuntime;
            int[] albumPrice = new int[25];
            string[] trackNames = new string[25];
            string[] featArtist = new string[25];
            int[] trackRuntime = new int[25]; 
            string[] trackRuntimesAsString = new string[25];

            List<Movie> movieList = new List<Movie>();
            List<Album> albumList = new List<Album>();
            Random roll = new Random();



            // Fyller listor med filmdata
            for (int i = 0; i < 25; i++)
            {
                movieNames[i] = "Movie no. " + (i+1);
                movieDirectors[i] = "Mr. Director no. " + (i+1);
                movieRatings[i] = $"{roll.Next(0, 10)}.{roll.Next(0,10)}";
                movieRelease[i] = $"{roll.Next(0, 3)}{roll.Next(0, 10)}{roll.Next(0, 10)}{roll.Next(0, 10)}:{roll.Next(0, 2)}{roll.Next(0, 10)}:{roll.Next(0, 4)}{roll.Next(0, 10)}";


                // Koden ovan skapar releasedatum med månadsnummer > 12 och dagnummer > 30; dessa if-satser fixar det
                if ((Convert.ToInt32(movieRelease[i].Substring(5,2)) > 12))
                {
                    movieRelease[i] = movieRelease[i].Remove(6);
                    movieRelease[i] += $"{roll.Next(0, 3)}:{roll.Next(0, 4)}{roll.Next(0, 10)}";
                }
                if (Convert.ToInt32(movieRelease[i].Substring(8,2)) > 30)
                {
                    movieRelease[i] = movieRelease[i].Remove(9);
                    movieRelease[i] += "0";
                }

                movieRuntime[i] = roll.Next(55, 255);
                moviePrice[i] = priceArray[roll.Next(0, (priceArray.Length - 1))];
            }


            // Använder filmdata för att skapa film objekt i en lista av filmobjekt
            // Samma loop skapar spårnamn, featured artists och spårtider för album
            for (int i = 0; i < 25; i++)
            {
                movieList.Add(new Movie(movieNames[i], movieDirectors[i], (short)Convert.ToDouble(movieRatings[i]), movieRuntime[i], movieRelease[i], moviePrice[i]));
                trackNames[i] = "Track no. " + (i + 1);
                featArtist[i] = "Feat. Artist. No. " + (i + 1);
                trackRuntime[i] = roll.Next(120,300);
            }


            // Räknar snabbt ut albumets runtime i minuter
            albumRuntime = trackRuntime.Sum();
            albumRuntime = (albumRuntime / 60);


            // Skapar albumdata
            for (int i = 0; i < 25; i++)
            {
                albumNames[i] = "Album no. " + (i + 1);
                albumArtists[i] = "Band/artist name no. " + (i + 1);
                albumRatings[i] = $"{roll.Next(0, 10)}.{roll.Next(0, 10)}";
                albumRelease[i] = $"{roll.Next(0, 3)}{roll.Next(0, 10)}{roll.Next(0, 10)}{roll.Next(0, 10)}:{roll.Next(0, 2)}{roll.Next(0, 10)}:{roll.Next(0, 4)}{roll.Next(0, 10)}";


                // Koden ovan skapar releasedatum med månadsnummer > 12 och dagnummer > 30; dessa if-satser fixar det
                if ((Convert.ToInt32(albumRelease[i].Substring(5, 2)) > 12))
                {
                    albumRelease[i] = albumRelease[i].Remove(6);
                    albumRelease[i] += $"{roll.Next(0, 3)}:{roll.Next(0, 4)}{roll.Next(0, 10)}";
                }
                if (Convert.ToInt32(albumRelease[i].Substring(8, 2)) > 30)
                {
                    albumRelease[i] = albumRelease[i].Remove(9);
                    albumRelease[i] += "0";
                }


                albumPrice[i] = priceArray[roll.Next(0, (priceArray.Length - 1))];
            }

            // Använder albumdata för att skapa albumobjekt i en albumlista.
            for (int i = 0; i < 25; i++)
            {
                albumList.Add(new Album(albumNames[i], albumArtists[i], (short)Convert.ToDouble(albumRatings[i]), albumRuntime, albumRelease[i], albumPrice[i], trackNames, trackRuntime, featArtist));
            }

            // Konverterar albumspårens runtime från integer till string, samtidigt som det konverteras från sekunder till minuter och sekunder med format M:SS
            // Detta görs för lättare utskrift senare i koden.
            for (int i = 0; i < 25; i++)
            {
                trackRuntimesAsString[i] = $"{Convert.ToString(trackRuntime[i] / 60)}:{Convert.ToString(trackRuntime[i] % 60)}";
            }


            // Sorterar filmer efter releasedatum och album efter användarbetyg
            movieList.Sort((x,y) => x.Releasedate.CompareTo(y.Releasedate));
            albumList.Sort((x, y) => x.Rating.CompareTo(y.Rating));
            // Och vänder sen listan så den är fallande istället för ökande.
            movieList.Reverse();
            albumList.Reverse();


            // Skriver ut all butiksinformation och väntar på input
            Console.WriteLine(butiksinformation);
            Console.ReadKey();
            Console.Clear();


            // Skriver ut filminformatio  och väntar på input
            foreach (Movie m in movieList)
            {
                Console.WriteLine();
                Console.WriteLine($"{m.Name}\r\nwas directed by {m.Artist}\r\nhas a rating of {m.Rating}\r\nwas released on {m.Releasedate}\r\nand costs {m.Price}:-\r\n");
            }
            Console.SetWindowPosition(0, 0);
            Console.ReadKey();
            Console.Clear();

            // Skriver ut albuminformation och väntar på input
            foreach (Album a in albumList)
            {
                Console.WriteLine();
                Console.WriteLine($"{a.Name}\r\nwas directed by {a.Artist}\r\nhas a rating of {a.Rating}\r\nwas released on {a.Releasedate}\r\nand costs {a.Price}\r\n");
                for (int i = 0; i < 25; i++)
                {
                    Console.WriteLine($"{a.tracknames[i]} has a length of {trackRuntimesAsString[i]} and features the artist {a.trackfeatartists[i]}");
                }
            }
            Console.SetWindowPosition(0, 0);
            Console.ReadKey();

            // Program klart    


            // Tog <3h att skriva
        }
    }
}
