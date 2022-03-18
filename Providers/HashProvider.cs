﻿using DesafioStone.Interfaces.ProvidersInterfaces;
using Scrypt;

namespace DesafioStone.Providers
{
    public class HashProvider : IHashProvider
    {
        private const int BlockSize = 8;
        private const int IterationCount = 16384;
        private const int ThreadCount = 1;

        private readonly ScryptEncoder _encoder;

        public HashProvider()
        {
            _encoder = new ScryptEncoder(IterationCount, BlockSize, ThreadCount);
        }

        public bool CompareHash(string plainValue, string hashedValue) =>
            _encoder.IsValid(hashedValue) && _encoder.Compare(plainValue, hashedValue);

        public string ComputeHash(string value) => _encoder.Encode(value);

        public bool ValidateHash(string hashedValue) => _encoder.IsValid(hashedValue);
    }
}