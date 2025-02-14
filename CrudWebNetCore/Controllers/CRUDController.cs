﻿using Microsoft.AspNetCore.Mvc;
using CrudWebNetCore.Datos;
using CrudWebNetCore.Models;

namespace CrudWebNetCore.Controllers
{
    public class CRUDController : Controller
    {
        ClienteDatos clienteDatos = new ClienteDatos();

        public IActionResult Index()
        {
            return View();
        }

        //Mostrar lista de clientes
        public IActionResult Listar()
        {
            var oLista = clienteDatos.Listar();
            return View(oLista);
        }

        //Mostrar una ventana para añadir los datos del nuevo registro
        public IActionResult Guardar()
        {
            return View();
        }

        //Guardar el registro con los datos que indicamos
        [HttpPost]
        public IActionResult Guardar(ModelCliente oContacto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = clienteDatos.Guardar(oContacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int id)
        {
            var oCliente = clienteDatos.Obtener(id);

            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Editar(ModelCliente oCliente)
        {
            var respuesta = clienteDatos.Editar(oCliente);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int id)
        {
            var oCliente = clienteDatos.Obtener(id);

            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Eliminar(ModelCliente oCliente)
        {
            var respuesta = clienteDatos.Eliminar(oCliente.IdContacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
