using System;

namespace Strategy
{
    //'IStrategy' interface
    public interface IEncodingStrategy
    {
        void EncodeValue(string value);
    }
    //'ConcreteStrategyA' class
    public class RSAEncodingStrategy : IEncodingStrategy
    {
        public void EncodeValue(string value)
        {
            // Implement Encoding strategy
            Console.WriteLine("Value {0} is Encoded using RSA Algorithm", value);
        }
    }
    //'ConcreteStrategyB' class
    public class DESncodingStrategy : IEncodingStrategy
    {
        public void EncodeValue(string value)
        {
            // Implement Encoding strategy
            Console.WriteLine("Value {0} is Encoded using DES Algorithm", value);
        }
    }

    //'ConcreteStrategyC' class
    public class BlowFishEncodingStrategy : IEncodingStrategy
    {
        public void EncodeValue(string value)
        {
            // Implement Encoding strategy
            Console.WriteLine("Value {0} is Encoded using BlowFish Algorithm", value);
        }
    }

    //'Context' class
    public class Encoding
    {
        private IEncodingStrategy _encodeStrategy;

        public Encoding(IEncodingStrategy encodeStrategy)
        {
            _encodeStrategy = encodeStrategy;
        }

        public void Encode(string value)
        {
            _encodeStrategy.EncodeValue(value);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IEncodingStrategy encodingStrategy = new RSAEncodingStrategy();
            Encoding encoding = new Encoding(encodingStrategy);
            encoding.Encode("10000011110");

            encodingStrategy = new DESncodingStrategy();
            encoding = new Encoding(encodingStrategy);
            encoding.Encode("10000011110");

            encodingStrategy = new BlowFishEncodingStrategy();
            encoding = new Encoding(encodingStrategy);
            encoding.Encode("10000011110");

            Console.ReadLine();
        }
    }
}