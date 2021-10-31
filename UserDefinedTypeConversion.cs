using System;

class UserDefinedTypeConversion{
    
class Country{
    public long CountryId { get; set; }
    public string Name { get; set; }

}

class CountryDto {
    public long CountryIdentityCode { get; set; }
    public string CountryName { get; set; }

    public static implicit operator Country(Country country){
        return new CountryDto(){
            CountryIdentityCode = country.CountryId,
            CountryName = country.Name
        };
    }
    
    public static implicit operator CountryDto(CountryDto countryDto){
        return new Country(){
            CountryId = countryDto.CountryIdentityCode,
            Name = countryDto.CountryName
        };
    }
}

    public static void Main(string[] args){

    //     Country country = new Country(){
    //         CountryId = 1,
    //         Name = "India"
    //     };

    //    // CountryDto countryDto = (CountryDto)country;

    //     Console.WriteLine(countryDto.ToString());

    }
}
