using System.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDAngularJS.Models;
using System.IO;

namespace CRUDAngularJS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UsuarioCRUD()
        {
            ViewBag.Message = "Mantenedor de Usuarios";
            return View();
        }

        public JsonResult Guardar(UsuarioClass usuario)
        {            
            string json = JsonConvert.SerializeObject(usuario);

            System.IO.File.WriteAllText(Server.MapPath("~/usuario.json"), json);

            StreamReader r = new StreamReader(Server.MapPath("~/usuario.json"));
            string jsonString = r.ReadToEnd();
            UsuarioClass mRes = JsonConvert.DeserializeObject<UsuarioClass>(jsonString);
            r.Close();

            return Json(mRes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Actualizar(UsuarioClass usuario)
        {
            string json = JsonConvert.SerializeObject(usuario);

            System.IO.File.WriteAllText(Server.MapPath("~/usuario.json"), json);

            StreamReader r = new StreamReader(Server.MapPath("~/usuario.json"));
            string jsonString = r.ReadToEnd();
            UsuarioClass mRes = JsonConvert.DeserializeObject<UsuarioClass>(jsonString);
            r.Close();

            return Json(mRes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerPorId(int Id)
        {
            StreamReader r = new StreamReader(Server.MapPath("~/usuario.json"));
            string jsonString = r.ReadToEnd();
            UsuarioClass mRes = JsonConvert.DeserializeObject<UsuarioClass>(jsonString);
            r.Close();

            return Json(mRes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Listar()
        {
            StreamReader r = new StreamReader(Server.MapPath("~/usuario.json"));
            string jsonString = r.ReadToEnd();
            UsuarioClass mRes = JsonConvert.DeserializeObject<UsuarioClass>(jsonString);
            r.Close();

            return Json(mRes);
        }

        public JsonResult Eliminar(int Id)
        {
            System.IO.File.WriteAllText(Server.MapPath("~/usuario.json"), String.Empty);

            StreamReader r = new StreamReader(Server.MapPath("~/usuario.json"));
            string jsonString = r.ReadToEnd();
            UsuarioClass mRes = JsonConvert.DeserializeObject<UsuarioClass>(jsonString);
            r.Close();

            return Json(mRes, JsonRequestBehavior.AllowGet);

        }
    }
}