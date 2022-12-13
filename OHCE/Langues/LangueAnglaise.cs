namespace OHCE.Langues
{
    public class LangueAnglaise : ILangue
    {
        /// <inheritdoc />
        public string Salutation => Expressions.Anglais.Salutation;

        /// <inheritdoc />
        public string Acquittance => Expressions.Anglais.Acquittance;

        /// <inheritdoc />
        public string BienDit => Expressions.Anglais.BienDit;
    }
}
