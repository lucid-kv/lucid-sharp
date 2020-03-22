using System.Net;

namespace Lucid
{
    public interface ILucid
    {
        HttpStatusCode Set(string key, string value);
        string Get(string key);
        HttpStatusCode Drop(string key);
    }
}
