using OHCE.Langues;

namespace OHCE.Test.Utilities
{
    internal class OhceBuilder
    {
        public static Ohce Default => new OhceBuilder().Build();

        private ILangue _langue = new LangueFrançaise();
        private MomentDeLaJournée _momentDeLaJournée = MomentDeLaJournée.Indéterminé;

        public OhceBuilder AyantPourLangue(ILangue langue)
        {
            _langue = langue;
            return this;
        }

        public OhceBuilder AyantPourMomentDeLaJournée(MomentDeLaJournée moment)
        {
            _momentDeLaJournée = moment;
            return this;
        }

        public Ohce Build() => new (_langue, _momentDeLaJournée);
    }
}
