﻿using System;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using TestSwitchApi.Models.ApiModels;
using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Repositories
{
    public class AdminRepo : IAdminRepo
    {
        private readonly TestSwitchDbContext _context;

        public AdminRepo(TestSwitchDbContext context)
        {
            _context = context;
        }

        public AdminUserDataModel GetAdminByEmail(string email)
        {
            return _context.AdminUsers.SingleOrDefault(c => c.Email == email);
        }

        public AdminUserSession CreateAndStoreSession(int adminUserId)
        {
            var newSession = new AdminUserSession
                { Id = Guid.NewGuid().ToString(), AdminUserID = adminUserId };
            _context.AdminUserSessions.Add(newSession);
            _context.SaveChanges();
            return _context.AdminUserSessions.SingleOrDefault(s => s.Id == newSession.Id);
        }
    }
}