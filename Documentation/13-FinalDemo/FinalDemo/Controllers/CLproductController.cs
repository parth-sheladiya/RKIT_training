using FinalDemo.BL.Operations;
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
    /// <summary>
    /// Controller for  product-related API 
    /// </summary>
    [RoutePrefix("api/CLproduct")]
    public class CLproductController : ApiController
    {
        private BLproduct _objBlProduct;
        private Responce _objResponce;

        /// <summary>
        ///ctor
        /// </summary>
        public CLproductController()
        {
            _objBlProduct = new BLproduct();
            _objResponce = new Responce();
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>List of products.</returns>
        [HttpGet]
        [Route("Products")]
        [JWTAuthorizationFilter(EnmRoleType.Admin, EnmRoleType.User)] // Only Admin and User can access
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                // get all method call
                _objResponce.Data = _objBlProduct.GetAll();

                // response
                return Ok(_objResponce);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error occurred: {ex.Message}"));
            }
        }

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <returns>Product details.</returns>
        [HttpGet]
        [Route("ProductById")]
        [JWTAuthorizationFilter(EnmRoleType.Admin, EnmRoleType.User)]
        public IHttpActionResult GetById(int id)
        {
            // prduct by id method call
            _objResponce.Data = _objBlProduct.GetProductById(id);

            // response
            return Ok(_objResponce);
        }

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="objProductDto">Product data transfer object.</param>
        /// <returns>Success or failure response.</returns>
        [HttpPost]
        [Route("AddProduct")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)]
        public IHttpActionResult AddProduct(DTOPDT01 objProductDto)
        {
            if (objProductDto == null)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "Product details are required.";
            }

            // type Add
            _objBlProduct.Type = EnumType.A;

            // presave method call
            _objBlProduct.PreSave(objProductDto);

            // validation method call
            _objResponce = _objBlProduct.Validation();
            if (!_objResponce.IsError)
            {
                _objResponce = _objBlProduct.Save();
                _objResponce.Message = "Product added successfully.";
            }

            // response
            return Ok(_objResponce);
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="objProductDto">Product data transfer object.</param>
        /// <returns>Success or failure response.</returns>
        [HttpPut]
        [Route("UpdateProduct")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)]
        public IHttpActionResult UpdateProduct(DTOPDT01 objProductDto)
        {
            if (objProductDto == null)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "Product details are required.";
                return Ok(_objResponce);
            }


            // type edit
            _objBlProduct.Type = EnumType.E;

            // presave method call
            _objBlProduct.PreSave(objProductDto);

            // validation method call
            _objResponce = _objBlProduct.Validation();

            // if any error
            if (!_objResponce.IsError)
            {
                _objResponce = _objBlProduct.Save();
                _objResponce.Message = "Product updated successfully.";
            }

            // response
            return Ok(_objResponce);
        }

        /// <summary>
        /// Deletes a product by ID.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <returns>Success or failure response.</returns>
        [HttpDelete]
        [Route("DeleteProduct")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)]
        public IHttpActionResult DeleteProduct(int id)
        {

            // delte method call
            _objResponce = _objBlProduct.Delete(id);

            // response
            return Ok(_objResponce);
        }

        /// <summary>
        /// Retrieves products by category.
        /// </summary>
        /// <param name="category">Product category.</param>
        /// <returns>List of products in the specified category.</returns>
        [HttpGet]
        [Route("ProductsByCategory")]
        // Allow Admin and User roles to access
        [JWTAuthorizationFilter(EnmRoleType.Admin, EnmRoleType.User)] 
        public IHttpActionResult GetProductsByCategory(string category)
        {
                // get product by category method call
                _objResponce = _objBlProduct.GetProcuctByCategory(category);

                // response
                return Ok(_objResponce);   
        }
    }
}