﻿using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using SportMatch.Models;
using static SportMatch.Controllers.DoorController;

namespace SportMatch.Controllers
{

    public class MatchController : Controller
    {
        // 導入資料庫
        private readonly SportMatchContext _context;

        public MatchController(SportMatchContext context)
        {
            _context = context;
        }

        List<TestForMatch> Player2 = new List<TestForMatch>
                {
                    new TestForMatch { Name = "妙蛙種子", Role = "控球後衛", Image = "../image/MatchPage/001.png" },
                    new TestForMatch { Name = "妙蛙草", Role = "大前鋒", Image = "../image/MatchPage/002.png" },
                    new TestForMatch { Name = "妙蛙花", Role = "中鋒", Image = "../image/MatchPage/003.png" },
                    new TestForMatch { Name = "小火龍", Role = "小前鋒", Image = "../image/MatchPage/004.png" },
                    new TestForMatch { Name = "火恐龍", Role = "得分後衛", Image = "../image/MatchPage/005.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "火恐龍", Role = "得分後衛", Image = "../image/MatchPage/005.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "火恐龍", Role = "得分後衛", Image = "../image/MatchPage/005.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "妙蛙花", Role = "中鋒", Image = "../image/MatchPage/003.png" },
                    new TestForMatch { Name = "小火龍", Role = "小前鋒", Image = "../image/MatchPage/004.png" },
                    new TestForMatch { Name = "火恐龍", Role = "得分後衛", Image = "../image/MatchPage/005.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "火恐龍", Role = "得分後衛", Image = "../image/MatchPage/005.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "妙蛙種子", Role = "控球後衛", Image = "../image/MatchPage/001.png" },
                    new TestForMatch { Name = "妙蛙草", Role = "大前鋒", Image = "../image/MatchPage/002.png" },
                    new TestForMatch { Name = "妙蛙花", Role = "中鋒", Image = "../image/MatchPage/003.png" },
                    new TestForMatch { Name = "小火龍", Role = "小前鋒", Image = "../image/MatchPage/004.png" },
                    new TestForMatch { Name = "火恐龍", Role = "得分後衛", Image = "../image/MatchPage/005.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "火恐龍", Role = "得分後衛", Image = "../image/MatchPage/005.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "火恐龍", Role = "得分後衛", Image = "../image/MatchPage/005.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "妙蛙花", Role = "中鋒", Image = "../image/MatchPage/003.png" },
                    new TestForMatch { Name = "小火龍", Role = "小前鋒", Image = "../image/MatchPage/004.png" },
                    new TestForMatch { Name = "火恐龍", Role = "得分後衛", Image = "../image/MatchPage/005.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "火恐龍", Role = "得分後衛", Image = "../image/MatchPage/005.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "妙蛙種子", Role = "控球後衛", Image = "../image/MatchPage/001.png" },
                    new TestForMatch { Name = "妙蛙草", Role = "大前鋒", Image = "../image/MatchPage/002.png" },
                    new TestForMatch { Name = "妙蛙花", Role = "中鋒", Image = "../image/MatchPage/003.png" },
                    new TestForMatch { Name = "小火龍", Role = "小前鋒", Image = "../image/MatchPage/004.png" },
                    new TestForMatch { Name = "火恐龍", Role = "得分後衛", Image = "../image/MatchPage/005.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "火恐龍", Role = "得分後衛", Image = "../image/MatchPage/005.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                    new TestForMatch { Name = "噴火龍", Role = "中鋒", Image = "../image/MatchPage/006.png" },
                };

        public IActionResult MatchPage()
        {

            return View();
        }

        [HttpGet]
        public JsonResult GetCards(int page, int pageSize)
        {
            int totalItems = Player2.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var cards = Player2.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return Json(new { cards, totalPages, totalItems });
        }

        [HttpGet]
        public JsonResult GetEvent()
        {
            var Event = from e in _context.Events
                        join g in _context.Genders
                        on e.GenderId equals g.GenderId
                        join s in _context.Sports
                        on e.SportId equals s.SportId
                        join a in _context.Areas
                        on e.AreaId equals a.AreaId
                        select new { Name = e.EventName, Gender = g.GenderType, Sport = s.SportName, Area = a.AreaName };

            List<string> BasketballEventList = new List<string>();
            List<string> ValleyballEventList = new List<string>();
            List<string> BadmintonEventList = new List<string>();
            foreach (var item in Event)
            {
                if (item.Sport == "BasketBall")
                {
                    BasketballEventList.Add(item.Name);
                }

                if (item.Sport == "ValleyBall")
                {
                    ValleyballEventList.Add(item.Name);
                }

                if (item.Sport == "Badminton")
                {
                    BadmintonEventList.Add(item.Name);
                }
            }

            return Json(new { BasketballEventList, ValleyballEventList, BadmintonEventList,Event });
        }

        [HttpPost]
        public IActionResult GetSelection(string MatchType, string MatchCategory, List<string> MatchEvent, List<string> MatchArea, List<string> MatchRole, string MatchGender)
        {
            if (MatchType == null)
            {
                ViewBag.MatchType = null;
                return View("MatchPage");
            }
            else
            {
                ViewBag.MatchType = MatchType;
                ViewBag.MatchCategory = MatchCategory;
                ViewBag.MatchEvent = MatchEvent;
                ViewBag.MatchArea = MatchArea;
                ViewBag.MatchRole = MatchRole;
                ViewBag.MatchGender = MatchGender;
                return View("MatchPage");
            }
        }

        // 篩選列功能
        [HttpGet]
        public JsonResult GetRole(string selectedSport)
        {
            // 從資料庫調出運動與對應的位置
            var Role = (from r in _context.Roles
                        join s in _context.Sports
                        on r.SportId equals s.SportId into sportGroup
                        from s in sportGroup.DefaultIfEmpty() // LEFT JOIN
                        select new
                        {
                            RoleName = r.RoleName,
                            SportName = s != null ? s.SportName : "N/A"
                        }).ToList();

            // 篩選列球類點擊時，資料傳入controller判斷種類回傳對應位置
            if (selectedSport != null)
            {
                List<string> RoleList = new List<string>();
                foreach (var item in Role)
                {
                    if (item.SportName.ToLower() == selectedSport.ToLower())
                    {
                        RoleList.Add(item.RoleName);
                    }
                }
                return Json(new { RoleList });
            }
            else
            {
                return Json(new { message = "未找到對應的運動" });
            }
        }
    }
}
