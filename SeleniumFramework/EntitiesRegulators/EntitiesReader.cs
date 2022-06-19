using SeleniumFramework.Extensions;
using SeleniumFramework.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using SeleniumFramework.Common;
using System.Linq;

namespace SeleniumFramework.EntitiesRegulators
{
    public class EntitiesReader<T> where T : Entity
    {
        private static readonly string dir = FileSearch.GetFullPath("Data");

        //Entity type is passed through the class. The corresponding .csv file is
        //read and a list of entities is created
        public static List<T> getEntities()
        {
            Type type = typeof(T);
            List<T> entities = new List<T>();

            using (var reader = new StreamReader($"{dir}\\{type.Name}.csv"))
            {
                string[][] entity = new string[2][];
                entity[0] = reader.ReadLine().Clean().Split(',');
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        entity[1] = line.Split(',').Select(item => item.Clean()).ToArray();
                        entities.Add(EntityGenerator<T>.CreateEntity(type, entity));
                    }
                }
            }

            return entities;
        }
    }
}
