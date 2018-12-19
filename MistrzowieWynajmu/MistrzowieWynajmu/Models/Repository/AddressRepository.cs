using MistrzowieWynajmu.Models.Database;
using MistrzowieWynajmu.Models.Interfaces;
using System;
using System.Linq;

namespace MistrzowieWynajmu.Models.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DatabaseContext _databaseContext;

        public AddressRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public int AddAddress(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            address.AddressId = 0;

            _databaseContext.Addresses.Add(address);
            _databaseContext.SaveChanges();

            return address.AddressId;
        }

        public Address GetAddress(int addressId)
        {
            if (addressId <= 0)
            {
                throw new ArgumentException("Id cannot be less than 0.", nameof(addressId));
            }
            return _databaseContext.Addresses.FirstOrDefault(address => address.AddressId == addressId);
        }
    }
}
