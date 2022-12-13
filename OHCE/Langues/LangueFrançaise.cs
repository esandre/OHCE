﻿namespace OHCE.Langues
{
    public class LangueFrançaise : ILangue
    {
        /// <inheritdoc />
        public string Salutation => Expressions.Français.Salutation;

        /// <inheritdoc />
        public string Acquittance => Expressions.Français.Acquittance;

        /// <inheritdoc />
        public string BienDit => Expressions.Français.BienDit;
    }
}
