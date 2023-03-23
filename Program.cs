// Angabe: https://github.com/Teaching-HTL-Leonding/resistor-bands-cli-David-Pogner

Console.OutputEncoding = System.Text.Encoding.Default;
if (args.Length >= 1)
{
    string UserInput = args[0];
    UserInput = UserInput.Replace("-", "");

    string FirstValue = UserInput.Substring(0, 3);
    string SecondValue = UserInput.Substring(3, 3);
    string ThirdValue = UserInput.Substring(6, 3);
    string FouthValue = UserInput.Substring(9, 3);

    int FirstColor = ConvertFirstColorToDigit(FirstValue);
    int SecondColor = ConvertSecondColorToDigit(SecondValue);
    int ThirdColorMultiplier = GetMultiplierFromColor(ThirdValue);
    double Tolerance = GetToleranceFromColor(FouthValue);


    double Result = 0;
    Decode4ColorBands(FirstColor, SecondColor, ThirdColorMultiplier, FouthValue, out Result);

    Console.WriteLine($"The resistance is {Result} Ohms");
    Console.WriteLine($"The tolerance is ±{Tolerance}%");
}

double Decode4ColorBands(int FirstColor, int SecondColor, int Multiplier, string FouthValue, out double Result)
{
    Result = (FirstColor * 10 + SecondColor) * Multiplier;

    double Tolerance = GetToleranceFromColor(FouthValue);
    return Tolerance;
}

#region ConvertColorToDigit
int ConvertFirstColorToDigit(string FirstValue)
{
    switch (FirstValue)
    {
        case "Bla": return 0;
        case "Bro": return 1;
        case "Red": return 2;
        case "Ora": return 3;
        case "Yel": return 4;
        case "Gre": return 5;
        case "Blu": return 6;
        case "Vio": return 7;
        case "Gra": return 8;
        case "Whi": return 9;
        default: return 0;
    }
}

int ConvertSecondColorToDigit(string SecondValue)
{
    switch (SecondValue)
    {
        case "Bla": return 0;
        case "Bro": return 1;
        case "Red": return 2;
        case "Ora": return 3;
        case "Yel": return 4;
        case "Gre": return 5;
        case "Blu": return 6;
        case "Vio": return 7;
        case "Gra": return 8;
        case "Whi": return 9;
        default: return 0;
    }
}

int GetMultiplierFromColor(string ThirdValue)
{
    switch (ThirdValue)
    {
        case "Bla": return 1;
        case "Bro": return 10;
        case "Red": return 1000;
        case "Ora": return 1_000;
        case "Yel": return 10_000;
        case "Gre": return 100_000;
        case "Blu": return 1_000_000;
        case "Vio": return 10_000_0000;
        case "Gra": return 100_000_000;
        case "Whi": return 1_000_000_000;
        default: return 0;
    }
}

double GetToleranceFromColor(string FouthValue)
{
    switch (FouthValue)
    {
        case "Bro": return 1;
        case "Red": return 2;
        case "Gre": return 0.5;
        case "Blu": return 0.25;
        case "Vio": return 0.1;
        case "Gra": return 0.05;
        case "Gol": return 5;
        case "Sil": return 10;
        default: return 0;
    }
}
#endregion