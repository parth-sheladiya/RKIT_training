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
        /// Retrieves all employees.
        /// </summary>

        [HttpGet]
        [Route("GetAllProducts")]
        public IHttpActionResult GetAllProduct()
        {
            var products = _objBLproduct.GetAllPDT();

            return Ok(products);
        }

        /// <summary>
        /// Retrieves an employee by ID.
        /// </summary>


        [HttpGet]
        [Route("getProductById")]
        public IHttpActionResult GetProductByID(int id)
        {
            var productByid = _objBLproduct.GetPDTbyID(id);
            if(productByid == null)
            {
                return NotFound();

            }
            return Ok(productByid);
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>

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
            return Ok(product);

        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
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
            return Ok(product); 
        }
        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>


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
        /// Validates if an employee exists by their ID.
        /// </summary>

        [HttpGet]
        [Route("CheckProductISExistsOrNot")]
        public IHttpActionResult IsProductExistOrNot(int id)
        {
            var Isprod = _objBLproduct.GetPDTbyID(id);
            if (Isprod == null)
            {
                return NotFound();
            }    

            return Ok(Isprod);
        }
    }
}
