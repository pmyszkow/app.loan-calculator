﻿using System;

namespace Acme.LoanCalculator.Core.Domain.Generic
{
    public sealed class AnnualInterestRate : IEquatable<AnnualInterestRate>
    {
        public AnnualInterestRate(Percent percents)
        {
            Percents = percents;
        }

        public static AnnualInterestRate Zero { get; } = new AnnualInterestRate(Percent.Zero);

        public Percent Percents { get; }

        public Percent GetMonthPercents() => Percents / 12m;

        public static bool operator ==(AnnualInterestRate left, AnnualInterestRate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AnnualInterestRate left, AnnualInterestRate right)
        {
            return !Equals(left, right);
        }

        public bool Equals(AnnualInterestRate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Percents, other.Percents);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is AnnualInterestRate other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (Percents != null ? Percents.GetHashCode() : 0);
        }
    }
}