// For learning dictionaries in C#.

using System;
using System.Collections;

public class MethodGroup {
    private static Dictionary<char,char> charSet = new Dictionary<char,char>();

    public void SetUp() {
        string alphabet = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
        for(int i=0;i<26*2;i+=2) {
            charSet.Add(alphabet[i],alphabet[i+1]);
        }
    }
    
    // Not particularly proud of the nesting in this one.
    public string SetToLowercase(string input) {
        string _output = "";
        foreach(char c in input) {
            if(char.IsUpper(c)) {
                foreach(KeyValuePair<char,char> kvp in charSet) {
                if(kvp.Value == c)
                    _output += kvp.Key;
                }
            } else {
               _output += c; 
            }
        }
        
        return _output;
    }
}

public class TestArea {
    private static void Main() {
        MethodGroup _runtime = new MethodGroup();
        _runtime.SetUp();
        Console.WriteLine(_runtime.SetToLowercase("This is a test statement."));
        Console.WriteLine(_runtime.SetToLowercase("tHe QuiCK bRowN FOX jumpED oVEr tHe LazY DOg"));
        Console.WriteLine(_runtime.SetToLowercase("!!! TEST"));
    }
}