using Borealis.Database;
using Borealis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Borealis.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			TimeRegistrationViewModel model = new TimeRegistrationViewModel();
			
			RaceTimeEntities raceTimeEntities = new RaceTimeEntities();
			List<Participants> participants = raceTimeEntities.Participants
												.Where(x => x.DateTimeAccepted != null)
												.OrderBy(x => x.RaceTime)
												.ToList();

			model.Participants = participants;

			raceTimeEntities.Dispose();
			return View(model);
		}

		[HttpGet]
		public ActionResult TimeRegistration()
		{
			ViewBag.Message = "Your time application page.";

			return View();
		}

		[HttpPost]
		public ActionResult TimeRegistration(TimeRegistrationViewModel model)
		{
			if (ModelState.IsValid)
			{
				RaceTimeEntities raceTimeEntities = new RaceTimeEntities();

				Participants participants = new Participants()
				{
					ID = Guid.NewGuid(),
					Name = model.Name,
					Surname = model.Surname,
					RaceTime = model.Time,
					DateTimeRegistered = DateTime.Now
				};

				raceTimeEntities.Participants.Add(participants);
				raceTimeEntities.SaveChanges();

				ModelState.Clear();
				raceTimeEntities.Dispose();

				return View();
			}
			else
			{
				TempData["alert"] = "Sva polja su obavezna.";
				return View(model);
			}

		}
	}
}