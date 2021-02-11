using System;
using Ideator.Domain.Model;

namespace Ideator.AuthorService
{
    public class AuthorExternalModel
    {
        private readonly string _firstName;
        private readonly long _id;
        private readonly string _lastName;

        public AuthorExternalModel(long id, string firstName, string lastName)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
        }

        private string FullName => $"{_firstName} {_lastName}";

        public Author ToDomain()
        {
            return new(
                new AuthorId(ConvertExternalIdToGuid(_id)),
                new PersonName(FullName));
        }

        public override string ToString()
        {
            return $"{nameof(FullName)}: {FullName}";
        }

        private static Guid ConvertExternalIdToGuid(long value)
        {
            var bytes = new byte[16];
            
            BitConverter
                .GetBytes(value)
                .CopyTo(bytes, 0);
            
            return new Guid(bytes);
        }
    }
}