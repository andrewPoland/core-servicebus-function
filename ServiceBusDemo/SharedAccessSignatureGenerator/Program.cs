using System;

namespace SharedAccessSignatureGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Expected arguments in format: SharedAccessSignatureGenerator.exe serviceBus keyName key");
            }

            string serviceBusUri = args[0];
            string keyName = args[1];
            string key = args[2];

            string subscriptionToken = SignatureFactory.BuildSignature(serviceBusUri,
                keyName, key, TimeSpan.FromDays(1));

            Console.WriteLine(subscriptionToken);
            Console.WriteLine("Push any key to close.");
            Console.ReadLine();
        }
    }
}
