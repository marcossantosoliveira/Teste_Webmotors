using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste_WebMotors.Application.InputModels;
using Teste_WebMotors.Application.Services;
using Teste_WebMotors.Application.ViewModels;
using Teste_WebMotors.Core.Entities;
using Teste_WebMotors.Core.Interfaces.Services;

namespace Teste_WebMotors.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnunciosController : Controller
    {

        private readonly IAnuncioServices _anuncioServices;
        public AnunciosController(IAnuncioServices anuncioServices)
        {
            _anuncioServices = anuncioServices;
        }

        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] AnuncioInputModel anuncioModel)
        {
            try
            {
                var anuncio = new Anuncio()
                {
                    Ano = anuncioModel.Ano,
                    Marca = anuncioModel.Marca,
                    Modelo = anuncioModel.Modelo,
                    Observacao = anuncioModel.Observacao,
                    Quilometragem = anuncioModel.Quilometragem,
                    Versao = anuncioModel.Versao
                };

                _anuncioServices.Add(anuncio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetAllMake")]
        public List<MarcaViewModel> GetAllMake()
     {
            try
            {
                var anuncioMarcas = _anuncioServices.GetAllMake();

                var listaMarcas = new List<MarcaViewModel>();

                foreach (var item in anuncioMarcas)
                {
                    var marca = new MarcaViewModel()
                    {
                        ID = item.ID,
                        Nome = item.Name,                       
                    };

                    listaMarcas.Add(marca);
                }

                return listaMarcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetModelByIdMake/{id}")]
        public List<ModeloViewModel> GetModelByIdMake(int id)
        {
            try
            {
                var modelos = _anuncioServices.GetModelByIdMake(id);
                var listaModelos = new List<ModeloViewModel>();

                foreach (var item in modelos)
                {
                    var modelo = new ModeloViewModel()
                    {
                        ID = item.ID,
                        Nome = item.Name,
                    };

                    listaModelos.Add(modelo);
                }

                return listaModelos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetVersionByIdModel/{id}")]
        public List<VersaoViewModel> GetVersionByIdModel(int id)
        {
            try
            {
                var versoes = _anuncioServices.GetVersionByIdModel(id);
                var listaVersoes = new List<VersaoViewModel>();

                foreach (var item in versoes)
                {
                    var versao = new VersaoViewModel()
                    {
                        ID = item.ID,
                        Nome = item.Name,
                    };

                    listaVersoes.Add(versao);
                }

                return listaVersoes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<AnuncioViewModel> GetAll()
        {
            try
            {
                var anuncios = _anuncioServices.GetAll();
                var listaAnuncios = new List<AnuncioViewModel>();

                foreach (var item in anuncios)
                {
                    var anuncio = new AnuncioViewModel()
                    {
                        ID = item.ID,
                        Ano = item.Ano,
                        Marca = item.Marca,
                        Modelo = item.Modelo,
                        Observacao = item.Observacao,
                        Quilometragem = item.Quilometragem,
                        Versao = item.Versao
                    };

                    listaAnuncios.Add(anuncio);
                }

                return listaAnuncios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public AnuncioViewModel GetById(int id)
        {
            try
            {
                var anuncio = _anuncioServices.GetById(id);

                var anuncioModel = new AnuncioViewModel() 
                {
                    ID = anuncio.ID,
                    Ano = anuncio.Ano,
                    Marca = anuncio.Marca,
                    Modelo = anuncio.Modelo,
                    Observacao = anuncio.Observacao,
                    Quilometragem = anuncio.Quilometragem,
                    Versao = anuncio.Versao
                };

                return anuncioModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("Update")]
        public void Update([FromBody] AnuncioInputModel anuncioModel)
        {
            try
            {
                var anuncio = new Anuncio()
                {
                    ID = anuncioModel.ID,
                    Ano = anuncioModel.Ano,
                    Marca = anuncioModel.Marca,
                    Modelo = anuncioModel.Modelo,
                    Observacao = anuncioModel.Observacao,
                    Quilometragem = anuncioModel.Quilometragem,
                    Versao = anuncioModel.Versao
                };

                _anuncioServices.update(anuncio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            try
            {
                _anuncioServices.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
