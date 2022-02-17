﻿using CarShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        private readonly CarShopDbContext data;

        public UserService(CarShopDbContext data)
        {
            this.data = data;
        }

        public bool IsMechanic(string userId)
            => this.data
                .Users
                .Any(u => u.Id == userId && u.IsMechanic);

        public bool OwnsCar(string userId, string carId)
            => this.data
                .Cars
                .Any(c => c.Id == carId && c.OwnerId == userId);
    }
}
