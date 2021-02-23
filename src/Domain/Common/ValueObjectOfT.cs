using System.Collections.Generic;

namespace Ideator.Domain.Common
{
    public abstract record ValueObject<T>(T Value) : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}