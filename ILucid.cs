namespace Lucid
{
    public interface ILucid
    {
        void Set(string key, string value);
        void Get(string key);
        void Drop(string key);
    }
}
