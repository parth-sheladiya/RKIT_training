using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ORMrevision.Models;
using ORMrevision.Models.ENUM;
using ORMrevision.Models.POCO;
using ORMrevision.Models.DTO;
using ORMrevision.BL.Interface;
using ORMrevision.BL.Operations;
using System.Web.Routing;

namespace ORMrevision.Controllers
{
    public class DataController : ApiController
    {
        private readonly IDataOperations _objIDataHandler = new IDataOperations();


        private Responce _objresponce;

        [HttpGet]
        [Route("GetAllProducts")]
        public IHttpActionResult GetAllProduct()
        {
            var products = _objIDataHandler.GetAll();
            return Ok(products);
        }

        [HttpGet]
        [Route("getProductByid")]

        public IHttpActionResult GetProdById(int id)
        {
            var prodById = _objIDataHandler.GetByID(id);

            return Ok(prodById);
        }

        [HttpPost]
        [Route("AddProduct")]

        public IHttpActionResult AddProduct(Product_DTO objProductDTO)
        {
            _objIDataHandler.Type = EnumType.A;
            _objIDataHandler.preSave(objProductDTO);
            _objresponce = _objIDataHandler.Validation();
            if(!(_objresponce.IsError))
            {
                _objresponce = _objIDataHandler.Save();
            }

            return Ok(objProductDTO);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public IHttpActionResult UpdateProduct(Product_DTO objProductDTO)
        {
            _objIDataHandler.Type = EnumType.E;
            _objIDataHandler.preSave(objProductDTO);
            _objresponce = _objIDataHandler.Validation();
            if (!(_objresponce.IsError))
            {
                _objresponce = _objIDataHandler.Save();
            }

            return Ok(objProductDTO);
        }


        [HttpDelete]
        [Route("DeleteProduct")]

        public IHttpActionResult DeleteProduct(int id)
        {
            _objresponce = _objIDataHandler.Delete(id);
            if(_objresponce.IsError )
            {
                return BadRequest(_objresponce.Message);
            }

            return Ok(_objresponce.Message);
        }


    }
}
