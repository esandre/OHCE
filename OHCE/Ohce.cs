using OHCE.Langues;

namespace OHCE
{
    public class Ohce
    {
        private readonly ILangue _langue;

        public Ohce(ILangue langue)
        {
            _langue = langue;
        }

        public string Miroir(string chaîne)
        {
            var miroir = new string(chaîne.Reverse().ToArray());
            var estUnPalindrome = miroir.Equals(chaîne);

            return _langue.Salutation
                   + miroir
                   + (estUnPalindrome ? "Bien dit" : string.Empty)
                   + "Au revoir";
        }
    }
}