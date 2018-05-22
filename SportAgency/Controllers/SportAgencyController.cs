using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using SportAgency.Models;
using System.IO;
using System.Diagnostics;

namespace SportAgency.Controllers
{
    public class SportAgencyController : Controller
    {
        // GET: SportAgency//Show
        public ActionResult Show()
        {
            FileLoad fl = new FileLoad();
            ModelState.Clear();
            return View(fl.GetAthleteAndAgent());
        }
            
     
    
        // GET: SportAgency/Load
        public ActionResult Load()
        {
            return View();
        }

        // GET: SportAgency/LoadSports
        public ActionResult uploadSports()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string filepath = ConfigurationManager.AppSettings["Path"].ToString();
                    //string relativePath = ConfigurationManager.AppSettings["Path"];
                    //Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath)

                    if (filepath != null)
                    {
                        FileLoad fl = new FileLoad();
                        if (fl.insertsport(filepath) == 1) 
                        {
                            ViewBag.Message = "Sports Inserted";
                        }
                        else
                        {
                            ViewBag.Message = "Insertion failed";
                        }
                    }
                }
            }

            catch (Exception e)
            {
                Debug.WriteLine("Error: {0}", e.ToString());
               // ViewBag.Message = e.ToString();
            }
            return RedirectToAction("Load");
        }


        // GET: SportAgency/ LoadAthletesandAgent
        [HttpPost]
        public ActionResult uploadathleteandagent(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string filepath = collection["textFileDirectory"];

                    if (filepath != null && !filepath.Trim().Equals(""))
                    {
                        filepath = filepath.Trim();
                        FileLoad fl = new FileLoad();
                        string agentfilepath = filepath + "\\Agents.txt";
                        string athletefilepath = filepath + "\\Athletes.txt";
                        if (fl.insertagent(agentfilepath) == 1)
                        {
                            ViewBag.Message = "Agent inserted";
                        }
                        else
                        {
                            ViewBag.Message = "Insertion failed";
                        }
                        if (fl.insertathlete(athletefilepath) == 1)
                        {
                            ViewBag.Message = "Athelete inserted";
                        }
                        else
                        {
                            ViewBag.Message = "Insertion failed";
                        }

                    }
                }
            }

            catch (Exception e)
            {
                Debug.WriteLine("Error: {0}", e.ToString());
                ViewBag.Message = e.ToString();
            }
            
            return RedirectToAction("Load"); ;
        }

       
    }
}
