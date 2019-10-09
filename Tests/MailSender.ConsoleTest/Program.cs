using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MailSender.ConsoleTest.Data;

namespace MailSender.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SongsDB())
            {
                //db.Configuration.AutoDetectChangesEnabled = false;

                db.Database.Log = msg => Console.WriteLine("EF: {0}\r\n-----------------", msg);

                var bad_artists = db.Artists
                   .Where(a => a.Name.EndsWith("2"))
                   .Include(a => a.Tracks);

                foreach (var bad_artist in bad_artists) // .Include(a => a.Tracks) - требование о загрузке данных из связанной таблицы
                {
                    bad_artist.Name = $"{bad_artist.Name} - Bad";

                    for (var i = 0; i < 10; i++)
                        bad_artist.Tracks.Add(new Track
                        {
                            Name = $"Bad track {i + 1} from bad_artist.Name"
                        });
                }

                Console.ReadLine();
                Console.Clear();

                //db.ChangeTracker.DetectChanges();
                db.SaveChanges();

            }

            Console.ReadLine();

            using (var db = new SongsDB())
            {
                //db.Database.Log = msg => Console.WriteLine("EF: {0}\r\n-----------------", msg);

                var tracks_count = db.Tracks.Count();
                Console.WriteLine("В базе данных содержится {0} песен", tracks_count);

                var long_tracks = db.Tracks.Where(track => track.Length > 500);

                foreach (var info in long_tracks
                   .Select(t => new
                   {
                       ArtistName = t.Artist.Name,
                       t.Artist.Birthday
                   }))
                {
                    Console.WriteLine("Artist:{0}, date:{1}", info.ArtistName, info.Birthday);
                }

                //db.Database.ExecuteSqlCommand()
            }

            //Console.WriteLine();
            //Console.ReadLine();

            //Console.Clear();

            //using (var db = new SongsDB())
            //{
            //    db.Database.Log = msg => Console.WriteLine("EF: {0}\r\n-----------------", msg);

            //    for (var i = 1; i <= 3; i++)
            //    {
            //        var artist = new Artist
            //        {
            //            Name = $"Artist name {i}",
            //            Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(365 * (i + 20))), 
            //            Tracks = new List<Track>()
            //        };

            //        for (var j = 1; j < 3; j++)
            //        {
            //            var track = new Track
            //            {
            //                Name = $"Track {i + j}",
            //                Length = j * 456
            //            };
            //            artist.Tracks.Add(track);
            //        }

            //        db.Artists.Add(artist);
            //    }

            //    db.SaveChanges();
            //}

            Console.ReadLine();
        }
    }
}
