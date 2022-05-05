using System;
using System.Collections.Generic;

class CustomExceptions
{
    public static void Main()
    {


        // .NET Framework originally defined ApplicationException as the
        // base class for all the custom exceptions. Since there was no enforcing, the base
        // class library itself never adopted this best practice widely. For this reason, the
        // current best practice is deriving all the custom exceptions from Exception,
        // as you can read in the official documentation:
        // https://docs.microsoft.com/en-us/dotnet/api/system.applicationexception?view=netcore-3.1

        GetCustomerNames("hello");

    }

    public static IList<string> GetCustomerNames(string queryKeyword)
    {

        var repository = new Repository("CustomerHttpRateRepository");

        try
        {
            return repository.GetCustomerNames(queryKeyword);
        }
        catch (Exception err)
        {
            // The exception being caught is passed to the constructor as an argument in order to
            // preserve the original cause of the error, while still throwing the custom exception that
            // better represents the nature of the error.

            throw new DataLayerException($"Error on repository {repository.RepositoryName}", err, queryKeyword);
        }

    }
}


public class DataLayerException : Exception
{
    public DataLayerException(string queryKeyword = null) : base()
    {
        this.QueryKeyword = queryKeyword;
    }

    public DataLayerException(string message, string queryKeyword = null) : base(message)
    {
        this.QueryKeyword = queryKeyword;
    }

    public DataLayerException(string message, Exception innerException, string queryKeyword = null) : base(message, innerException)
    {
        this.QueryKeyword = queryKeyword;
    }

    public string QueryKeyword { get; private set; }

}

public class Repository
{
    public string RepositoryName { get; private set; }

    public Repository(string repositoryName) => this.RepositoryName = repositoryName;
    public IList<string> GetCustomerNames(string QueryKeyword)
    {
        throw new NotImplementedException();
    }

}


