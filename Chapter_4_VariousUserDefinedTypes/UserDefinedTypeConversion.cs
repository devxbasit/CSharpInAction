using System;

class UserDefinedTypeConversion
{
    public static void Main(string[] args)
    {

        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operator

        Country country = new Country(1, "USA");

        CountryDto countryDto = (CountryDto)country;
        Console.WriteLine(countryDto.CountryName);

        countryDto.CountryName = "Tokoyo";

        country = (Country)countryDto;

        Console.WriteLine(country.Name);


        Digit d1 = new Digit(5);

        // implicit
        byte b = d1;


        // explicit from byte to digit
        Digit d2 = (Digit)b;

        Console.WriteLine($"d1 = {d1}");
        Console.WriteLine($"b = {b}");
        Console.WriteLine($"d2 = {d2}");


    }
}


class Digit
{
    private readonly byte _digit;

    public Digit(byte digit)
    {
        if (digit > 9)
        {
            throw new ArgumentOutOfRangeException(nameof(digit), "Digit cannnot be greater than nine.");
        }

        _digit = digit;
    }

    public static implicit operator byte(Digit d) => d._digit;
    public static explicit operator Digit(byte b) => new Digit(b);


    public override string ToString() => $"{_digit}";

}


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


    // Dto to Entity  
    public static implicit operator Country(CountryDto countryDto)
    {
        return new Country(countryDto.CountryIdentityCode, countryDto.CountryName);
    }


    // Entity to Dto 
    public static implicit operator CountryDto(Country country)
    {
        return new CountryDto(country.CountryId, country.Name);
    }

    /*
    //https://www.infoworld.com/article/3606436/how-to-use-implicit-and-explicit-operators-in-csharp.html
    Note you cannot have both implicit and explicit operators defined in a class.
    If you have defined an implicit operator, you will be able to convert objects both implicitly and
    explicitly. However, if you have defined an explicit operator, you will be able to convert objects 
    explicitly only. This explains why you cannot have both implicit and explicit operators in a class. 
    Although an implicit cast is more convenient to use, an explicit cast provides better clarity and readability 
    of your code.
    */
}
