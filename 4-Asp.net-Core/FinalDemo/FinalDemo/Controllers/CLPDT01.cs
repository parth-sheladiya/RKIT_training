using FinalDemo.BL.Operations;
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
        private readonly BLPdt _objBLPdt;

        public CLPDT01(Response objResponse, BLPdt objBLPdt)
        {
            _objResponse = objResponse;
            _objBLPdt = objBLPdt;
        }

        [HttpGet]
        [Route("getAllProducts")]
        public IActionResult GetAllProducts()
        {

            _objResponse = _objBLPdt.GetAll();
            return Ok(_objResponse);
        }

        [HttpGet]
        [Route("getProductById")]
        public IActionResult GetProductByid(int id)
        {

            _objResponse = _objBLPdt.GetByid(id);
            return Ok(_objResponse);
        }


        [HttpPost]
        [Route("addProduct")]

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

        [HttpPut]
        [Route("updateProduct")]
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

        [HttpDelete]
        [Route("deleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            _objResponse = _objBLPdt.Delete(id);
            return Ok(_objResponse);
        }
    }
}
