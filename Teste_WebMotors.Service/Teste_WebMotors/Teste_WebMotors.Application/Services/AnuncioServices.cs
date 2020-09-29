using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste_WebMotors.Application.InputModels;
using Teste_WebMotors.Application.ViewModels;
using Teste_WebMotors.Core.Entities;
using Teste_WebMotors.Core.Interfaces.Repository;
using Teste_WebMotors.Core.Interfaces.Services;

namespace Teste_WebMotors.Application.Services
{
    public class AnuncioServices : IAnuncioServices
    {
        private readonly IAnuncioRepository _anuncioRepository;

        private readonly IMakeCrossCutting _makeRepository;

        private readonly IModelCrossCutting _modelRepository;

        private readonly IVersionCrossCutting _versionRepository;

        public AnuncioServices(IAnuncioRepository anuncioRepository, IMakeCrossCutting makeRepository,
            IModelCrossCutting modelRepository, IVersionCrossCutting versionRepository)
        {
            _anuncioRepository = anuncioRepository;
            _makeRepository = makeRepository;
            _modelRepository = modelRepository;
            _versionRepository = versionRepository;
        }

        public void Add(Anuncio obj)
        {
            _anuncioRepository.Add(obj);
        }

        public void Delete(int id)
        {
            var anuncio = _anuncioRepository.GetById(id);
            _anuncioRepository.Delete(anuncio);
        }

        public IEnumerable<Anuncio> GetAll()
        {
            var anuncios = _anuncioRepository.GetAll();
            return anuncios;
        }

        public IEnumerable<Marca> GetAllMake()
        {
            var marcas = _makeRepository.GetAll().Result;
            return marcas;
        }

        public IEnumerable<Modelo> GetModelByIdMake(int id)
        {
            var modelos = _modelRepository.GetModelByIdMake(id).Result;
            return modelos;
        }

        public IEnumerable<Versao> GetVersionByIdModel(int id)
        {
            var versoes = _versionRepository.GetVersionByIdModel(id).Result;
            return versoes;
        }

        public Anuncio GetById(int id)
        {
            var anuncio = _anuncioRepository.GetById(id);
            return anuncio;
        }

        public void update(Anuncio obj)
        {
            _anuncioRepository.update(obj);
        }
    }
}
