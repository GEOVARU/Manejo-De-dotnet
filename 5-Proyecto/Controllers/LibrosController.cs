using System;
using Microsoft.AspNetCore.Mvc;
using _5_Proyecto.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using _5_Proyecto.Models;

namespace _5_Proyecto.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Http Get method Index
        public IActionResult Index()
        {
            IEnumerable<Libro> listLibros = _context.Libro;
            return View(listLibros);
        }


        //Http Get method Create
        public IActionResult Create()
        {
            return View();
        }
        //Http [post] method Create
        [HttpPost]//DEFINIMOS EL TIPO DE METODO
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro Libro)
        {
            if (ModelState.IsValid)
            {
                //agrega
                _context.Libro.Add(Libro);
                //guarda
                _context.SaveChanges();


                //mensaje
                TempData["mensaje"] = "El libro se a guardado con exito";
                return RedirectToAction("Index");
            }
            return View();

        }

        //Http Get method Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtenemos los datos del libro
            var libro = _context.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);

        }
        //Http [post] method Edit
        [HttpPost]//DEFINIMOS EL TIPO DE METODO
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro Libro)
        {
            if (ModelState.IsValid)
            {
                //Actualiza
                _context.Libro.Update(Libro);
                //guatda cambios
                _context.SaveChanges();


                //mensaje
                TempData["mensaje"] = "El libro se a actualizado con exito";
                return RedirectToAction("Index");
            }
            return View();

        }



        

        //Http Get method Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtenemos los datos del libro
            var libro = _context.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);

        }
        //Http [post] method DeleteLibro
        [HttpPost]//DEFINIMOS EL TIPO DE METODO
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(int? id)
        {
            //obtenemos el libro por Id
            var libro = _context.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
           
            //Eliminamos
            _context.Libro.Remove(libro);
            //guatda cambios
            _context.SaveChanges();


            //mensaje
            TempData["mensaje"] = "El libro se a actualizado con exito";
            return RedirectToAction("Index"); 
        }
        
    }
}