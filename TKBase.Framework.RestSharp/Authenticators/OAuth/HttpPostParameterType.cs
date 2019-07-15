using System.Runtime.Serialization;

namespace TKBase.Framework.RestSharp.Authenticators.OAuth
{
    [DataContract]
    internal enum HttpPostParameterType
    {
        Field,
        File
    }
}
