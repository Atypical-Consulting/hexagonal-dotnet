// inspired by
// - https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
// - https://www.romanx.co.uk/posts/playing-with-my-record-collection

using System.Collections.Generic;
using System.Linq;

namespace Ideator.Domain.Common
{
    public abstract record ValueObject
    {
        public virtual bool Equals(ValueObject other)
        {
            return other is not null
                   && GetEqualityComponents()
                       .SequenceEqual(other.GetEqualityComponents());
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    unchecked
                    {
                        return current * 23 + (obj?.GetHashCode() ?? 0);
                    }
                });
        }
    }
}