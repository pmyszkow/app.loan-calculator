using System;
using System.Collections.Generic;

namespace Acme.LoanCalculator.Core.Domain.Generic
{
    public sealed class Money : IEquatable<Money>, IComparable<Money>, IComparable
    {
        public Money(decimal amount, Currency currency)
        {
            if (amount < 0) throw new ArgumentException("Money amount must be positive value.", nameof(amount));
            Amount = amount;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public static Money FromDanishCrones(decimal amount) => new Money(amount, Currency.DanishCrone);

        public static Money Zero { get; } = new Money(0m, Generic.Currency.Default);

        public decimal Amount { get; }

        public Currency Currency { get; }

        public static Money operator +(Money left, Money right)
        {
            AssertIsCurrencyTheSame(left, right);
            return new Money(left.Amount + right.Amount, left.Currency);
        }

        public static Money operator -(Money left, Money right)
        {
            AssertIsCurrencyTheSame(left, right);
            return new Money(left.Amount - right.Amount, left.Currency);
        }

        public static decimal operator /(Money left, Money right)
        {
            AssertIsCurrencyTheSame(left, right);
            return left.Amount / right.Amount;
        }

        public static Money operator *(Money left, Percent percent)
        {
            return new Money(left.Amount * percent.Rate, left.Currency);
        }

        public static Money operator *(Money left, decimal right)
        {
            return new Money(left.Amount * right, left.Currency);
        }

        public static Money operator /(Money left, decimal right)
        {
            return new Money(left.Amount * right, left.Currency);
        }

        public static bool operator ==(Money left, Money right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Money left, Money right)
        {
            return !Equals(left, right);
        }

        public static bool operator <(Money left, Money right)
        {
            return Comparer<Money>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(Money left, Money right)
        {
            return Comparer<Money>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(Money left, Money right)
        {
            return Comparer<Money>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(Money left, Money right)
        {
            return Comparer<Money>.Default.Compare(left, right) >= 0;
        }

        public static void AssertIsCurrencyTheSame(Money left, Money right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));
            if (left.Currency != right.Currency) throw new InvalidOperationException("Money operands must be of the same type.");
        }

        public override string ToString()
        {
            return $"{Amount:C} {Currency}";
        }

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount && Equals(Currency, other.Currency);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Money other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }

        public int CompareTo(Money other)
        {
            AssertIsCurrencyTheSame(this, other);
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Amount.CompareTo(other.Amount);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is Money other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Money)}");
        }
    }
}