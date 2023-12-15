using System;

public static class ClampScript {
    private static void Main(string[] args) {
        float x = Clamp(30,0,100); // Should return 30
        float y = Clamp(0,30,100); // Should return 30
        float z = Clamp(130,0,100); // Should return 100
        Console.WriteLine(x);
        Console.WriteLine(y);
        Console.WriteLine(z);
    } 

    private static float Clamp(float input, float min, float max) {
        float _output;
        if(input > max)
            _output = max;
        if(input < min)
            _output = min;
        else
            _output = input;
        
        return _output;
    }
}


