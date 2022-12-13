namespace OHCE.Langues
{
    public interface ILangue
    {
        string Saluer(MomentDeLaJournée moment);
        string Acquittance { get; }
        string BienDit { get; }
    }
}
