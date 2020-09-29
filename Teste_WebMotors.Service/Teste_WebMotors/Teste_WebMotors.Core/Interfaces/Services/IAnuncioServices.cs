
using System.Collections.Generic;
using Teste_WebMotors.Application.ViewModels;
using Teste_WebMotors.Core.Entities;

namespace Teste_WebMotors.Core.Interfaces.Services
{
    public interface IAnuncioServices
    {
        void Add(Anuncio obj);
        void Delete(int id);
        IEnumerable<Anuncio> GetAll();
        Anuncio GetById(int id);
        void update(Anuncio obj);
        IEnumerable<Marca> GetAllMake();
        IEnumerable<Modelo> GetModelByIdMake(int id);
        IEnumerable<Versao> GetVersionByIdModel(int id);
    }
}
