using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaIngenieria.Domain.Entities;
using TareaIngenieria.Domain.Interfaces.Repositories;

namespace TareaIngenieria.Infraestructure.Data.Repositories
{
    /**
     * <summary>Clase que contiene los métodos de la entidad permiso, se encarga de realizar las consultas a Entity Framework.</summary>
     */
    public class CarroRepository : BaseRepository<Carro>, ICarroRepository
    {
    }//Fin de la clase PermissionService
}
