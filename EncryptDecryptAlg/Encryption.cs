using System;
using System.Numerics;
using System.Security.Cryptography;

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
        BigInteger _generatedOne = GenerateLargeNumber(16);
        while(!IsPrime(_generatedOne,90)) {
            _generatedOne = GenerateLargeNumber(16);
        }
        Console.WriteLine("Prime 1: " + _generatedOne);

        BigInteger _generatedTwo = GenerateLargeNumber(16);
        while(!IsPrime(_generatedTwo,90)) {
            _generatedTwo = GenerateLargeNumber(16);
        }
        Console.WriteLine("Prime 2: " + _generatedTwo);

        BigInteger c,d,_public,_private;
        c = _generatedOne * _generatedTwo;
        d = (_generatedOne-1)*(_generatedTwo-1);
        _public = GeneratePublic(d);
        _private = GeneratePrivate(d,_public);
        Console.WriteLine(_public);
    }

    // https://www.freecodecamp.org/news/understanding-encryption-algorithms/
    // https://www.c-sharpcorner.com/UploadFile/75a48f/rsa-algorithm-with-C-Sharp2/
    private static BigInteger GeneratePublic(BigInteger _d) {
        // RSA
        BigInteger _output = 0;
        BigInteger i = _d/2;
        if(i%2 == 0) {
            for(BigInteger _i=_d/2;_i<_d;_i++) {
                if(IsPrime(_i,10) && BigInteger.GreatestCommonDivisor(_i,_d) == 1)
                    _output = i;
            } 
        } else {
            for(BigInteger _i=_d/2;_i<_d;_i+=2) {
                if(IsPrime(_i,10) && BigInteger.GreatestCommonDivisor(_i,_d) == 1)
                    _output = _i;
            } 
        }

        return _output;
    }

    private static BigInteger GeneratePrivate(BigInteger _d, BigInteger _public) {
        BigInteger _output = -1;
        return _output;
    }

    private static bool IsPrime(BigInteger _in, int _certainty) {
        if(_in % 2 == 0)
            return false;
        
        BigInteger d = _in - 1;
        int s = 0;

        while(d % 2 == 0) {
            d /= 2;
            s += 1;
        }

        RandomNumberGenerator _rng = RandomNumberGenerator.Create();
        byte[] _data = new byte[_in.ToByteArray().LongLength];
        BigInteger a;

        for(int i=0; i<_certainty; i++) {
            do {
                _rng.GetBytes(_data);
                a = new BigInteger(_data);
            } while(a < 2 || a >= _in - 2);

            BigInteger x = BigInteger.ModPow(a,d,_in);
            if(x == 1 || x == _in - 1)
                continue;

            for(int o=1;o<s;o++) {
                x = BigInteger.ModPow(x,2,_in);
                if(x == 1)
                    return false;
                if(x == _in - 1)
                    break;
            }

            if(x != _in - 1)
                return false;
        }

        return true;
    }

    private static BigInteger GenerateLargeNumber(int _length) {
        Random _rand = new Random();
        byte[] _data = new byte[_length];
        _rand.NextBytes(_data);
        var _bigInteger = new BigInteger(_data.Concat(new byte[] { 0 }).ToArray());
        return _bigInteger;
    }
}