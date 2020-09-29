using System;
using System.Collections.Generic;
using System.Text;

namespace Teste_WebMotors.Application.ViewModels
{
    public class AnuncioViewModel
    {
        public int ID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }
    }
}
