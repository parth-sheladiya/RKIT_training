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

        public  Responce GetAllOrder(string status)
        {
            try
            {
                using(IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    var getOrder = db.Select<Order>(o=>o.orderStatus==status);
                    if(getOrder.Count==0)
                    {
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
        public Responce GetProfile(int userId)
        {
            try
            {
                using (var db = _dbfactory.OpenDbConnection())
                {
                    var result = db.Select<Order>(u => u.userId == userId).ToList();

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

        //public Responce Delete(int id)
        //{
        //    // Pre-validation check before deletion
        //    var validateResponce = PreValidationOnDelete();

        //    // If validation fails, return the response with error message
        //    if (validateResponce.IsError)
        //    {
        //        return validateResponce;
        //    }

            

        //    // Proceed with deletion if ID exists
        //    using (var db = _dbfactory.OpenDbConnection())
        //    {
        //        try
        //        {
        //            db.DeleteById<Product>(id);  // Deleting the record by ID
        //        }
        //        catch (Exception ex)
        //        {
        //            // error responce for error handler
        //            _objResponce.IsError = true;
        //            _objResponce.Message = $"Error while deleting product: {ex.Message}";
        //            _objResponce.Data = null;
        //            return _objResponce;
        //        }
        //    }

        //    // Success response after deletion
        //    _objResponce.IsError = false;
        //    _objResponce.Message = "product deleted successfully";
        //    _objResponce.Data = null;  // No data to return after deletion
        //    return _objResponce;
        //}


        public Responce Save()
        {
            try
            {
                using (var db = _dbfactory.OpenDbConnection())
                {
                    // Validate user
                    var user = db.SingleById<User>(_objOrder.userId);
                    if (user == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "User does not exist.";
                        return _objResponce;
                    }

                    // Validate product
                    var product = db.SingleById<Product>(_objOrder.productId);
                    if (product == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "product does not exist.";
                        return _objResponce;
                    }

                    // Product quantity check
                    if (product.productQuantity < _objOrder.qunt)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "Insufficient product quantity..";
                        return _objResponce;
                    }

                    // Calculate total amount
                    decimal totalAmount = product.productPrice * _objOrder.qunt;
                    _objOrder.totalAmount = totalAmount;
                    // Perform operation based on Type
                    if (Type == EnumType.A)
                    {
                        // Check if updating the product quantity will make it negative
                        if (product.productQuantity - _objOrder.qunt < 0)
                        {
                            _objResponce.IsError = true;
                            _objResponce.Message = "Insufficient stock. Please check the product quantity before ordering.";
                            return _objResponce;
                        }
                        // Insert new order
                        db.Insert(_objOrder);

                        // Update product quantity
                        product.productQuantity -= _objOrder.qunt;
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
                    var order = db.SingleById<Order>(id);

                    // If order doesn't exist, return an error response
                    if (order == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "Order not found.";
                        return _objResponce;
                    }

                    // Fetch the product related to the order
                    var product = db.SingleById<Product>(order.productId);

                    // If product doesn't exist, return an error response
                    if (product == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "Product not found for the order.";
                        return _objResponce;
                    }

                    // Update the product quantity by adding the cancelled order quantity
                    product.productQuantity += order.qunt;
                    db.Update(product);  // Save the updated product details

                    // Update the order status to "Cancelled"
                    order.orderStatus = "Cancelled";
                    db.Update(order);  // Save the changes to the order

                    // Return success response
                    _objResponce.IsError = false;
                    _objResponce.Message = "Order status updated to 'Cancelled', and product quantity updated.";
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

        public Responce ChangeStatus(int orderId, string newStatus)
        {
            try
            {
                using (var db = _dbfactory.OpenDbConnection())
                {
                    // Validate the order
                    var order = db.SingleById<Order>(orderId);
                    if (order == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "Order not found.";
                        return _objResponce;
                    }

                    // Check if the order's status is already 'Success'
                    if (order.orderStatus == "success" || order.orderStatus == "cancelled")
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "Order status is already success or cancelled. Status cannot be changed.";
                        return _objResponce;
                    }

                    // Update the order status
                    order.orderStatus = newStatus;
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