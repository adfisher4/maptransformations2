using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MappingTransformations.Controllers
{
    public class ActionController : Controller
    {
        public int WhichQuad (int x, int y)
        {
            if (x > 310 && y < 310) {
                return 1;
            }
            else if (x < 310 && y < 310) {
                return 2;
            }
            else if (x < 310 && y > 310) {
                return 3;
            }
            else if (x > 310 && y > 310) {
                return 4; 
            }  
            else if (x == 310 && y > 310) {
                return 34;
            }
            else if (x == 310 && y < 310) {
                return 12;
            }
            else if (x < 310 && y == 310) {
                return 23;
            }
            else if (x > 310 && y == 310){
                return 14;
            }
            else{
            return 0;
            } 
        }

        public int[] RotateCoordinates (int x, int y, int DegDirect)
        {
            int[] pair = new int[2];
            if (DegDirect == 1 && WhichQuad(x, y) == 1 || DegDirect == 1 && WhichQuad(x,y) == 4 || DegDirect == 1 && WhichQuad(x, y) == 2) {
                pair[0] = 620 - y;
                pair[1] = x;
            }
            if (DegDirect == 1 && WhichQuad(x, y) == 23 || DegDirect == 1 && WhichQuad(x,y) == 14 || DegDirect == 2 && WhichQuad(x, y) == 34 || DegDirect == 2 && WhichQuad(x, y) == 12) {
                pair[0] = y;
                pair[1] = x;
            }
            if (DegDirect == 2 && WhichQuad(x, y) == 23) {
                pair[0] = (310-y) + 310;
                pair[1] = x;
            }
            if (DegDirect == 2 && WhichQuad(x, y) == 23 || DegDirect == 2 && WhichQuad(x, y) == 14) {
                pair[0] = 310;
                pair[1] = 620 - x;
            }
            if (DegDirect == 1 && WhichQuad(x, y) == 34) {
                pair[0] = 310 - (y-310);
                pair[1] = 310;
            }
            if (DegDirect == 1 && WhichQuad(x, y) == 12) {
                pair[0] = 620-y;
                pair[1] = 310;
            }
            if (WhichQuad(x,y) == 0) {
                pair[0] = 310;
                pair[1] = 310;
            }
            if (DegDirect == 1 && WhichQuad(x,y) == 3) {
                pair[0] = 310 - (y - 310);
                pair[1] = x;
            }
            if (DegDirect == 2 && WhichQuad(x, y) == 1 || DegDirect == 2 && WhichQuad(x,y) == 4) {
                pair[0] = y;
                pair[1] = 310 - (x - 310);
               
            }
            if (DegDirect == 2 && (WhichQuad(x,y) == 3 || WhichQuad(x,y) == 34) || DegDirect == 2 && WhichQuad(x, y) == 2) {
                pair[0] = y;
                pair[1] = 620 - x;   
            }
            if (DegDirect == 3 && WhichQuad(x, y) == 1) {
                pair[0] =  310 - (x - 310);
                pair[1] =  620 - y; 
            }
            if (DegDirect == 3 && WhichQuad(x, y) == 3 || DegDirect == 3 && WhichQuad(x, y) == 2) {
                pair[0] =  620 - x;
                pair[1] =  620 - y; 
            }
            if (DegDirect == 3 && WhichQuad(x, y) == 4) {
                pair[0] =  620 - x;
                pair[1] =  310 - (y - 310); 
            }
            if (DegDirect == 3 && WhichQuad(x, y) == 12 || DegDirect == 3 && WhichQuad(x, y) == 34) {
                pair[0] =  310;
                pair[1] =  620 - y; 
            }
            if (DegDirect == 3 && WhichQuad(x, y) == 23 || DegDirect == 3 && WhichQuad(x, y) == 14) {
                pair[0] =  620 - x;
                pair[1] =  310; 
            }
        return pair;
        }
        public IActionResult TranslationPartial (int ChangeX = 0,int ChangeY = 0)
        {
       
        int? Ax = HttpContext.Session.GetInt32("Ax");
        int? Ay = HttpContext.Session.GetInt32("Ay");
        int? Bx = HttpContext.Session.GetInt32("Bx");
        int? By = HttpContext.Session.GetInt32("By");
        int? Cx = HttpContext.Session.GetInt32("Cx");
        int? Cy = HttpContext.Session.GetInt32("Cy");
        int? Dx = HttpContext.Session.GetInt32("Dx");
        int? Dy = HttpContext.Session.GetInt32("Dy");
        int? Score = HttpContext.Session.GetInt32("Score");
        int? level = HttpContext.Session.GetInt32("Level");

        Ax += ChangeX * 30;
        Bx += ChangeX * 30;
        Cx += ChangeX * 30;
        Dx += ChangeX * 30;
        Ay -= ChangeY * 30;
        By -= ChangeY * 30;
        Cy -= ChangeY * 30;
        Dy -= ChangeY * 30;
        Score += 1;
        

        if (Ax > 610 && Bx > 610 && Cx > 610 && Dx > 610 || Ay > 610 && By > 610 && Cy > 610 && Dy > 610 || Ax < 10 && Bx < 10 && Cx < 10 && Dx < 10 || Ay < 10 && By < 10 && Cy < 10 && Dy < 10) {
            //ViewBag.OffGrid = true;
            Ax -= ChangeX * 30;
            Bx -= ChangeX * 30;
            Cx -= ChangeX * 30;
            Dx -= ChangeX * 30;
            Ay += ChangeY * 30;
            By += ChangeY * 30;
            Cy += ChangeY * 30;
            Dy += ChangeY * 30;

        }

        HttpContext.Session.SetInt32("Ax", (int)Ax);
        HttpContext.Session.SetInt32("Ay", (int)Ay);
        HttpContext.Session.SetInt32("Bx", (int)Bx);
        HttpContext.Session.SetInt32("By", (int)By);
        HttpContext.Session.SetInt32("Cx", (int)Cx);
        HttpContext.Session.SetInt32("Cy", (int)Cy);
        HttpContext.Session.SetInt32("Dx", (int)Dx);
        HttpContext.Session.SetInt32("Dy", (int)Dy);
        HttpContext.Session.SetInt32("Score", (int)Score); 

            return Redirect ($"/{level}");
        }

         public IActionResult ReflectionPartialX ()
        {
        
        int? Ay = HttpContext.Session.GetInt32("Ay");
        int? By = HttpContext.Session.GetInt32("By");
        int? Cy = HttpContext.Session.GetInt32("Cy");
        int? Dy = HttpContext.Session.GetInt32("Dy");
        int? Score = HttpContext.Session.GetInt32("Score");
         int? level = HttpContext.Session.GetInt32("Level");
    
        Ay = 310 + (310 - Ay);
        By = 310 + (310 - By);
        Cy = 310 + (310 - Cy);
        Dy = 310 + (310 - Dy);
        Score += 1;
        
        HttpContext.Session.SetInt32("Ay", (int)Ay);
        HttpContext.Session.SetInt32("By", (int)By);
        HttpContext.Session.SetInt32("Cy", (int)Cy);
        HttpContext.Session.SetInt32("Dy", (int)Dy);
        HttpContext.Session.SetInt32("Score", (int)Score); 
       
            return Redirect ($"/{level}");
        }

         public IActionResult ReflectionPartialY ()
        {
        int? Ax = HttpContext.Session.GetInt32("Ax");
        int? Bx = HttpContext.Session.GetInt32("Bx");
        int? Cx = HttpContext.Session.GetInt32("Cx");
        int? Dx = HttpContext.Session.GetInt32("Dx");
        int? Score = HttpContext.Session.GetInt32("Score");
        int? level = HttpContext.Session.GetInt32("Level");
    
        Ax = 310 + (310 - Ax);
        Bx = 310 + (310 - Bx);
        Cx = 310 + (310 - Cx);
        Dx = 310 + (310 - Dx);
        Score += 1;
     
        HttpContext.Session.SetInt32("Ax", (int)Ax);
        HttpContext.Session.SetInt32("Bx", (int)Bx);
        HttpContext.Session.SetInt32("Cx", (int)Cx);
        HttpContext.Session.SetInt32("Dx", (int)Dx);
        HttpContext.Session.SetInt32("Score", (int)Score); 

            return Redirect ($"/{level}");
        }

        public IActionResult RotationPartial (int DegreeDirection)
        {
        
        int? Ax = HttpContext.Session.GetInt32("Ax");
        int? Ay = HttpContext.Session.GetInt32("Ay");
        int? Bx = HttpContext.Session.GetInt32("Bx");
        int? By = HttpContext.Session.GetInt32("By");
        int? Cx = HttpContext.Session.GetInt32("Cx");
        int? Cy = HttpContext.Session.GetInt32("Cy");
        int? Dx = HttpContext.Session.GetInt32("Dx");
        int? Dy = HttpContext.Session.GetInt32("Dy");
        int? Score = HttpContext.Session.GetInt32("Score");
        int? level = HttpContext.Session.GetInt32("Level");

        
        int[] pairA = RotateCoordinates ((int)Ax, (int)Ay, DegreeDirection);
        int[] pairB = RotateCoordinates ((int)Bx, (int)By, DegreeDirection);
        int[] pairC = RotateCoordinates ((int)Cx, (int)Cy, DegreeDirection);
        int[] pairD = RotateCoordinates ((int)Dx, (int)Dy, DegreeDirection);
        Score += 1;

        HttpContext.Session.SetInt32("Ax", pairA[0]);
        HttpContext.Session.SetInt32("Ay", pairA[1]);
        HttpContext.Session.SetInt32("Bx", pairB[0]);
        HttpContext.Session.SetInt32("By", pairB[1]);
        HttpContext.Session.SetInt32("Cx", pairC[0]);
        HttpContext.Session.SetInt32("Cy", pairC[1]);
        HttpContext.Session.SetInt32("Dx", pairD[0]);
        HttpContext.Session.SetInt32("Dy", pairD[1]);
        HttpContext.Session.SetInt32("Score", (int)Score); 
        
            return Redirect ($"/{level}");
        }
    }
}