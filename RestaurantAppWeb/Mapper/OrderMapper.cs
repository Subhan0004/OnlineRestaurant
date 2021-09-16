using Restaurant.Core.Domain.Entities;
using RestaurantAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAppWeb.Mapper
{
    public class OrderMapper : BaseMapper<Order, OrderModel>
    {
        public override Order Map(OrderModel orderModel)
        {
            if (orderModel == null)
                return null;

            CustomerMapper customerMapper = new CustomerMapper();
            CourierMapper courierMapper = new CourierMapper();

            Order order = new Order()
            {
                Id = orderModel.Id,
                Address = orderModel.Address,
                Note = orderModel.Note
            };

            order.Customer = customerMapper.Map(orderModel.Customer);
            order.Courier = courierMapper.Map(orderModel.Courier);

            return order;
        }

        public override OrderModel Map(Order order)
        {
            if (order == null)
                return null;

            CustomerMapper customerMapper = new CustomerMapper();
            CourierMapper courierMapper = new CourierMapper();


            OrderModel orderModel = new OrderModel()
            {
                Id = order.Id,
                Address = order.Address,
                Note = order.Note
            };

            orderModel.Customer = customerMapper.Map(order.Customer);
            orderModel.Courier = courierMapper.Map(order.Courier);
            
            return orderModel;
        }
      
    }
}
