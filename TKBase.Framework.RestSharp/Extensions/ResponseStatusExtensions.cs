﻿using System;
using System.Net;

namespace TKBase.Framework.RestSharp.Extensions
{
    public static class ResponseStatusExtensions
    {
        /// <summary>
        /// Convert a <see cref="ResponseStatus"/> to a <see cref="WebException"/> instance.
        /// </summary>
        /// <param name="responseStatus">The response status.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">responseStatus</exception>
        public static WebException ToWebException(this ResponseStatus responseStatus)
        {
            switch (responseStatus)
            {
                case ResponseStatus.None:
                    return new WebException("The request could not be processed.",
                        WebExceptionStatus.ServerProtocolViolation
                    );

                case ResponseStatus.Error:
                    return new WebException("An error occurred while processing the request.",
                        WebExceptionStatus.ServerProtocolViolation
                    );

                case ResponseStatus.TimedOut:
                    return new WebException("The request timed-out.",
                        WebExceptionStatus.Timeout
                    );

                case ResponseStatus.Aborted:
                    return new WebException("The request was aborted.",
                        WebExceptionStatus.Timeout
                    );

                default:
                    throw new ArgumentOutOfRangeException(nameof(responseStatus));
            }
        }
    }
}