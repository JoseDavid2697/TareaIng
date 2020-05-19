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
        }//Constructor


        public ActionResult Index()
        {
            return View(this.app.getAll());
        }//Index


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
            return View("Index");
        }//Create


        [HttpGet]
        public ActionResult Update(int id)
        {
            Carro carro = this.app.getById(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View("Update", carro);
        }//Edit


        [HttpPost]
        public ActionResult Save(Carro carro)
        {
            if (ModelState.IsValid)
            {
                this.app.modify(carro);

                return RedirectToAction("Index");
            }//Fin del if

            return View("Update",carro);
        }//Save


        [HttpGet]
        public ActionResult Delete(int id, FormCollection collection)
        {
            this.app.delete(id);
            return RedirectToAction("Index");
        }//Delete

        public ActionResult ShowCreate()
        {
            return View("Create");
        }//MostrarCrear


        private Boolean nameUnique(string placa, int id)
        {
            var carro = this.app.getAll();

            //Se recorre todos los permisos
            foreach (var current in carro)
            {
                if (current.Placa.ToString() == placa)
                {
                    return (current.ID == id);
                }//if
            }//foreach
            return true;
        }//nameUnique
    }
}
