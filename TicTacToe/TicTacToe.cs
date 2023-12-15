using System;

public class InOut {
    public string[] Tiles = ["-","-","-",
                             "-","-","-",
                             "-","-","-"];
    public int ChosenTile { get; set; }

    public InOut() {
        Console.WriteLine("Welcome!");
    }
}

public class TicTacToe {
    InOut inOut = new InOut();
    private static void Main() {
        TicTacToe start = new TicTacToe();
        start.Start();
    }
    
    private void Start() {
        Console.WriteLine("Grid coordinates: \n0 1 2\n3 4 5\n6 7 8\n");
        Console.Write("Enter a tile number: ");
        TryParseInput();
    }

    private void TryParseInput() {
        int _tile;
        if(int.TryParse(Console.ReadLine(), out _tile) && _tile > -1 && _tile < 9) {
            if(inOut.Tiles[_tile] == "x" || inOut.Tiles[_tile] == "o") {
                Console.WriteLine("Cannot choose a tile that's already occupied.");
                Console.Write("Enter a valid number: ");
                TryParseInput();
            } else {
                inOut.ChosenTile = _tile;
                inOut.Tiles[inOut.ChosenTile] = "x";
                DrawLines();
            }
            
        } else {
            Console.Write("Enter a valid number: ");
            TryParseInput();
        }
    }

    private void DrawLines() {
        Console.Clear();
        for(int i=0;i<inOut.Tiles.Length;i++) {
            if(i==2 || i==5)
                Console.Write(inOut.Tiles[i] + "\n");
            else
                Console.Write(inOut.Tiles[i] + " ");
        }

        CheckWinner(false);
    }

    private void CheckWinner(bool isAITurn) {
        int[] _magicSquare = [8,1,6,
                              3,5,7,
                              4,9,2];
        int[] _oSquare =     [0,0,0,
                              0,0,0,
                              0,0,0];
        int[] _xSquare =     [0,0,0,
                              0,0,0,
                              0,0,0];
        bool _hasWon = false;

        int iteration = 0;
        foreach(string item in inOut.Tiles) {
            if(item == "x")
                _xSquare[iteration] = _magicSquare[iteration];
            if(item == "o")
                _oSquare[iteration] = _magicSquare[iteration];

            iteration++;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        if((_xSquare[0] + _xSquare[3] + _xSquare[6]) == 15) {
            Console.WriteLine("\nX WINS");
            _hasWon = true;
        } else if((_xSquare[1] + _xSquare[4] + _xSquare[7]) == 15) {
            Console.WriteLine("\nX WINS");
            _hasWon = true;
        } else if((_xSquare[2] + _xSquare[5] + _xSquare[8]) == 15) {
            Console.WriteLine("\nX WINS");
            _hasWon = true;
        } else if((_xSquare[0] + _xSquare[1] + _xSquare[2]) == 15) {
            Console.WriteLine("\nX WINS");
            _hasWon = true;
        } else if((_xSquare[3] + _xSquare[4] + _xSquare[5]) == 15) {
            Console.WriteLine("\nX WINS");
            _hasWon = true;
        } else if((_xSquare[6] + _xSquare[7] + _xSquare[8]) == 15) {
            Console.WriteLine("\nX WINS");
            _hasWon = true;
        } else if((_xSquare[0] + _xSquare[4] + _xSquare[8]) == 15) {
            Console.WriteLine("\nX WINS");
            _hasWon = true;
        } else if((_xSquare[6] + _xSquare[4] + _xSquare[2]) == 15) {
            Console.WriteLine("\nX WINS");
            _hasWon = true;
        }

        
        if((_oSquare[0] + _oSquare[3] + _oSquare[6]) == 15) {
            Console.WriteLine("\nO WINS");
            _hasWon = true;
        } else if((_oSquare[1] + _oSquare[4] + _oSquare[7]) == 15) {
            Console.WriteLine("\nO WINS");
            _hasWon = true;
        } else if((_oSquare[2] + _oSquare[5] + _oSquare[8]) == 15) {
            Console.WriteLine("\nO WINS");
            _hasWon = true;
        } else if((_oSquare[0] + _oSquare[1] + _oSquare[2]) == 15) {
            Console.WriteLine("\nO WINS");
            _hasWon = true;
        } else if((_oSquare[3] + _oSquare[4] + _oSquare[5]) == 15) {
            Console.WriteLine("\nO WINS");
            _hasWon = true;
        } else if((_oSquare[6] + _oSquare[7] + _oSquare[8]) == 15) {
            Console.WriteLine("\nO WINS");
            _hasWon = true;
        } else if((_oSquare[0] + _oSquare[4] + _oSquare[8]) == 15) {
            Console.WriteLine("\nO WINS");
            _hasWon = true;
        } else if((_oSquare[6] + _oSquare[4] + _oSquare[2]) == 15) {
            Console.WriteLine("\nO WINS");
            _hasWon = true;
        } Console.ResetColor();

        if(_hasWon)
            Environment.Exit(0);
        if(!isAITurn)
            AIChooseTile();
        Console.Write("Enter a tile number: ");
        TryParseInput();
    }

    private void AIChooseTile() {
        Random _random = new Random();
        int _randTile = _random.Next(0,9);

        while(inOut.Tiles[_randTile] == "x" || inOut.Tiles[_randTile] == "o") {
            _randTile = _random.Next(0,9);
        } inOut.Tiles[_randTile] = "o";

        Console.WriteLine("\n");
        for(int i=0;i<inOut.Tiles.Length;i++) {
            if(i==2 || i==5)
                Console.Write(inOut.Tiles[i] + "\n");
            else
                Console.Write(inOut.Tiles[i] + " ");
        }
        Console.WriteLine("");

        CheckWinner(true);
    }
}