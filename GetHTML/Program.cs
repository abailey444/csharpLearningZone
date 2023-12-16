// Grabs information from RGL.gg

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;

Trawler runtime = new Trawler();
runtime.Start();

public class Trawler {
    static readonly HttpClient client = new HttpClient();
    
    public void Start() {
        Console.WriteLine("Calling RLG.gg at {0:HH:mm:ss tt}",DateTime.Now);

        string url = "https://rgl.gg/";
        var awaiter = ResponseFromURL(url);
        if(awaiter.Result != "") {
            WriteToFile(awaiter.Result);
            string tempPath = System.IO.Directory.GetCurrentDirectory() + @"\output.txt";
            Console.WriteLine("Response written to output file @ {0}", tempPath);
        }
    }

    private void WriteToFile(string result) {
        string path = System.IO.Directory.GetCurrentDirectory();
        path += @"\output.txt";
        if(!File.Exists(path)) {
            using(StreamWriter sw = File.CreateText(path)) {
                sw.WriteLine(result);
            }
        }
    }

    private static async Task<string> ResponseFromURL(string url) {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
        client.DefaultRequestHeaders.Accept.Clear();
        var response = client.GetStringAsync(url);
        return await response;
    } 
}