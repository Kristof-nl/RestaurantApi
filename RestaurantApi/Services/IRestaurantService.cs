using RestaurantApi.Models;
using System.Collections.Generic;

namespace RestaurantApi.Services
{
    public interface IRestaurantService
    {
        RestaurantDto GetById(int id);
        IEnumerable<RestaurantDto> GetAll();
        int Create(CreateRestaurantDto dto);
    }
}