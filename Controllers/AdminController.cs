using Borealis.Database;
using Borealis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Borealis.Controllers
{
	public class AdminController : Controller
	{
		public ActionResult RaceTimes()
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

		public ActionResult NewTimes()
		{
			TimeRegistrationViewModel model = new TimeRegistrationViewModel();

			RaceTimeEntities raceTimeEntities = new RaceTimeEntities();
			List<Participants> participants = raceTimeEntities.Participants
												.Where(x => x.DateTimeAccepted == null)
												.OrderBy(x => x.RaceTime)
												.ToList();

			model.Participants = participants;

			raceTimeEntities.Dispose();
			return View(model);
		}

		public void Accept(Guid id)
		{
			RaceTimeEntities raceTimeEntities = new RaceTimeEntities();
			Participants participants = raceTimeEntities.Participants.FirstOrDefault(x => x.ID == id);

			participants.DateTimeAccepted = DateTime.Now;

			raceTimeEntities.Entry(participants).State = System.Data.Entity.EntityState.Modified;
			raceTimeEntities.SaveChanges();

			raceTimeEntities.Dispose();
		}

		public void Refuse(Guid id)
		{
			RaceTimeEntities raceTimeEntities = new RaceTimeEntities();
			Participants participants = raceTimeEntities.Participants.FirstOrDefault(x => x.ID == id);

			raceTimeEntities.Participants.Remove(participants);
			raceTimeEntities.SaveChanges();

			raceTimeEntities.Dispose();
		}
	}
}