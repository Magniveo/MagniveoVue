using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagniveoVue.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalkingTec.Mvvm.Core;

namespace MagniveoVue.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly DataContext _context;

        public ItemController()
        {//@"Server=(localdb)\\mssqllocaldb;Database=MagniveoVue_db;Trusted_Connection=True;",
            _context = new DataContext(@"Server=(localdb)\\mssqllocaldb;Database=MagniveoVue_db;Trusted_Connection=True;", DBTypeEnum.SqlServer);
            //new DataContext("Default", DBTypeEnum.SqlServer);
            try 
            {
                var test = _context.ModelItems.ToList();
            }
            catch (Exception ex) 
            { 
            
            }
        }
        // GET: Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.ModelItem.Item>>> GetHouseModels()
        {
            return await _context.ModelItems.ToListAsync();
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Item/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Item/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}