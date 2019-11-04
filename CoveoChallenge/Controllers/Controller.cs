using Microsoft.AspNetCore.Mvc;
using CoveoChallenge.Models;
using CoveoChallenge.Services;
using System.Collections.Generic;
using System;

namespace CoveoChallenge.Controllers
{
    [Route("")]
    [ApiController]
    public class Controller : ControllerBase
    {
        [HttpGet]
        public string Hello()
        {
            return "hello";
        }

        [HttpPost]
        public ActionResult<Output> PostRequest([FromBody] List<List<List<char>>> problems)
        {
            List<string> answers = new List<string>();
            foreach (List<List<char>> p in problems)
            {
               answers.Add(PuzzleSolver.Solve(p));
            }

            Participant[] participants = new Participant[4];

            participants[0] = new Participant()
            {
                Email = "elias.alhomsi@hotmail.com",
                FullName = "Elias Al Homsi",
                GoogleAccount = "eliasalhomsi@gmail.com",
                GraduationDate = EpochTimeConverter(new DateTime(2020, 12, 15)),
                IsCaptain = true,
                Phone = "438-969-3563",
                School = "McGill University",
                SchoolProgram = "Software Engineering BEng",
                ShirtSize = "f-S"
            };

            participants[1] = new Participant()
            {
                Email = "zhou.mia2@gmail.com",
                FullName = "Yuxin Zhou",
                GoogleAccount = "zhou.mia2@gmail.com",
                GraduationDate = EpochTimeConverter(new DateTime(2021, 5, 15)),
                IsCaptain = false,
                Phone = "514-632-5653",
                School = "McGill University",
                SchoolProgram = "Software Engineering BEng",
                ShirtSize = "f-S"
            };

            participants[2] = new Participant()
            {
                Email = "Carlelkhoury@hotmail.com",
                FullName = "Carl Elkhoury",
                GoogleAccount = "Carlelkhoury5@gmail.com",
                GraduationDate = EpochTimeConverter(new DateTime(2020, 12, 15)),
                IsCaptain = false,
                Phone = "5142249729",
                School = "McGill University",
                SchoolProgram = "Software Engineering BEng",
                ShirtSize = "m-M"
            };

            participants[3] = new Participant()
            {
                Email = "irmakpakis@yahoo.com.tr",
                FullName = "Irmak Pakis",
                GoogleAccount = "irmakpakis@gmail.com",
                GraduationDate = EpochTimeConverter(new DateTime(2020, 12, 15)),
                IsCaptain = false,
                Phone = "4389276876",
                School = "McGill University",
                SchoolProgram = "Software Engineering BEng",
                ShirtSize = "f-M"
            };

            return new Output()
            {
                TeamName = "Cartman",
                TeamStreetAddress = "H3A1A8",
                Solutions = answers.ToArray(),
                Participants = participants
            };

            long EpochTimeConverter(DateTime dateTime)
            {
                var baseDate = new DateTime(1970, 01, 01);
                return (long)dateTime.Subtract(baseDate).TotalMilliseconds;
            }
        }
    }
}
