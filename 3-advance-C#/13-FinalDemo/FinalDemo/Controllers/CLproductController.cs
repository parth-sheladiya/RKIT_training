﻿using FinalDemo.BL.Operations;
using FinalDemo.Models;
using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalDemo.Controllers
{
    [RoutePrefix("api/CLproduct")]
    public class CLproductController : ApiController
    {

        private BLproduct _objBlProduct;
        private Responce _objResponce;

        public CLproductController()
        {
            _objBlProduct = new BLproduct();
            _objResponce = new Responce();
        }

        [HttpGet]
        [Route("Products")]
        [JWTAuthorizationFilter(EnmRoleType.Admin,EnmRoleType.User)] // Only Admin can access this method
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                _objResponce.Data = _objBlProduct.GetAll();
                return Ok(_objResponce);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error occurred: {ex.Message}"));
            }
        }


        [HttpGet]
        [Route("ProductById")]
        [JWTAuthorizationFilter(EnmRoleType.Admin, EnmRoleType.User)]
        public IHttpActionResult GetById(int id)
        {
            _objResponce.Data = _objBlProduct.GetProductById(id);
            return Ok(_objResponce);
        }

        [HttpPost]
        [Route("AddProduct")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)]
        public IHttpActionResult AddProduct(ProductDto objProductDto)
        {
            if (objProductDto == null)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "product details are required.";
            }

            _objBlProduct.Type = EnumType.A;
            _objBlProduct.PreSave(objProductDto);
            _objResponce = _objBlProduct.Validation();
            if (!_objResponce.IsError)
            {
                _objResponce = _objBlProduct.Save();
                _objResponce.Message = "product Added Successfully";
            }
            return Ok(_objResponce);

        }


        [HttpPut]
        [Route("UpdateProduct")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)]
        public IHttpActionResult UpdateProduct(ProductDto objProductDto)
        {
            if (objProductDto == null)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "product details are required.";
                return Ok(_objResponce);
            }

            _objBlProduct.Type = EnumType.E;
            _objBlProduct.PreSave(objProductDto);
            _objResponce = _objBlProduct.Validation();
            if (!_objResponce.IsError)
            {
                _objResponce = _objBlProduct.Save();
                _objResponce.Message = "product Updated Successfully";
            }
            return Ok(_objResponce);
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)]
        public IHttpActionResult DeleteProduct(int id)
        {
            _objResponce = _objBlProduct.Delete(id);
            return Ok(_objResponce);
        }


        [HttpGet]
        [Route("ProductsByCategory")]
        [JWTAuthorizationFilter(EnmRoleType.Admin, EnmRoleType.User)] // Allow Admin and User roles to access
        public IHttpActionResult GetProductsByCategory(string category)
        {
            try
            {
                _objResponce = _objBlProduct.GetProcuctByCategory(category);
                return Ok(_objResponce);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error occurred: {ex.Message}"));
            }
        }

    }
}
