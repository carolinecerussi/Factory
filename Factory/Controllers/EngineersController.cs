using System;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Factory.Controllers
{
	public class EngineersController : Controller 
	{
		private readonly FactoryContext _db;

		public EngineersController(FactoryContext db)
		{
			_db = db;
		}

			public ActionResult Index()
		{
			return View(_db.Engineers.ToList());
		}

		public ActionResult Create()
		{
		return View("Create", "engineers");
		}

		[HttpPost]
		public ActionResult Create(Engineer engineer)
		{
			_db.Engineers.Add(engineer);
			_db.SaveChanges();
			return RedirectToAction("Index", "engineers");
		}

		public ActionResult Details(int id)
		{
			var thisEngineer = _db.Engineers
			.Include(engineer=> engineer.JoinEntities)
			.ThenInclude(join => join.Machine)
			.FirstOrDefault(engineer=> engineer.EId == id);
			return View(thisEngineer);
		}
		public ActionResult Edit(int id)
		{
			var thisEngineer = _db.Engineers.FirstOrDefault(engineer=> engineer.EId == id);
			return View(thisEngineer);
		}

	[HttpPost]
	public ActionResult Edit(Engineer engineer)
	{
		_db.Entry(engineer).State = EntityState.Modified;
		_db.SaveChanges();
		return RedirectToAction("Index");
		}
		public ActionResult Delete (int id)
			{
				var thisEngineer = 
				_db.Engineers.FirstOrDefault(engineer => engineer.EId == id);
				return View(thisEngineer);
			}
		[HttpPost, ActionName("Delete")]
			public ActionResult DeleteConfirmed(int id)
			{
				var thisEngineer = 
				_db.Engineers.FirstOrDefault(engineer=> engineer.EId == id);
				_db.Engineers.Remove(thisEngineer);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
		public ActionResult AddM(int id)
		{
			var thisEngineer =
			_db.Engineers.FirstOrDefault(engineer => engineer.EId == id );
			return View(thisEngineer);
		}

		[HttpPost]
		public ActionResult AddM(Engineer engineer, int MId)
		{
			if (MId !=0)
			{
				_db
					.EngineerMachine
					.Add(new EngineerMachine()
					{MId =MId, EId = engineer.EId});
				_db.SaveChanges();
			}
			return RedirectToAction("Index");
			}

	}
}