﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using NLog;
using SnilAcademicDepartment.Base;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;

namespace SnilAcademicDepartment.Controllers
{
	[RoutePrefix("{language}")]
	public class ParticipantsSPMAController : SnilBaseController
	{
		private readonly ISpmaParticipants _participantsService;

		/// <summary>
		/// Initializes a new instance of the <see cref="ParticipantsSPMAController"/> class.
		/// </summary>
		/// <param name="logger">The logger.</param>
		/// <param name="participantsService">The participants service.</param>
		public ParticipantsSPMAController(ILogger logger, ISpmaParticipants participantsService) : base(logger)
		{
			this._participantsService = participantsService;
		}

		[HttpGet]
		[Route("participants")]
		public async Task<ActionResult> ParticipantsPage()
		{
			IEnumerable<SpmaStudent> students = await this._participantsService.GetStuffStudents(Thread.CurrentThread.CurrentCulture.LCID);
			IEnumerable<SpmaPerson> heads = await this._participantsService.GetStuffPersonal(Thread.CurrentThread.CurrentCulture.LCID);

			ViewData.Add("students", students);
			ViewData.Add("heads", heads);
			return this.View("ParticipantsSPMA");
		}

		[HttpGet]
		[Route("spma/student")]
		public async Task<ActionResult> SpmaStudentPersonalPage(int id)
		{
			if (id <= 0)
			{
				this._logger.Warn($"SpmaStudent's Id requsted in ParticipantsSPMAController is less than zero. Id value: {id}");
				return this.Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
			}

			SpmaStudent personalInfo = null;

			personalInfo = await this._participantsService.GetStuffStudentById(id, Thread.CurrentThread.CurrentCulture.LCID);

			ViewData.Model = personalInfo;
			ViewBag.Title = string.Format("{0}, {1}", personalInfo.SecoundName, personalInfo.FirstName);
			return this.View("SpmaPersonalPage");
		}

		[HttpGet]
		[Route("spma/stuff")]
		public async Task<ActionResult> SpmaStuffPersonalPage(int id)
		{
			if (id <= 0)
			{
				this._logger.Warn($"SpmaStuff's Id requsted in ParticipantsSPMAController is less than zero. Id value: {id}");
				return this.Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
			}

			SpmaPerson personalInfo = null;

			personalInfo = await this._participantsService.GetStuffPersonById(id, Thread.CurrentThread.CurrentCulture.LCID);

			ViewData.Model = personalInfo;
			ViewBag.Title = string.Format("{0}, {1}", personalInfo.SecoundName, personalInfo.PersonName);
			return this.View("SpmaPersonalPage");
		}
	}
}