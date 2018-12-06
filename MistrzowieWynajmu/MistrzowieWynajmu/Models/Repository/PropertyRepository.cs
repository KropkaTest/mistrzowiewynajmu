using MistrzowieWynajmu.Models.Database;
using MistrzowieWynajmu.Models.Interfaces;
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

        public List<Property> GetAll() => _databaseContext.Properties.ToList();

        public Property GetProperty(int propertyId) => _databaseContext.Properties.FirstOrDefault(property => property.Id == propertyId);
    }
}
