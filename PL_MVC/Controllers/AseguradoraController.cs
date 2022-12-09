using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AseguradoraController : Controller
    {
        // GET: Aseguradora

        [HttpGet] 
        public ActionResult GetAll()
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            ServiceAseguradora.AseguradoraClient context = new ServiceAseguradora.AseguradoraClient();

            var result = context.GetAll();
            //ML.Result result = new ML.Result();
            //result = BL.Aseguradora.GetAllEF();

            if (result.Correct)
            {
                //ML.Aseguradora aseguradora = new ML.Aseguradora();
                aseguradora.Aseguradoras = result.Objects.ToList();
                //return View(aseguradora);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
                //return View();
            }
            return View(aseguradora);
        }

        [HttpGet]
        public ActionResult Form(int? IdAseguradora)
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            ServiceAseguradora.AseguradoraClient context = new ServiceAseguradora.AseguradoraClient();



            //ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario= new ML.Usuario();
            aseguradora.Usuario.Rol = new ML.Rol();


            ML.Result resultUsuario = BL.Usuario.GetAllEF(aseguradora.Usuario);

            if (IdAseguradora == null)
            {
                aseguradora.Usuario.Usuarios = resultUsuario.Objects;
                //return View(aseguradora);
            }
            else
            {
                //GetbyId
                //ML.Result result = BL.Aseguradora.GetByIdEF(IdAseguradora.Value);
                var result = context.GetById(IdAseguradora.Value);

                if (result.Correct)
                {
                    aseguradora = (ML.Aseguradora)result.Object;
                    aseguradora.Usuario.Usuarios = resultUsuario.Objects;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar la aseguradora seleccionada";
                }
                //return View(aseguradora);
            }
            return View(aseguradora);

        }

        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora)
        {

            ServiceAseguradora.AseguradoraClient context = new ServiceAseguradora.AseguradoraClient();

            
            //ML.Result result = new ML.Result();

            if (aseguradora.IdAseguradora == 0)
            {
                //add
                //result = BL.Aseguradora.AddEF(aseguradora);
                var result = context.Add(aseguradora);

                if (result.Correct)
                {
                    ViewBag.Message = "Se ha registrado la aseguradora";
                    //return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se ha registrado la aseguradora" + result.ErrorMessage;
                    //return PartialView("Modal");
                }
                return PartialView("Modal");
            }
            else
            {
                //update
                //result = BL.Aseguradora.UpdateEF(aseguradora);
                var result = context.Update(aseguradora);
                if (result.Correct)
                {
                    ViewBag.Message = "Se ha actualizado la aseguradora";
                    //return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se ha actualizado la aseguradora" + result.ErrorMessage;
                    //return PartialView("Modal");
                }
                return PartialView("Modal");
            }
        }

        [HttpGet]
        public ActionResult Delete(int IdAseguradora)
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            ServiceAseguradora.AseguradoraClient context = new ServiceAseguradora.AseguradoraClient();

            var result = context.Delete(IdAseguradora);

            //ML.Result result = new ML.Result();
            //result = BL.Aseguradora.DeleteEF(IdAseguradora);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha elimnado el registro";
                //return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha elimnado el registro" + result.ErrorMessage;
                //return PartialView("Modal");
            }
            return PartialView("Modal");
        }
    }
}