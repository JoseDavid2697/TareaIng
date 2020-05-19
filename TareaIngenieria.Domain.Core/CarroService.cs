using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaIngenieria.Domain.Entities;
using TareaIngenieria.Domain.Interfaces.Repositories;
using TareaIngenieria.Domain.Interfaces.Services;
namespace TareaIngenieria.Domain.Core
{
    /**
         * <summary>Clase que contiene los métodos de la entidad permiso, se encarga de realizar la conexión entre los servicios y los repositorios.</summary>
         */
    public class CarroService : BaseService<Carro>, ICarroService
    {
        //Declaración de variables globales
        private readonly ICarroRepository carroRepository;

        /**
         * <summary>Método constructor</summary>
         * <param name="permissionRepository">Corresponde al tipo de interfaz de tipo IPermissionRepository</param>
         */
        public CarroService(ICarroRepository carroRepository) : base(carroRepository)
        {
            this.carroRepository = carroRepository;
        }//Fin del método
    }//Fin de la Interface IBaseRepository
}
