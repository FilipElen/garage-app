﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Repositories;
using garage_app_entities;

namespace garage_app_bl.Services
{
    public class AuthService
    {
        private UserRepository _userRepository;

        public AuthService()
        {
            _userRepository = new UserRepository(new MyDbContext());
        }

        public bool ValidateUser(string userName, string password)
        {
            try
            {
                User user = _userRepository.FindUserByUserName(userName);
                if (user.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}