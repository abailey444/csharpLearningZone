using System;

public class Encrypt {
    private string? input;
    
    private static void Main() {
        Encrypt setUp = new Encrypt();
        setUp.Start();
    }

    private void Start() {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("DO NOT LOSE YOUR KEY");
        Console.ResetColor();
        GetPassword();
    }

    private void GetPassword() {
        Console.Write("Enter a password: ");
        input = Console.ReadLine();
        Console.Write("Enter the same password: ");
        string? _checkPassword = Console.ReadLine();
        if(_checkPassword == input) {
            DoEncryptionSteps();
        } else {
            GetPassword();
        }
    }

    private void DoEncryptionSteps() {
        long _generatedLong = GenerateLargeNumber();
        while(!CheckIfPrime(_generatedLong)) {
            _generatedLong = GenerateLargeNumber();
        }

        string _key = EncryptString(input,_generatedLong);
        Console.WriteLine("Key: " + _key);
    }

    private static string EncryptString(string? _in, long _prime) {
        // https://www.freecodecamp.org/news/understanding-encryption-algorithms/
        return "this";
    }

    private static bool CheckIfPrime(long _input) {
        // https://mathworld.wolfram.com/Baillie-PSWPrimalityTest.html
        bool _output;
        if(Math.Pow(3,_input) != Math.Abs(1%_input) || Math.Pow(3,_input) != 1%_input) {
            _output = true;
        } else {
            _output = false;
        }
        
        return _output;
    }

    private static long GenerateLargeNumber() {
        Random _random = new Random();
        long _output = _random.Next(10^64,10^128);
        return _output;
    }
}