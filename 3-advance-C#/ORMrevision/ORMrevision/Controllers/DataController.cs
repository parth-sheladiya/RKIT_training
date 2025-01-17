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
using Newtonsoft.Json;


namespace ORMrevision.Controllers
{
    public class DataController : ApiController
    {
        /// <summary>
        /// create object for Business logic operations class 
        ///  if we are not create object then given null refrence error
        ///  System.NullReferenceException: 'Object reference not set to an instance of an object.
        /// </summary>
        private readonly IDataOperations _objIDataOperations = new IDataOperations();

        /// <summary>
        /// responce object because it is store to responce from database and handle by data operations
        /// </summary>
        private Responce _objresponce;

        /// <summary>
        /// get request it is return existing products
        /// </summary>
        /// <returns>return existing products</returns>
        [HttpGet]
        [Route("GetAllProducts")]
        public IHttpActionResult GetAllProduct()
        {
            // data operation from actual logic part from business logic 
            var products = _objIDataOperations.GetAll();
            return Ok(products);
        }

        /// <summary>
        /// getProdByid it is get for existing user other wise responce will give error 
        /// error handle in business logic
        /// </summary>
        /// <param name="id">this id is search from database and given responce</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getProductByid")]

        public IHttpActionResult GetProdById(int id)
        {
            // call businesslogic method
            _objresponce  = _objIDataOperations.GetByID(id);

            // it id not found then return responce 
            // responce convert to json string 
            // because httpreq is not handle to obj  responce 
            string jsonStr =  JsonConvert.SerializeObject(_objresponce);
            // check data is null or not other wise it will return dataobj responce 
            if(_objresponce.Data == null)
            {
                return BadRequest(jsonStr);
            }
            // return one existing product
            return Ok(_objresponce);
        }

        /// <summary>
        /// add request it is store data to the database by poco model
        /// </summary>
        /// <param name="objProductDTO">it is convert DTO to POCO model. beacause it ise need for data base communications 
        ///  poco model implementation in business logic data operation </param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProduct")]
        public IHttpActionResult AddProduct(Product_DTO objProductDTO)
        {
           // it is set for Add operation
            _objIDataOperations.Type = EnumType.A;
            // it is convert to poco model in presave method
            _objIDataOperations.preSave(objProductDTO);
            // before save we use a vaidation method 
            _objresponce = _objIDataOperations.Validation();
            // if not any error in  business login then data is add and save in database 
            if(!(_objresponce.IsError))
            {
                _objresponce = _objIDataOperations.Save();
            }

            return Ok(_objresponce);
        }
        /// <summary>
        /// update product 
        /// </summary>
        /// <param name="objProductDTO">it is dto to poco model </param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateProduct")]
        public IHttpActionResult UpdateProduct(Product_DTO objProductDTO)
        {
            // it is set to E for edit 
            _objIDataOperations.Type = EnumType.E;
            // dto data is convert to poco model and then we will edit data 
            // before save data a presave method set an id and then we add logic 
            _objIDataOperations.preSave(objProductDTO);
            // check validation
            _objresponce = _objIDataOperations.Validation();
            // incase not any error then data will update and save in database 
            if (!(_objresponce.IsError))
            {
                _objresponce = _objIDataOperations.Save();
            }


             // return responce 
            return Ok(_objresponce);
        }

        /// <summary>
        /// delete method it is remove data in database 
        /// </summary>
        /// <param name="id">user enter id and then system will  verify id </param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteProduct")]

        public IHttpActionResult DeleteProduct(int id)
        {
            //delete data using id 
            _objresponce = _objIDataOperations.Delete(id);

            // return responce 
            return Ok(_objresponce);
        }


    }
}
