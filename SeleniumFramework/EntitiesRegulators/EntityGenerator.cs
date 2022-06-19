using SeleniumFramework.Models;
using System;

namespace SeleniumFramework.EntitiesRegulators
{
    public class EntityGenerator<T> where T:Entity
    {
        public static T CreateEntity(Type type, string[][] args)
        {
            var entity = (T)Activator.CreateInstance(type);
            entity.Populate(args);
            return entity;
        }
    }
}
