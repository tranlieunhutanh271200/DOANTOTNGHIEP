using System;

namespace Service.Core.Utils
{
    public class HashIds : IHashIds
    {
        private string _salt;
        private int _minLength;
        private int _maxLength;
        private int _count;
        public HashIds(string salt, int minLength = 10, int maxLength = 15, int count = 1)
        {
            _salt = salt;
            _minLength = minLength;
            _maxLength = maxLength;
            _count = count;
        }

        public string Decode(string value)
        {
            throw new NotImplementedException();
        }

        public string Encode(string value)
        {
            throw new NotImplementedException();
        }

        public void SetSalt(string salt)
        {
            throw new NotImplementedException();
        }
        private void UpdateHashes()
        {

        }
    }
}
