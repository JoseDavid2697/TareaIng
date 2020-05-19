using TareaIngenieria.Domain.Entities;
using TareaIngenieria.Domain.Interfaces.Services;
using TareaIngenieria.Application.Main.Interfaces;

namespace TareaIngenieria.Application.Main.Services
{
    
    public class CarroAppService : BaseAppService<Carro>, ICarroAppService
    {
        //Declaración de variables globales
        private readonly ICarroService carroService;


        public CarroAppService(ICarroService carroService) : base(carroService)
        {
            this.carroService = carroService;
        }//Fin del método
    }
}