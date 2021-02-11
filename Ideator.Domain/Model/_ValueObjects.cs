using System;
using System.Collections.Generic;
using Ideator.Domain.Common;

namespace Ideator.Domain.Model
{
    public sealed record ArticleId(Guid Value)
        : ValueObject<Guid>(Value);

    public sealed record AuthorId(Guid Value)
        : ValueObject<Guid>(Value);

    public sealed record Content(string Value)
        : ValueObject<string>(Value);

    public sealed record PersonName(string Value)
        : ValueObject<string>(Value);

    public sealed record Title(string Value)
        : ValueObject<string>(Value);

    public sealed record Address(string Street, string City, string ZipCode, List<PersonName> Tenants)
        : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return ZipCode;

            foreach (var tenant in Tenants) yield return tenant;
        }
    }

    public sealed record Money(string Currency, decimal Amount)
        : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Currency.ToUpper();
            yield return Math.Round(Amount, 2);
        }
    }
}