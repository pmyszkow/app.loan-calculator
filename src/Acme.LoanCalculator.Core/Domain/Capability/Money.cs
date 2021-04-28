using System;
using System.Collections.Generic;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class Money : IEquatable<Money>, IComparable<Money>, IComparable
    {
        public Money(decimal value, Currency currency)
        {
            if (value < 0) throw new ArgumentException("Money value must be positive.", nameof(value));
            Value = value;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public static Money FromDanishCrones(decimal amount) => new Money(amount, Currency.DanishCrone);

        public static Money Zero { get; } = new Money(0m, Currency.Default);

        public decimal Value { get; }

        public Currency Currency { get; }

        public static Money operator +(Money left, Money right)
        {
            AssertIsCurrencyTheSame(left, right);
            return new Money(left.Value + right.Value, left.Currency);
        }

        public static Money operator -(Money left, Money right)
        {
            AssertIsCurrencyTheSame(left, right);
            return new Money(left.Value - right.Value, left.Currency);
        }

        public static decimal operator /(Money left, Money right)
        {
            AssertIsCurrencyTheSame(left, right);
            return left.Value / right.Value;
        }

        public static Money operator *(Money left, Percent percent)
        {
            return new Money(left.Value * percent.DecimalFraction, left.Currency);
        }

        public static Money operator *(Money left, decimal right)
        {
            return new Money(left.Value * right, left.Currency);
        }

        public static Money operator /(Money left, decimal right)
        {
            return new Money(left.Value * right, left.Currency);
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
            return $"{Value:C} {Currency}";
        }

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value && Equals(Currency, other.Currency);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Money other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Currency);
        }

        public int CompareTo(Money other)
        {
            AssertIsCurrencyTheSame(this, other);
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is Money other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Money)}");
        }
    }
}