using Restaurant.Core.Domain.Entities;
using RestaurantAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAppWeb.Mapper
{
    public class CourierMapper : BaseMapper<Courier, CourierModel>
    {
        public override Courier Map(CourierModel courierModel)
        {
            if (courierModel == null)
                return null;

            Courier courier = new Courier();

            courier.Name = courierModel.Name;
            courier.Surname = courierModel.Surname;
            courier.Phone = courierModel.Phone;
            courier.Note = courierModel.Note;
            courier.Id = courierModel.Id;

            return courier;
        }

        public override CourierModel Map(Courier courier)
        {
            if (courier == null)
                return null;
            CourierModel courierModel = new CourierModel();

            courierModel.Id = courier.Id;
            courierModel.Name = courier.Name;
            courierModel.Surname = courier.Surname;
            courierModel.Phone = courier.Phone;
            courierModel.Note = courier.Note;

            return courierModel;

        }
    }
}
