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
            new object[]
            {
                new LangueAnglaise(), 
                MomentDeLaJournée.Indéterminé, 
                Expressions.Anglais.Salutation
            },
            new object[]
            {
                new LangueAnglaise(),
                MomentDeLaJournée.Matin,
                Expressions.Anglais.GoodMorning
            },
            new object[]
            {
                new LangueFrançaise(), 
                MomentDeLaJournée.Indéterminé, 
                Expressions.Français.Salutation
            },
        };

        [Theory]
        [MemberData(nameof(CasTestBonjour))]
        public void TestBonjour(ILangue langue, MomentDeLaJournée moment, string salutation)
        {
            // ETANT DONNE un utilisateur parlant <langue>
            // ET que nous sommes à un moment de la journée <moment>
            var ohce = new OhceBuilder()
                .AyantPourLangue(langue)
                .AyantPourMomentDeLaJournée(moment)
                .Build();

            // QUAND on envoie une chaîne à OHCE
            var résultat = ohce.Miroir("toto");

            // ALORS il salue en <langue> avant tout
            Assert.StartsWith(salutation, résultat);
        }

        public static IEnumerable<object[]> CasTestAuRevoir => new[]
        {
            new object[] { new LangueFrançaise(), Expressions.Français.Acquittance },
            new object[] { new LangueAnglaise(), Expressions.Anglais.Acquittance }
        };

        [Theory]
        [MemberData(nameof(CasTestAuRevoir))]
        public void TestAuRevoir(ILangue langue, string acquittance)
        {
            // ETANT DONNE un utilisateur parlant <langue>
            var ohce = new OhceBuilder()
                .AyantPourLangue(langue)
                .Build();

            // QUAND on envoie une chaîne à OHCE
            var résultat = ohce.Miroir("toto");

            // ALORS il salue en <langue> en dernier
            Assert.EndsWith(acquittance, résultat);
        }

        public static IEnumerable<object[]> CasTestBienDit => new[]
        {
            new object[] { new LangueFrançaise(), Expressions.Français.BienDit },
            new object[] { new LangueAnglaise(), Expressions.Anglais.BienDit }
        };

        [Theory]
        [MemberData(nameof(CasTestBienDit))]
        public void TestPalindrome(ILangue langue, string bienDit)
        {
            // ETANT DONNE un utilisateur parlant <langue>
            var ohce = new OhceBuilder()
                .AyantPourLangue(langue)
                .Build();

            // QUAND on envoie un palindrome à OHCE
            const string palindrome = "radar";
            var résultat = ohce.Miroir(palindrome);

            // ALORS il le renvoie
            Assert.Contains(palindrome, résultat);
            var finPalindrome = résultat.IndexOf(palindrome, StringComparison.Ordinal)
                                + palindrome.Length;
            var résultatAprèsPalindrome = résultat[finPalindrome..];

            // ET écrit 'Bien dit' en <langue> juste ensuite
            Assert.StartsWith(bienDit, résultatAprèsPalindrome);
        }

        [Theory]
        [MemberData(nameof(CasTestBienDit))]
        public void TestNonPalindrome(ILangue langue, string bienDit)
        {
            // ETANT DONNE un utilisateur parlant <langue>
            var ohce = new OhceBuilder()
                .AyantPourLangue(langue)
                .Build();

            // QUAND on envoie une chaîne qui n'est palindrome à OHCE
            const string chaîne = "test";
            var résultat = ohce.Miroir(chaîne);
            
            // ALORS 'Bien dit' en <langue> n'est pas renvoyé
            Assert.DoesNotContain(bienDit, résultat);
        }
    }
}