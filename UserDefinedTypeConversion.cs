using System;

class UserDefinedTypeConversion
{

    class Country
    {
        public long CountryId { get; set; }
        public string Name { get; set; }
        public Country(long countryId, string name)
        {
            CountryId = countryId;
            Name = name;
        }
    }

    class CountryDto
    {
        public long CountryIdentityCode { get; set; }
        public string CountryName { get; set; }

        public CountryDto(long countryIdentityCode, string countryName)
        {
            CountryIdentityCode = countryIdentityCode;
            CountryName = countryName;
        }


        // Dto to Entity  - Overloading Country
        public static implicit operator Country(CountryDto countryDto)
        {
            return new Country(countryDto.CountryIdentityCode, countryDto.CountryName);
        }


        // Entity to Dto - Overloading CountryDto
        public static implicit operator CountryDto(Country country)
        {
            return new CountryDto(country.CountryId, country.Name);
        }
    }

    public static void Main(string[] args)
    {

        Country country = new Country(1, "USA");

        CountryDto countryDto = (CountryDto)country;
        Console.WriteLine(countryDto.CountryName);

        countryDto.CountryName = "Tokoyo";
        country = (Country)countryDto;

        Console.WriteLine(country.Name);
    }
}
