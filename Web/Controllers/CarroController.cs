using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaIngenieria.Application.Main.Interfaces;
using TareaIngenieria.Domain.Entities;

namespace Web.Controllers
{
    public class CarroController : Controller
    {
        private readonly ICarroAppService app;
        public CarroController(ICarroAppService app)
        {
            this.app = app;
        }

        // GET: Carro
        public ActionResult Index()
        {
            return View(this.app.getAll());
        }

        // GET: Carro/Details/5
        public ActionResult Details(int id)
        {
            Carro carro = this.app.getById(id); //Le obtenemos la información de un permiso
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
           
        }

        // GET: Carro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Carro carro)
        {
            if (ModelState.IsValid)
            {
                //Se valida que el nombre no exista en la base de datos
                if (this.nameUnique(carro.Placa.ToString(), 0))
                {
                    this.app.add(carro);

                    return RedirectToAction("Index");
                }
            }//Fin del if
            return View(carro);
        }

        // GET: Carro/Edit/5
        public ActionResult Edit(int id)
        {
            Carro carro = this.app.getById(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carro/Edit/5
        [HttpPost]
        public ActionResult Edit(Carro carro)
        {
            if (ModelState.IsValid)
            {
                //Se valida que el nombre sea único en la base de datos
                if (this.nameUnique(carro.Placa.ToString(), carro.ID))
                {
                    this.app.modify(carro);
                    return RedirectToAction("Index");
                }
            }//Fin del if

            return View(carro);
        }

        // GET: Carro/Delete/5
        public ActionResult Delete(int id)
        {
            Carro carro = this.app.getById(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            this.app.delete(id);
            return RedirectToAction("Index");
        }


        private Boolean nameUnique(string placa, int id)
        {
            var carro = this.app.getAll();

            //Se recorre todos los permisos
            foreach (var current in carro)
            {
                if (current.Placa.ToString() == placa)
                {
                    //Si son iguales lo que está es actualizando, en caso contrario es un nuevo registro
                    return (current.ID == id);
                }//Fin del if
            }//Fin del foreach
            return true;
        }//fin del método nameUnique
    }
}
