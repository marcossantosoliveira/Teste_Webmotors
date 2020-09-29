using Teste_WebMotors.Core.Entities;
using Teste_WebMotors.Core.Interfaces.Repository;

namespace Teste_WebMotors.Infrastructure.Persistence.Repositories
{
    public class AnuncioRepository: EFRepository<Anuncio>, IAnuncioRepository
    {
        protected readonly Context _dbContext;      

        public AnuncioRepository(Context dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
