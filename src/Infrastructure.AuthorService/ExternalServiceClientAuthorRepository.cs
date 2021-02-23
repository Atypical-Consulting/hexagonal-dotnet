using Ideator.Domain.Model;
using Ideator.Domain.Ports;

namespace Ideator.AuthorService
{
    public class ExternalServiceClientAuthorRepository : IAuthorRepository
    {
        public Author Get(AuthorId authorId)
        {
            // TODO: external author service integration implementation comes here

            var authorExternalModel = new AuthorExternalModel(
                928467, "William", "Shakespeare");

            return authorExternalModel.ToDomain();
        }
    }
}