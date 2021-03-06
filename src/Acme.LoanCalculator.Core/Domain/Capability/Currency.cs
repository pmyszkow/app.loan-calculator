using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class Currency : IEquatable<Currency>
    {
        public Currency(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException("Currency symbol cannot be null or whitespace.", nameof(symbol));
            Symbol = symbol;
        }

        public static Currency DanishCrone { get; } = new Currency("kr.");

        public static Currency Default { get; } = DanishCrone;

        public string Symbol { get; }

        public static bool operator ==(Currency left, Currency right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Currency left, Currency right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{Symbol}";
        }

        public bool Equals(Currency other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Currency other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Symbol);
        }
    }
}