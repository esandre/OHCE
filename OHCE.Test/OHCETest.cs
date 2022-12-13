using OHCE.Langues;
using OHCE.Test.Utilities;

namespace OHCE.Test
{
    public class OHCETest
    {
        [Theory]
        [InlineData("toto")]
        [InlineData("test")]
        public void TestMiroir(string chaîne)
        {
            // QUAND on envoie une chaîne à OHCE
            var résultat = OhceBuilder.Default.Miroir(chaîne);

            // ALORS elle est renvoyée en miroir
            var miroir = new string(chaîne.Reverse().ToArray());
            Assert.Contains(miroir, résultat);
        }

        public static IEnumerable<object[]> CasTestBonjour => new []
        {
            new object[] { new LangueAnglaise(), Expressions.Anglais.Salutation },
            new object[] { new LangueFrançaise(), Expressions.Français.Salutation },
        };

        [Theory]
        [MemberData(nameof(CasTestBonjour))]
        public void TestBonjour(ILangue langue, string salutation)
        {
            // ETANT un utilisateur parlant <langue>
            var ohce = new OhceBuilder()
                .AyantPourLangue(langue)
                .Build();

            // QUAND on envoie une chaîne à OHCE
            var résultat = ohce.Miroir("toto");

            // ALORS il salue en <langue> avant tout
            Assert.StartsWith(salutation, résultat);
        }

        [Fact]
        public void TestAuRevoir()
        {
            // QUAND on envoie une chaîne à OHCE
            var résultat = OhceBuilder.Default.Miroir("toto");

            // ALORS il répond 'Au revoir' en dernier
            Assert.EndsWith("Au revoir", résultat);
        }

        [Fact]
        public void TestPalindrome()
        {
            // QUAND on envoie un palindrome à OHCE
            const string palindrome = "radar";
            var résultat = OhceBuilder.Default.Miroir(palindrome);

            // ALORS il le renvoie
            Assert.Contains(palindrome, résultat);
            var finPalindrome = résultat.IndexOf(palindrome, StringComparison.Ordinal)
                                + palindrome.Length;
            var résultatAprèsPalindrome = résultat[finPalindrome..];

            // ET écrit 'Bien dit' juste ensuite
            Assert.StartsWith("Bien dit", résultatAprèsPalindrome);
        }

        [Fact]
        public void TestNonPalindrome()
        {
            // QUAND on envoie une chaîne qui n'est palindrome à OHCE
            const string chaîne = "test";
            var résultat = OhceBuilder.Default.Miroir(chaîne);
            
            // ALORS 'Bien dit' n'est pas renvoyé
            Assert.DoesNotContain("Bien dit", résultat);
        }
    }
}