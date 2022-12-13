using OHCE;
using OHCE.Langues;

Console.WriteLine(
    new Ohce(new LangueFrançaise()).Miroir(
        Console.ReadLine() ?? string.Empty
        )
    );