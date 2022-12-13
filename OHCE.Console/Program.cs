using OHCE;
using OHCE.Langues;

Console.WriteLine(
    new Ohce(new LangueFrançaise(), MomentDeLaJournée.Indéterminé).Miroir(
        Console.ReadLine() ?? string.Empty
        )
    );