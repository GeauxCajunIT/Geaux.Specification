// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.Specification.Exceptions;

public class DuplicateOrderChainException : Exception
{
    private const string _message = "The specification contains more than one Order chain!";

    public DuplicateOrderChainException()
        : base(_message)
    {
    }

    public DuplicateOrderChainException(Exception innerException)
        : base(_message, innerException)
    {
    }
}

