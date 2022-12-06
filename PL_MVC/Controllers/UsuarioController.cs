using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        //[HttpPost]
        //[HttpPut]
        //[HttpDelete]
        //[HttpPatch]

        [HttpGet]
        public ActionResult GetAll()
        {

            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = new ML.Result();

            usuario.Rol = new ML.Rol();

            ML.Result resultRol = BL.Rol.GetAll();
            result = BL.Usuario.GetAllEF(usuario);


            if (result.Correct)
            {
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
                return View();
            }
        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            ML.Result resultRol = BL.Rol.GetAll();
            result = BL.Usuario.GetAllEF(usuario);


            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                usuario.Rol.Roles = resultRol.Objects;

                return View(usuario);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            ML.Result resultPaises = BL.Pais.GetAll();
            ML.Result resultRol = BL.Rol.GetAll();

            if (IdUsuario == null)
            {
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;
                return View(usuario);
            }
            else
            {
                //GetbyId
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);

                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                    usuario.Rol.Roles = resultRol.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;

                    ML.Result resultEstados = BL.Estado.EstadoGetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;

                    ML.Result resultMunicipios = BL.Municipio.MunicipioGetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;

                    ML.Result resultColonias = BL.Colonia.ColoniaGetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    usuario.Direccion.Colonia.Colonias = resultColonias.Objects;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el usuario seleccionado";
                }
                return View(usuario);
            }

        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            HttpPostedFileBase file = Request.Files["ImagenData"];

            //if (file.ContentLength > 0)
            //{
            //    usuario.Imagen = ConvertToBytes(file);
            //}

            if (usuario.IdUsuario == 0)
            {
                //add
                result = BL.Usuario.AddEF(usuario);

                if (result.Correct)
                {
                    ViewBag.Message = "Se ha registrado el usuario";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No ha registrado el usuario" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                //update
                result = BL.Usuario.UpdateEF(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "Se ha Actualizado el usuario";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No ha registrado el usuario" + result.ErrorMessage;
                    return PartialView("Modal");
                }

            }
        }

        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            result = BL.Usuario.DeleteEF(IdUsuario);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha elimnado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha elimnado el registro" + result.ErrorMessage;
                return PartialView("Modal");
            }
        }

        public JsonResult GetEstado(int IdPais)
        {
            var result = BL.Estado.EstadoGetByIdPais(IdPais);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.MunicipioGetByIdEstado(IdEstado);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.ColoniaGetByIdMunicipio(IdMunicipio);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

        return data;
        }
    }
}