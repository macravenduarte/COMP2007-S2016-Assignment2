﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COMP2007_S2016_Assignment2.Models;

namespace COMP2007_S2016_Assignment2.Controllers
{
    public class MenuItemsController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: MenuItems
        public async Task<ActionResult> Index()
        {
            return View(await db.MenuItems.ToListAsync());
        }

        // GET: MenuItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItems menuItems = await db.MenuItems.FindAsync(id);
            if (menuItems == null)
            {
                return HttpNotFound();
            }
            return View(menuItems);
        }
        [Authorize]
        // GET: MenuItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create([Bind(Include = "ID,ItemName,ItemPrice,ShortDesc,LongDesc,ThumbnailURL,FullsizeURL")] MenuItems menuItems)
        {
            if (ModelState.IsValid)
            {
                db.MenuItems.Add(menuItems);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(menuItems);
        }
        [Authorize]
        // GET: MenuItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItems menuItems = await db.MenuItems.FindAsync(id);
            if (menuItems == null)
            {
                return HttpNotFound();
            }
            return View(menuItems);
        }

        // POST: MenuItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ItemName,ItemPrice,ShortDesc,LongDesc,ThumbnailURL,FullsizeURL")] MenuItems menuItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuItems).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(menuItems);
        }

        // GET: MenuItems/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItems menuItems = await db.MenuItems.FindAsync(id);
            if (menuItems == null)
            {
                return HttpNotFound();
            }
            return View(menuItems);
        }

        // POST: MenuItems/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MenuItems menuItems = await db.MenuItems.FindAsync(id);
            db.MenuItems.Remove(menuItems);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
