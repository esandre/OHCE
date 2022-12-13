namespace OHCE.Langues
{
    public class LangueAnglaise : ILangue
    {
        /// <inheritdoc />
        public string Saluer(MomentDeLaJournée moment)
            => moment == MomentDeLaJournée.Matin
                ? Expressions.Anglais.GoodMorning
                : Expressions.Anglais.Salutation;

        /// <inheritdoc />
        public string Acquittance => Expressions.Anglais.Acquittance;

        /// <inheritdoc />
        public string BienDit => Expressions.Anglais.BienDit;
    }
}
