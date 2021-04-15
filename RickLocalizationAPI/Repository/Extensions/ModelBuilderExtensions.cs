using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            var dimensions = Seeder.GetDimensions();
            var ricks = Seeder.GetRicks(dimensions);
            var mortys = Seeder.GetMorty(dimensions);

            modelBuilder.Entity<Dimension>()
              .HasData(dimensions);

            modelBuilder.Entity<Rick>()
           .HasData(ricks);

            modelBuilder.Entity<Morty>()
            .HasData(mortys);
        }
    }

    public static class Seeder
    {
        internal static List<Dimension> GetDimensions()
        {
            var listDimensions = new List<Dimension>();

            var lines = File.ReadAllLines(@"../Repository/Seed/dimensions.txt");

            for (int i = 1; i < lines.Length; i++)
            {
                var name = lines[i].Split(';')[0].Trim();
                var image = lines[i].Split(';')[1].Trim();

                image = image.Contains("revision") ? image.Split(new string[] { "/revision" }, StringSplitOptions.None).First() : image;

                listDimensions.Add(new Dimension() { Id = i, Name = name, Image = image });
            }



            return listDimensions;
        }

        internal static List<Rick> GetRicks(List<Dimension> dimensions)
        {
            var ricks = new List<Rick>();

            foreach (var dimension in dimensions)
            {
                var rick = new Rick()
                {
                    Id = dimension.Id,
                    Name = $"Rick Sanchez ({dimension.Name})",
                    Image = "https://rickandmortyapi.com/api/character/avatar/1.jpeg",
                    Age = 70,
                    Species = "Human (Cyborg)",
                    Occupation = "Scientist",
                    DimensionId = dimension.Id,
                };

                ricks.Add(rick);
            }

            return ricks;
        }

        internal static List<Morty> GetMorty(List<Dimension> dimensions)
        {
            var mortys = new List<Morty>();

            foreach (var dimension in dimensions)
            {
                var morty = new Morty()
                {
                    Id = dimension.Id,
                    Name = $"Morty Smith ({dimension.Name})",
                    Image = "https://rickandmortyapi.com/api/character/avatar/2.jpeg",
                    Age = 14,
                    Occupation = "Student",
                    RickId = dimension.Id,
                    DimensionId = dimension.Id,
                };

                mortys.Add(morty);
            }

            return mortys;
        }
    }
}
