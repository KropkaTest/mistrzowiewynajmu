using MistrzowieWynajmu.Models.Database;
using MistrzowieWynajmu.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MistrzowieWynajmu.Models.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PropertyRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public int AddProperty(Property property, Address address, Owner owner)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            property.Id = 0;

            property.Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            property.OwnerId = owner.OwnerId;

            property.Address = address ?? throw new ArgumentNullException(nameof(address));
            property.AddressId = address.AddressId;

            _databaseContext.Properties.Add(property);
            _databaseContext.SaveChanges();

            return property.Id;
        }

        public void DeleteProperty(Property property, Address address, Owner owner)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            _databaseContext.Properties.Remove(property);
            _databaseContext.SaveChanges();

            _databaseContext.Addresses.Remove(address);
            _databaseContext.SaveChanges();

            _databaseContext.Owners.Remove(owner);
            _databaseContext.SaveChanges();
        }

        public List<Property> GetAllProperties() => _databaseContext.Properties.ToList();

        public Property GetProperty(int propertyId)
        {
            if(propertyId <= 0)
            {
                throw new ArgumentException("Id cannot be less than 0.", nameof(propertyId));
            }
            return _databaseContext.Properties.FirstOrDefault(property => property.Id == propertyId);
        }

        public int UpdateProperty(Property property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            _databaseContext.Properties.Update(property);
            _databaseContext.SaveChanges();
            return property.Id;
        }
    }
}
