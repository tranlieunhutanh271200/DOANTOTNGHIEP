namespace Service.Core.Utils
{
    public interface IHashIds
    {
        void SetSalt(string salt);
        string Decode(string value);
        string Encode(string value);
    }
}
