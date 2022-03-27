using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCoreReview.Datos;
using CrudCoreReview.Models;

namespace CrudCoreReview.Controllers
{
    public class MantenedorController : Controller
    {

        ContactoDatos _ContactoDatos = new ContactoDatos();

        public IActionResult List()
        {
            //retorna lista de contactos
            var oList = _ContactoDatos.List();
            return View(oList);
        }

        public IActionResult Save()
        {
            //metodo solo devuelve la lista
            return View();
        }
        [HttpPost]
        public IActionResult Save(ContactoModel oContacto)
        {
            //metodo recibe el objeto para guardarlo en bd

            if (!ModelState.IsValid)
            {
                return View();
            }


            var response = _ContactoDatos.save(oContacto);

            if (response)
                return RedirectToAction("List");
            else                
                return View();
        }

        public IActionResult Update(int idContacto)
        {
            //metodo solo devuelve la lista
            var oContacto = _ContactoDatos.Get(idContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Update(ContactoModel oContacto)
        {
            //metodo recibe el objeto para guardarlo en bd

            if (!ModelState.IsValid)
            {
                return View();
            }


            var response = _ContactoDatos.update(oContacto);

            if (response)
                return RedirectToAction("List");
            else
                return View();
        }


        public IActionResult Delete(int idContacto)
        {
            //metodo solo devuelve la lista
            var oContacto = _ContactoDatos.Get(idContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Delete(ContactoModel oContacto)
        {
            //metodo recibe el objeto para guardarlo en bd

            var response = _ContactoDatos.delete(oContacto.idContacto);

            if (response)
                return RedirectToAction("List");
            else
                return View();
        }
    }
}
