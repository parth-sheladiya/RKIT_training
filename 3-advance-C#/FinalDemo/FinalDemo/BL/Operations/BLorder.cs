using FinalDemo.BL.Interface;
using FinalDemo.Models.ENUM;
using FinalDemo.Models;
using FinalDemo.Models.POCO;
using ServiceStack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ServiceStack.OrmLite;
using FinalDemo.Models.DTO;
using FinalDemo.Extension;

namespace FinalDemo.BL.Operations
{
    public class BLorder : IDataHandler<OrderDto>
    {
        private Order _objOrder;
        private BLuser _objUser;
        private BLproduct _objProduct;
        private Responce _objResponce;
        private IDbConnectionFactory _dbfactory;
        int _id;
        private EnmRoleType roleType;
        public EnumType Type { get; set; }


        public BLorder()
        {
            _objOrder = new Order();
            _objResponce = new Responce();
            _objUser = new BLuser();
            _objProduct = new BLproduct();
            _dbfactory = HttpContext.Current.Application["Dbfactory"] as IDbConnectionFactory;

            if (_dbfactory == null)
            {
                throw new Exception("Db Connection not found");
            }
        }

        public  Responce GetAllOrder()
        {
            try
            {
                using(IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    var getOrder = db.Select<Order>();
                    if(getOrder.Count==0)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = $"no order available";
                    }
                    else
                    {
                        _objResponce.IsError = false;
                        _objResponce.Message = $"there are {getOrder.Count} available";
                       
                    }
                    
                    _objResponce.Data = getOrder;
                }

                return _objResponce;
            }
            catch(Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"error for get all orders : {ex.Message}";
                return _objResponce;
            }
        }

        public Responce GetOrderById(int id)
        {
            try
            {
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    var orderbyid = db.SingleById<Order>(id);
                    if (orderbyid == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "No order found";
                    }
                    else
                    {
                        _objResponce.IsError = false;
                     
                    }
                    _objResponce.IsError = false;
                    _objResponce.Data = orderbyid;


                }

            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"error for get order by id: {ex.Message}";
            }

            return _objResponce;
        }

       public void PreSave(OrderDto objOrderDto)
        {
            _objOrder = objOrderDto.ConvertTo<Order>();
            
            if (Type == EnumType.E)
            {
                _id = objOrderDto.userId;
            }
            else
            {
                // Handle other cases if needed
                _id = 0;
            }
        }

        public Responce Validation()
        {
            if (Type == EnumType.E)
            {
                // Check if the ID is greater than 0
                if (!(_id > 0))
                {
                    // error handler
                    _objResponce.IsError = true;
                    _objResponce.Message = "ID must be greater than 0";
                    _objResponce.Data = null;  // No data in case of error
                }
                else
                {
                    // obj error handler
                    _objResponce.IsError = false;
                    _objResponce.Message = "Validation successful";
                    _objResponce.Data = new { _id };  // Returning the validated ID as data (or any other data you want)
                }


                return _objResponce;
            }

            return _objResponce;
        }

        public Responce PreValidationOnDelete()
        {
            if (EnumType.D == Type)
            {
                // id must be greater then 0
                if (!(_id > 0))
                {
                    // error handler 
                    _objResponce.IsError = true;
                    _objResponce.Message = "id must be greater then 0";
                }
                
                return _objResponce;

            }

            _objResponce.IsError = false;
            return _objResponce;
        }

        public Responce Delete(int id)
        {
            // Pre-validation check before deletion
            var validateResponce = PreValidationOnDelete();

            // If validation fails, return the response with error message
            if (validateResponce.IsError)
            {
                return validateResponce;
            }

            

            // Proceed with deletion if ID exists
            using (var db = _dbfactory.OpenDbConnection())
            {
                try
                {
                    db.DeleteById<Product>(id);  // Deleting the record by ID
                }
                catch (Exception ex)
                {
                    // error responce for error handler
                    _objResponce.IsError = true;
                    _objResponce.Message = $"Error while deleting product: {ex.Message}";
                    _objResponce.Data = null;
                    return _objResponce;
                }
            }

            // Success response after deletion
            _objResponce.IsError = false;
            _objResponce.Message = "product deleted successfully";
            _objResponce.Data = null;  // No data to return after deletion
            return _objResponce;
        }


        public Responce Save()
        {
            try
            {
                using (var db = _dbfactory.OpenDbConnection())
                {
                    // validate user 
                    var user = db.SingleById<User>(_objOrder.userId);
                    if (user == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "User does not exist.";
                        return _objResponce;
                    }
                    // validate product 
                    var product = db.SingleById<Product>(_objOrder.productId);
                    if(product == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "product does not exist.";
                        return _objResponce;
                    }

                    // product quantity check
                    if(product.productQuantity < _objOrder.qunt)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "Insufficient product quantity.";
                        return _objResponce;
                    }
                    // Calculate total amount
                    decimal totalAmount = product.productPrice * _objOrder.qunt;
                    // add operation condition
                    if (EnumType.A == Type)
                    {
                        // insert 
                        db.Insert(_objOrder);

                        // Update product quantity
                        product.productQuantity -= _objOrder.qunt;
                        db.Update(product);
                        // give responce
                        _objResponce.Message = "data addes";
                        _objResponce.Data = _objOrder;
                    }
                    // edit operation condition
                    if (EnumType.E == Type)
                    {
                        // update method for poco model 
                        db.Update(_objOrder);
                        // return responce object 
                        _objResponce.Message = "data updated";
                        _objResponce.Data = _objOrder;
                    }
                }
            }
            catch (Exception ex)
            {
                // error handler 
                _objResponce.IsError = true;
                _objResponce.Message = $"error for save order: {ex.Message}";
            }
            return _objResponce;
        }

        public Responce CancelOrder(int id)
        {
            // Pre-validation check before cancelling
            var validateResponce = PreValidationOnDelete();

            // If validation fails, return the response with error message
            if (validateResponce.IsError)
            {
                return validateResponce;
            }

            using (var db = _dbfactory.OpenDbConnection())
            {
                try
                {
                    // Fetch the order by ID
                    var order = db.SingleById<Order>(id);

                    // If order doesn't exist, return an error response
                    if (order == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "Order not found.";
                        return _objResponce;
                    }

                    // Update the order status to "Cancelled"
                    order.orderStatus = "Cancelled";
                    db.Update(order);  // Save the changes to the database

                    // Return success response
                    _objResponce.IsError = false;
                    _objResponce.Message = "Order status updated to 'Cancelled'.";
                    _objResponce.Data = order;  // Optionally, return the updated order
                }
                catch (Exception ex)
                {
                    _objResponce.IsError = true;
                    _objResponce.Message = $"Error while updating order status: {ex.Message}";
                }
            }

            return _objResponce;
        }


    }
}