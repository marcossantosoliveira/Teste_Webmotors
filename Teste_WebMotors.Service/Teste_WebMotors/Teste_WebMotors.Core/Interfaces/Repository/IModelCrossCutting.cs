using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teste_WebMotors.Application.ViewModels;

namespace Teste_WebMotors.Core.Interfaces.Repository
{
    public interface IModelCrossCutting
    {
      Task<IEnumerable<Modelo>> GetModelByIdMake(int id);
    }
}
