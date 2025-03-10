using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using DeveloperPathways.Data;
using DeveloperPathways.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPathways.Services
{
    public class CsvService
    {
      private readonly string _filePath;
        private readonly DbContextOptions<TitanicContext> _dbOptions;

        public CsvService()
        {
            _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "titanic.csv");
            _dbOptions = new DbContextOptionsBuilder<TitanicContext>()
                .UseSqlServer(@"Server=DESKTOP-V4GVEDM\SQLEXPRESS;Database=titanic;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;
        }

        public void RetrieveCsv()
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            try
            {
                using var reader = new StreamReader(_filePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                
                csv.Context.TypeConverterOptionsCache.GetOptions<double?>().NullValues.Add("");
                csv.Read();
                csv.ReadHeader();

                using var context = new TitanicContext(_dbOptions);

                CreateDatabase(context);
                var passengers = RetrieveRecords(csv, context);
                SaveRecordsToDatabase(passengers, context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing CSV: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private static void CreateDatabase(TitanicContext context)
        {
            context.Database.ExecuteSqlRaw("DROP TABLE IF EXISTS Passengers");
            context.Database.EnsureCreated();
        }

        private static List<Passenger> RetrieveRecords(CsvReader csv, TitanicContext context)
        {
            var passengers = new List<Passenger>();

            foreach (var record in csv.GetRecords<Passenger>())
            {
                if (!context.Passengers.Any(p => p.Name == record.Name && p.Ticket == record.Ticket))
                {
                    var passenger = new Passenger(record.Name, record.Pclass, record.Survived)
                    {
                        Sex = record.Sex,
                        Age = record.Age,
                        SibSp = record.SibSp,
                        Parch = record.Parch,
                        Ticket = record.Ticket,
                        Fare = record.Fare,
                        Cabin = record.Cabin,
                        Embarked = record.Embarked
                    };

                    passengers.Add(passenger);
                }
            }
            return passengers;
        }

        private static void SaveRecordsToDatabase(List<Passenger> passengers, TitanicContext context)
        {
            if (passengers.Count > 0 )
            {
                context.Passengers.AddRange(passengers);
                context.SaveChanges();
                Console.WriteLine($"{passengers.Count} new passengers added.");
            }
            else
            {
                Console.WriteLine("No new passengers to add.");
            }
        }
    }
}
