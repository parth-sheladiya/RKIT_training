using FinalDemo.BL.Interface;
using FinalDemo.BL.Operations;
using FinalDemo.Filters;
using FinalDemo.Models;
using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLPDT01 : ControllerBase
    {
        private Response _objResponse;
        //private readonly BLPdt _objBLPdt;
        private IBLPDT _objBLPdt;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="objResponse"></param>
        /// <param name="objBLPdt"></param>
        public CLPDT01(Response objResponse, IBLPDT objBLPdt)
        {
            _objResponse = objResponse;
            _objBLPdt = objBLPdt;
        }

        /// <summary>
        /// get all product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllProducts")]
        [AuthFilter("Admin","User")]
        public IActionResult GetAllProducts()
        {

            _objResponse = _objBLPdt.GetAllProducts();
            return Ok(_objResponse);
        }

        /// <summary>
        /// get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getProductById")]
        [AuthFilter("Admin", "User")]
        public IActionResult GetProductByid(int id)
        {

            _objResponse = _objBLPdt.GetProductByid(id);
            return Ok(_objResponse);
        }

        /// <summary>
        /// add product
        /// </summary>
        /// <param name="objDtoPDT01"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addProduct")]
        [AuthFilter("Admin")]
        public IActionResult AddPRoduct(DTOPDT01 objDtoPDT01)
        {

            _objBLPdt.typeOfOperation = EnumType.A;
            _objBLPdt.PreSave(objDtoPDT01);
            _objResponse = _objBLPdt.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLPdt.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// update product
        /// </summary>
        /// <param name="objDtoPDT01"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateProduct")]
        [AuthFilter("Admin")]
        public IActionResult UpdateProduct(DTOPDT01 objDtoPDT01)
        {
            _objBLPdt.typeOfOperation = EnumType.U;
            _objBLPdt.PreSave(objDtoPDT01);
            _objResponse = _objBLPdt.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLPdt.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteProduct")]
        [AuthFilter("Admin")]
        public IActionResult DeleteProduct(int id)
        {
            _objResponse = _objBLPdt.Delete(id);
            return Ok(_objResponse);
        }
    }
}
