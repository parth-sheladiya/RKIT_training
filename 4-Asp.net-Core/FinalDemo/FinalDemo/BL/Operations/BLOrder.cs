using FinalDemo.BL.Interface;
using FinalDemo.Extention;
using FinalDemo.Models;
using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using FinalDemo.Models.POCO;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.Web;
using System.Data;

namespace FinalDemo.BL.Operations
{
    public class BLOrder : ICommonHandler<DTOORD01>
    {
        private readonly IDbConnectionFactory _dbfactory;
        private Response _objResponse;
        public int _id;
        private ORD01 _objORD01;
        public EnumType typeOfOperation { get; set; }
        public EnumRole typeOfRole { get; set; }

        public BLOrder(IDbConnectionFactory dbfactory, Response objResponse,ORD01 objORD01)
        {
            _dbfactory = dbfactory;
            _objResponse = objResponse;
            _objORD01 = objORD01;
        }

        public Response GetAll()
        {
            using (IDbConnection db = _dbfactory.OpenDbConnection())
            {
                // select list of user data
                List<ORD01> res = db.Select<ORD01>().ToList();

                // if no product found
                if (res.Count == 0)
                {
                    _objResponse.Data = null;
                    _objResponse.IsError = true;
                    _objResponse.Message = "No order found";
                }
                // if user found
                else
                {

                    // success responce 
                    _objResponse.Message = $"there are {res.Count} orders available";

                }

                return _objResponse;
            }
        }

        public Response GetByid(int id)
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                _objORD01 = db.SingleById<ORD01>(id);
            }

            if (_objORD01 != null)
            {
                _objResponse.Data = _objORD01;
                _objResponse.IsError = false;
                _objResponse.Message = "Order id fetch successfully";
            }
            else
            {
                _objResponse.IsError = true;
                _objResponse.Message = "order id not found";

            }

            return _objResponse;

        }
        public void PreSave(DTOORD01 objDTOOrder)
        {
            _objORD01 = objDTOOrder.Convert<ORD01>();

            // edit 
            if (typeOfOperation == EnumType.U)
            {
                _id = objDTOOrder.T01F01;
            }
        }
        public bool IsORDExist(int id)
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                return db.Exists<ORD01>(id);
            }
        }
        public Response Validation()
        {
            if (typeOfOperation == EnumType.U)
            {
                if (!(_id > 0))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Enter Correct Id";
                }
                else if (!IsORDExist(_id))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Order Not Found";
                }
            }

            return _objResponse;
        }
        public Response Save()
        {
            try
            {
                // open database
                using (var db = _dbfactory.OpenDbConnection())
                {
                    // Validate user
                    var user = db.SingleById<USR01>(_objORD01.R01F01);
                    if (user == null)
                    {
                        _objResponse.IsError = true;
                        _objResponse.Message = "User does not exist.";
                        return _objResponse;
                    }

                    // Validate product
                    var product = db.SingleById<PDT01>(_objORD01.T01F01);

                    // testing purpose
                    Console.WriteLine($"Order Product ID: {_objORD01.T01F01}");

                    if (product == null)
                    {
                        _objResponse.IsError = true;
                        _objResponse.Message = "product does not exist.";
                        return _objResponse;
                    }

                    //// Product quantity check
                    if (product.T01F05 < _objORD01.D01F04)
                    {
                        _objResponse.IsError = true;
                        _objResponse.Message = "Insufficient product quantity..";
                        return _objResponse;
                    }

                    // Calculate total amount
                    decimal totalAmount = product.T01F06 * _objORD01.D01F04;
                    _objORD01.D01F05 = totalAmount;
                    // Perform operation based on Type
                    if (typeOfOperation == EnumType.A)
                    {
                        // Check if updating the product quantity will make it negative
                        if (product.T01F05 - _objORD01.D01F04 < 0)
                        {
                            _objResponse.IsError = true;
                            _objResponse.Message = "Insufficient stock. Please check the product quantity before ordering.";
                            return _objResponse;
                        }
                        // Insert new order
                        db.Insert(_objORD01);

                        // Update product quantity
                        product.T01F05 -= _objORD01.D01F04;
                        db.Update(product);


                        _objResponse.IsError = false;
                        _objResponse.Message = "order add success fully";
                        return _objResponse;
                    }
                    else if (typeOfOperation == EnumType.U)
                    {
                        // Update existing order
                        db.Update(_objORD01);

                        _objResponse.IsError = false;
                        _objResponse.Message = "order update success fully";
                        return _objResponse;
                    }
                    else
                    {
                        _objResponse.IsError = true;
                        _objResponse.Message = "invalid operations";
                        return _objResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response
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
        public Response CancelOrder(int id)
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                try
                {
                    // Fetch the order by ID
                    var order = db.SingleById<ORD01>(id);

                    // If order doesn't exist, return an error response
                    if (order == null)
                    {
                        _objResponse.IsError = true;
                        _objResponse.Message = "Order not found.";
                        return _objResponse;
                    }

                    // Check if the order is already cancelled
                    if (order.D01F06 == "cancelled")
                    {
                        _objResponse.IsError = true;
                        _objResponse.Message = "Order is already cancelled.";
                        return _objResponse;
                    }

                    if (order.D01F06 == "success")
                    {
                        _objResponse.IsError = true;
                        _objResponse.Message = "order is success sorry do not change status";
                        return _objResponse;
                    }

                    // Fetch the product related to the order
                    var product = db.SingleById<PDT01>(order.T01F01);

                    // If product doesn't exist, return an error response
                    if (product == null)
                    {
                        _objResponse.IsError = true;
                        _objResponse.Message = "Product not found for the order.";
                        return _objResponse;
                    }

                    // Update the product quantity by adding the cancelled order quantity
                    product.T01F05 += order.D01F04;
                    db.Update(product);  // Save the updated product details

                    // Update the order status to "Cancelled"
                    order.D01F06 = "cancelled";
                    db.Update(order);  // Save the changes to the order

                    // Return success response
                    _objResponse.IsError = false;
                    _objResponse.Message = "Your order has been cancelled.";
                }
                catch (Exception ex)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = $"Error while updating order status: {ex.Message}";
                }
            }

            return _objResponse;
        }


        /// <summary>
        /// change status
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        public Response ChangeStatus(int orderId, string newStatus)
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
                        _objResponse.IsError = true;
                        _objResponse.Message = "Order not found.";
                        return _objResponse;
                    }

                    // Check if the order's status is already 'Success'
                    if (order.D01F06 == "success" || order.D01F06 == "cancelled")
                    {
                        _objResponse.IsError = true;
                        _objResponse.Message = "Order status is already success or cancelled  Status cannot be changed.";
                        return _objResponse;
                    }

                    // Update the order status
                    order.D01F06 = newStatus;
                    db.Update(order);

                    _objResponse.IsError = false;
                    _objResponse.Message = "Order status updated successfully.";
                    return _objResponse;
                }
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsError = true,
                    Message = $"Error while updating order status: {ex.Message}"
                };
            }
        }




    }
}
