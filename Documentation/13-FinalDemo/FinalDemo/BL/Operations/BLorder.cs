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
    /// <summary>
    /// business logic for order 
    /// </summary>
    public class BLorder : IDataHandler<DTOORD01>
    {

        //order poco
        private ORD01 _objOrder;

        // user poco
        private BLuser _objUser;

        // product poco
        private BLproduct _objProduct;

        // response
        private Responce _objResponce;

        // data base 
        private IDbConnectionFactory _dbfactory;
        int _id;
        private EnmRoleType roleType;
        public EnumType Type { get; set; }


        /// <summary>
        /// ctor 
        /// </summary>
        /// <exception cref="Exception"></exception>
        public BLorder()
        {
            _objOrder = new ORD01();
            _objResponce = new Responce();
            _objUser = new BLuser();
            _objProduct = new BLproduct();
            _dbfactory = HttpContext.Current.Application["Dbfactory"] as IDbConnectionFactory;

            if (_dbfactory == null)
            {
                throw new Exception("Db Connection not found");
            }
        }

        /// <summary>
        /// get all orders
        /// </summary>
        /// <param name="status"></param>
        /// <returns>list of orders</returns>
        public  Responce GetAllOrder(string status)
        {
            try
            {
                // open database
                using(IDbConnection db = _dbfactory.OpenDbConnection())
                {
                 // order list   
                    List<ORD01> getOrder = db.Select<ORD01>(o=>o.D01F06 == status);
                    if(getOrder.Count==0)
                    {
                        // not order available
                        _objResponce.IsError = true;
                        _objResponce.Message = $"no order available";
                    }
                    else
                    {
                        _objResponce.IsError = false;
                        _objResponce.Message = $"there are {getOrder.Count} {status} order available";
                       
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

        /// <summary>
        /// get user profile
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Responce GetProfile(int userId)
        {
            try
            {
                // open database
                using (var db = _dbfactory.OpenDbConnection())
                {
                    // get specific profile
                    List<ORD01> result = db.Select<ORD01>(u => u.R01F01 == userId).ToList();

                    _objResponce.IsError = false;
                    _objResponce.Data = result;
                    _objResponce.Message = "your order  get successfully";
                }
            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = ex.Message;
            }
            return _objResponce;
        }

        /// <summary>
        /// order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Responce GetOrderById(int id)
        {
            try
            {
                // open database
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    // single id
                    var orderbyid = db.SingleById<ORD01>(id);
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

        /// <summary>
        /// pre save method
        /// </summary>
        /// <param name="objOrderDto"></param>
       public void PreSave(DTOORD01 objOrderDto)
        {
            // convert dto to poco
            _objOrder = objOrderDto.ConvertTo<ORD01>();
            
            // edit
            if (Type == EnumType.E)
            {
                _id = objOrderDto.T01F01;
            }
            else
            {
                // it is for other case
                _id = 0;
            }
        }

        /// <summary>
        /// validation method
        /// </summary>
        /// <returns></returns>
        public Responce Validation()
        {
            //edit
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

        /// <summary>
        /// validation on cancel order
        /// </summary>
        /// <returns></returns>
        public Responce PreValidationOnCancelOrder()
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


        /// <summary>
        /// save mthod
        /// </summary>
        /// <returns></returns>
        //// doubt
        public Responce Save()
        {
            try
            {
                // open database
                using (var db = _dbfactory.OpenDbConnection())
                {
                    // Validate user
                    var user = db.SingleById<USR01>(_objOrder.R01F01);
                    if (user == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "User does not exist.";
                        return _objResponce;
                    }

                    // Validate product
                    var product = db.SingleById<PDT01>(_objOrder.T01F01);

                    // testing purpose
                    Console.WriteLine($"Order Product ID: {_objOrder.T01F01}");

                    if (product == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "product does not exist.";
                        return _objResponce;
                    }

                    // Product quantity check
                    if (product.T01F05 < _objOrder.D01F04)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "Insufficient product quantity..";
                        return _objResponce;
                    }

                    // Calculate total amount
                    decimal totalAmount = product.T01F06 * _objOrder.D01F04;
                    _objOrder.D01F05 = totalAmount;
                    // Perform operation based on Type
                    if (Type == EnumType.A)
                    {
                        // Check if updating the product quantity will make it negative
                        if (product.T01F05 - _objOrder.D01F04 < 0)
                        {
                            _objResponce.IsError = true;
                            _objResponce.Message = "Insufficient stock. Please check the product quantity before ordering.";
                            return _objResponce;
                        }
                        // Insert new order
                        db.Insert(_objOrder);

                        // Update product quantity
                        product.T01F05 -= _objOrder.D01F04;
                        db.Update(product);

                        //return new Responce
                        //{
                        //    IsError = false,
                        //    Message = "Order added successfully.",
                        //    Data = _objOrder
                        //};


                        _objResponce.IsError = false;
                        _objResponce.Message = "order add success fully";
                        return _objResponce;
                    }
                    else if (Type == EnumType.E)
                    {
                        // Update existing order
                        db.Update(_objOrder);

                        _objResponce.IsError = false;
                        _objResponce.Message = "order update success fully";
                        return _objResponce;
                    }
                    else
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "invalid operations";
                        return _objResponce;
                    }
                }
            }
            catch (Exception ex)
            {
                return new Responce
                {
                    IsError = true,
                    Message = $"Error while saving order: {ex.Message}"
                };
            }
        }


        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Responce CancelOrder(int id)
        {
            // Pre-validation check before cancelling
            var validateResponce = PreValidationOnCancelOrder();

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
                    var order = db.SingleById<ORD01>(id);

                    // If order doesn't exist, return an error response
                    if (order == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "Order not found.";
                        return _objResponce;
                    }

                    // Fetch the product related to the order
                    var product = db.SingleById<PDT01>(order.T01F01);

                    // If product doesn't exist, return an error response
                    if (product == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "Product not found for the order.";
                        return _objResponce;
                    }

                    // Update the product quantity by adding the cancelled order quantity
                    product.T01F05 += order.D01F04;
                    db.Update(product);  // Save the updated product details

                    // Update the order status to "Cancelled"
                    order.D01F06 = "Cancelled";
                    db.Update(order);  // Save the changes to the order

                    // Return success response
                    _objResponce.IsError = false;
                    _objResponce.Message = "your order has been cancelled";
                    _objResponce.Data = new
                    {
                        Order = order,
                        UpdatedProduct = product
                    };  // Optionally, return the updated order and product details
                }
                catch (Exception ex)
                {
                    _objResponce.IsError = true;
                    _objResponce.Message = $"Error while updating order status: {ex.Message}";
                }
            }

            return _objResponce;
        }

        /// <summary>
        /// change status
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        public Responce ChangeStatus(int orderId, string newStatus)
        {
            try
            {
                // open database
                using (var db = _dbfactory.OpenDbConnection())
                {
                    // Validate the order
                    var order = db.SingleById<ORD01>(orderId);
                    if (order == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "Order not found.";
                        return _objResponce;
                    }

                    // Check if the order's status is already 'Success'
                    if (order.D01F06 == "success" || order.D01F06 == "cancelled")
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "Order status is already success or cancelled  Status cannot be changed.";
                        return _objResponce;
                    }

                    // Update the order status
                    order.D01F06 = newStatus;
                    db.Update(order);

                    _objResponce.IsError = false;
                    _objResponce.Message = "Order status updated successfully.";
                    return _objResponce;
                }
            }
            catch (Exception ex)
            {
                return new Responce
                {
                    IsError = true,
                    Message = $"Error while updating order status: {ex.Message}"
                };
            }
        }



    }
}