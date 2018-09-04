using ClientRegistration.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace TestClient.Controllers
{
    public class BusinessAdminRegistrationController : Controller
    {
        // GET: BusinessAdminRegistration
        public ActionResult Index()
        {
            return View();
        }

        // GET: BusinessAdminRegistration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BusinessAdminRegistration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessAdminRegistration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel registerView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        //HTTP POST
                        registerView.Role = "BusinessAdmin";
                        registerView.RegistrationDate = DateTime.Now;
                        var json = new JavaScriptSerializer().Serialize(registerView);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                        var registerContent = new ByteArrayContent(buffer);

                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var sendData = await client.PostAsync(path, registerContent);

                        if (sendData.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e.InnerException;

            }
            return View(registerView);

        }

        // GET: BusinessAdminRegistration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BusinessAdminRegistration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessAdminRegistration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BusinessAdminRegistration/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
