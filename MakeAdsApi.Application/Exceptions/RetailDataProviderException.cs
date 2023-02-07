using System;

namespace MakeAdsApi.Application.Exceptions;

public class RetailDataProviderException: Exception
{
    public RetailDataProviderException(string message): base(message)
    {
        
    }
}