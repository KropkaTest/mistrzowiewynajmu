using MistrzowieWynajmu.Models.Database;
using MistrzowieWynajmu.Models.Interfaces;
using System;
using System.Linq;

namespace MistrzowieWynajmu.Models.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OwnerRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public int AddOwner(Owner owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            owner.OwnerId = 0;

            _databaseContext.Owners.Add(owner);
            _databaseContext.SaveChanges();

            return owner.OwnerId;
        }

        public Owner GetOwner(int ownerId)
        {
            if (ownerId <= 0)
            {
                throw new ArgumentException("Id cannot be less than 0.", nameof(ownerId));
            }
            return _databaseContext.Owners.FirstOrDefault(owner => owner.OwnerId == ownerId);
        }
    }
}
