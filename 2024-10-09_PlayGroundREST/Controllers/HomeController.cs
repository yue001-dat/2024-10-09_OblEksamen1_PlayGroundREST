﻿using Microsoft.AspNetCore.Mvc;

namespace _2024_10_09_PlayGroundREST.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public string Index()
		{
			return "Hello World";
		}
	}
}