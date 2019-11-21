using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MappingTransformations.Models;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace MappingTransformations.Controllers
{
    public class HomeController : Controller
    {
     
    
    public Dictionary<int, List<int>> Goals = new Dictionary <int, List<int>>()
        {
            {1, new List<int>{160, 10, 160, 160, 250, 160, 250, 70}},
            {2, new List<int>{160, 10, 160, 160, 250, 160, 250, 70}},
            {3, new List<int>{370, 10, 370, 160, 460, 160, 460, 70}},
            {4, new List<int>{400,550, 400, 400, 310, 400, 310, 490}},
            {5, new List<int>{160, 10, 160, 160, 250, 160, 250, 70}},
            {6, new List<int>{400, 370, 490, 340, 430, 400, 430, 460}},
            {7, new List<int>{400, 370, 490, 340, 430, 400, 430, 460}},
            {8, new List<int>{430, 130, 460, 130, 550, 190, 400, 190}},
            {9, new List<int>{400, 220, 400, 220, 460, 310, 370, 310}},
            {10, new List<int>{520, 550, 520, 550, 400, 400, 400, 490}},
            {11, new List<int>{650, 10, 160, 160, 250, 160, 250, 70}}
        };

    public Dictionary<int, List<int>> Starter = new Dictionary <int, List<int>>()
        {
            {1, new List<int>{280, 190, 280, 340, 370, 340, 370, 250}},
            {2, new List<int>{460, 130, 460, 280, 370, 280, 370, 190}},
            {3, new List<int>{310, 550, 310, 400, 400, 400, 400, 490}},
            {4, new List<int>{190, 40, 190, 190, 280, 190, 280, 100}},
            {5, new List<int>{520, 220, 370, 220, 370, 310, 460, 310}},
            {6, new List<int>{220, 370, 130, 340, 190, 400, 190, 460}},
            {7, new List<int>{280, 250, 250, 160, 310, 220, 370, 220}},
            {8, new List<int>{130, 430, 130, 460, 190, 550, 190, 400}},
            {9, new List<int>{400, 220, 400, 220, 460, 130, 370, 130}},
            {10, new List<int>{130, 10, 130, 10, 250, 160, 250, 70}},
            {11, new List<int>{160, 10, 160, 160, 250, 160, 250, 70}}
        };

    
    
     
         
     
    [HttpGet("")]
    public IActionResult Start () {
        if (HttpContext.Session.GetInt32("Ax") == null )
        {
        HttpContext.Session.SetInt32("Level", 1);
        HttpContext.Session.SetInt32("Score", 0);    
        HttpContext.Session.SetInt32("Ax", Starter[1][0]);
        HttpContext.Session.SetInt32("Ay", Starter[1][1]);
        HttpContext.Session.SetInt32("Bx", Starter[1][2]);
        HttpContext.Session.SetInt32("By", Starter[1][3]);
        HttpContext.Session.SetInt32("Cx", Starter[1][4]);
        HttpContext.Session.SetInt32("Cy", Starter[1][5]);
        HttpContext.Session.SetInt32("Dx", Starter[1][6]);
        HttpContext.Session.SetInt32("Dy", Starter[1][7]);
        }
        return Redirect ("/1");
    }
    [HttpGet("{Level}")]
    
    public IActionResult Index(int Level)
    {  
        int goalAx = Goals[Level][0];
        int goalAy = Goals[Level][1];
        int goalBx = Goals[Level][2];
        int goalBy = Goals[Level][3];
        int goalCx = Goals[Level][4];
        int goalCy = Goals[Level][5];
        int goalDx = Goals[Level][6];
        int goalDy = Goals[Level][7];

        ViewBag.goalAx = goalAx;
        ViewBag.goalAy = goalAy;
        ViewBag.goalBx = goalBx;
        ViewBag.goalBy = goalBy;
        ViewBag.goalCx = goalCx;
        ViewBag.goalCy = goalCy;
        ViewBag.goalDx = goalDx;
        ViewBag.goalDy = goalDy;

        if (HttpContext.Session.GetInt32("Ax") == 0)
        {
        HttpContext.Session.SetInt32("Ax", Starter[Level][0]);
        HttpContext.Session.SetInt32("Ay", Starter[Level][1]);
        HttpContext.Session.SetInt32("Bx", Starter[Level][2]);
        HttpContext.Session.SetInt32("By", Starter[Level][3]);
        HttpContext.Session.SetInt32("Cx", Starter[Level][4]);
        HttpContext.Session.SetInt32("Cy", Starter[Level][5]);
        HttpContext.Session.SetInt32("Dx", Starter[Level][6]);
        HttpContext.Session.SetInt32("Dy", Starter[Level][7]);

        }
        ViewBag.Level = HttpContext.Session.GetInt32("Level");
        ViewBag.Score = HttpContext.Session.GetInt32("Score");
        ViewBag.Ax = HttpContext.Session.GetInt32("Ax");
        ViewBag.Ay = HttpContext.Session.GetInt32("Ay");
        ViewBag.Bx = HttpContext.Session.GetInt32("Bx");
        ViewBag.By = HttpContext.Session.GetInt32("By");
        ViewBag.Cx = HttpContext.Session.GetInt32("Cx");
        ViewBag.Cy = HttpContext.Session.GetInt32("Cy");
        ViewBag.Dx = HttpContext.Session.GetInt32("Dx");
        ViewBag.Dy = HttpContext.Session.GetInt32("Dy");

        if (ViewBag.Ax == goalAx && ViewBag.Ay == goalAy && ViewBag.Bx == goalBx && ViewBag.By == goalBy && ViewBag.Cx == goalCx && ViewBag.Cy == goalCy && ViewBag.Dx == goalDx && ViewBag.Dy == goalDy) {
            ViewBag.Level++;
            Level += 1;
            HttpContext.Session.SetInt32("Ax", 0);
            HttpContext.Session.SetInt32("Level", Level);

    }
        
        return View();
    }

    [HttpGet("rules")]
    public IActionResult Rules()
    {
        ViewBag.Level = HttpContext.Session.GetInt32("Level");
        ViewBag.Score = HttpContext.Session.GetInt32("Score");
        return View();
    }


    [HttpGet("reset")]
    public IActionResult Reset ()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Start");
        }  



    public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


