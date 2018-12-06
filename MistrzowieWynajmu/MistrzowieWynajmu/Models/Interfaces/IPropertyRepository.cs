using System.Collections.Generic;

namespace MistrzowieWynajmu.Models.Interfaces
{
    public interface IPropertyRepository
    {
        List<Property> GetAll();
        Property GetProperty(int propertyId);
    }
}
