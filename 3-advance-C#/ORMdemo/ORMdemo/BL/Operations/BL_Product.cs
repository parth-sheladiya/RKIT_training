using ORMdemo.BL.Interface;
using ORMdemo.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using ORMdemo.Models.ENUM;
using ORMdemo.Models.POCO;
using ORMdemo.Models;
using ServiceStack.Data;
using System.Web.Security;
using ORMdemo.Extensions;


namespace ORMdemo.BL.Operations
{
    public class BL_Product : IDataHandler<DTO_PDT01>
    {
        // poco class 
        private PDT01 _objPDT01;

        private int _id;

        private Response _objresponce;

        private readonly IDbConnectionFactory _dbfactory;

        public EnumType Type { get; set; }


        public BL_Product()
        {
            // create obj of responce   error , message , data
            _objresponce = new Response();

            //  db connection factory 
            _dbfactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;  

            // check  connection data is null or not
            if(_dbfactory == null )
            {
                throw new Exception("connection not found ");
            }
        }


        public List<PDT01> GetAllPDT()
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                return db.Select<PDT01>().ToList();
            }
        }

        public PDT01 GetPDTbyID(int id )
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                return db.SingleById<PDT01>(id);
            }
        }


        private  bool IsProductExists(int id)
        {
            using (var db= _dbfactory.OpenDbConnection())
            {
                return db.Exists<PDT01>(id);
            }
        }

        private PDT01 PreDelete(int id)
        {
            if(IsProductExists(id))
            {
                return GetPDTbyID(id);
            }

            return null;
        }


        public Response validateOndelete(PDT01 objPDT01)
        {
            if(objPDT01 == null)
            {
                _objresponce.IsError = true;
                _objresponce.Message="product not found";
                return _objresponce;
            }

           _objresponce.IsError=false;
            return _objresponce;
        }

        public Response Delete(int id)
        {
            var product = PreDelete(id);

            var validateResponce = validateOndelete(product);

            if(validateResponce.IsError)
            {
                return validateResponce;
            }

            using (var db = _dbfactory.OpenDbConnection())
            {
                db.DeleteById<PDT01>(id);
            }
            _objresponce.Message = "Data Deleted";
            return _objresponce;
        }

        public void PreSave (DTO_PDT01 objDTO)
        {
            _objPDT01 = objDTO.Convert<PDT01>();
            if(Type == EnumType.E && objDTO.Id>0)
            {
                _id = objDTO.Id;
            }
        }


        public Response Validation()  
        {
            if(Type == EnumType.E)
            {
                if(!(_id>0))
                {
                    _objresponce.IsError = true;
                    _objresponce.Message = "enter correct id";
                }
                else if(!IsProductExists(_id))
                {
                    _objresponce.IsError = true;
                    _objresponce.Message = "product not found";
                }
                return _objresponce;
            }
            return new Response();
        }

        public Response Save()
        {
            try
            {
                using (var db= _dbfactory.OpenDbConnection())
                {
                    if(Type == EnumType.A)
                    {
                        db.Insert(_objPDT01);
                        _objresponce.Message = "data added";
                    }
                    else if(Type == EnumType.E )
                    {
                        db.Update(_objPDT01);
                        _objresponce.Message = "Data updated";
                    }
                }
            }
            catch(Exception ex)
            {
                _objresponce.IsError= true;
                _objresponce.Message= "error from global handler :  "+ex.Message;
               
            }

            return _objresponce;
        }

    

       
    }
}