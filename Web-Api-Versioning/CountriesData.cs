using Web_Api_Versioning.Models.Domain;

namespace Web_Api_Versioning
{
    public  static class CountriesData
    {
        public static List<Country> Get()
        {
            var countryList = new[]
            {
                new{id=1,Name="India"},
                new{id=1,Name="Japan"},
                new{id=1,Name="Pakistan"},
                new{id=1,Name="Shri Lanka"},

            };
            return countryList.Select(c=>new Country { Id=c.id,Name=c.Name}).ToList();
        }
    }
}
