using ORMdemo.BL.Operations;
using ORMdemo.Models;
using ORMdemo.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ORMdemo.Models.ENUM;
using ORMdemo.Models.POCO;

namespace ORMdemo.Controllers
{
    /// <summary>
    /// Controller to manage employee-related API operations.
    /// </summary>
    public class CL_ProductController : ApiController
    {
        private readonly BL_Product _objBLproduct= new BL_Product();

        private Response _objresponce;

        /// <summary>
        /// return all product
        /// </summary>
        /// <returns>responce</returns>

        [HttpGet]
        [Route("GetAllProducts")]
        public IHttpActionResult GetAllProduct()
        {
            _objresponce = _objBLproduct.GetAllPDT();

            return Ok(_objresponce);
        }


        /// <summary>
        /// fet product by id
        /// </summary>
        /// <param name="id">enter product id</param>
        /// <returns>responce</returns>
        [HttpGet]
        [Route("GetProductById")]
        public IHttpActionResult GetProductByID(int id)
        {
            _objresponce = _objBLproduct.GetPDTbyID(id); // Get product as PDT01


            return Ok(_objresponce);
        }


        /// <summary>
        /// addn product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>responce</returns>
        [HttpPost]
        [Route("AddProduct")]
        public IHttpActionResult AddProduct(DTO_PDT01 product)
        {
            _objBLproduct.Type = EnumType.A;
            _objBLproduct.PreSave(product);
            _objresponce = _objBLproduct.Validation();
            if(!_objresponce.IsError)
            {
                _objresponce = _objBLproduct.Save();
            }
            return Ok(_objresponce);

        }

        /// <summary>
        /// update product
        /// </summary>
        /// <param name="product">enter product id</param>
        /// <returns>responce</returns>
        [HttpPut]
        [Route("UpdateProduct")]
        public IHttpActionResult UpdateProduct(DTO_PDT01 product)
        {
            _objBLproduct.Type = EnumType.E;
            _objBLproduct.PreSave(product);
            _objresponce = _objBLproduct.Validation();
            if(!_objresponce.IsError)
            {
                _objresponce = _objBLproduct.Save();
            }
            return Ok(_objresponce); 
        }


        /// <summary>
        /// delete product
        /// </summary>
        /// <param name="id">enter product id</param>
        /// <returns>responce</returns>
        [HttpDelete]
        [Route("deleteProduct")]
        public IHttpActionResult DeleteProduct(int id)
        {
            _objresponce = _objBLproduct.Delete(id);
            if(_objresponce.IsError)
            {
                return BadRequest(_objresponce.Message);
            }
            return Ok(_objresponce.Message);
        }


        /// <summary>
        /// check product is exist or not
        /// </summary>
        /// <param name="id">enter product id</param>
        /// <returns>responce</returns>
        [HttpGet]
        [Route("CheckProductISExistsOrNot")]
        public IHttpActionResult IsProductExistOrNot(int id)
        {
            _objresponce = _objBLproduct.GetPDTbyID(id);
              

            return Ok(_objresponce);
        }
    }
}
