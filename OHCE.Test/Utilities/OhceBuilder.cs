using OHCE.Langues;

namespace OHCE.Test.Utilities
{
    internal class OhceBuilder
    {
        public static Ohce Default => new OhceBuilder().Build();

        private ILangue _langue = new LangueFrançaise();

        public OhceBuilder AyantPourLangue(ILangue langue)
        {
            _langue = langue;
            return this;
        }

        public Ohce Build() => new (_langue);
    }
}
