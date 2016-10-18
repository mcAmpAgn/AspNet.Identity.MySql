using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using SYM.DataAccessLayer;

namespace MySql.AspNet.Identity.Repositories
{
    public class UserRepository<TUser> where TUser : IdentityUser
    {
        //private readonly string _connectionString;
        private Entities _context = new Entities();

        public UserRepository()
        {
        }

        public void Insert(TUser user)
        {
            aspnetusers obj = new aspnetusers();
            obj.Id = user.Id;
            obj.Email = user.Email;
            obj.EmailConfirmed = user.EmailConfirmed;
            obj.PasswordHash = user.PasswordHash;
            obj.SecurityStamp = user.SecurityStamp;
            obj.PhoneNumber = user.PhoneNumber;
            obj.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            obj.TwoFactorEnabled = user.TwoFactorAuthEnabled;
            obj.LockoutEndDateUtc = user.LockoutEndDate;
            obj.LockoutEnabled = user.LockoutEnabled;
            obj.AccessFailedCount = user.AccessFailedCount;
            obj.UserName = user.UserName;

            _context.aspnetusers.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(TUser user)
        {
            aspnetusers obj = _context.aspnetusers.Find(user.Id);
            _context.aspnetusers.Remove(obj);
            _context.SaveChanges();
        }

        public IQueryable<TUser> GetAll()
        {
            List<TUser> users = new List<TUser>();

            List<aspnetusers> list = _context.aspnetusers.ToList();

            foreach (aspnetusers obj in list)
            {
                var user = (TUser)Activator.CreateInstance(typeof(TUser));
                user.Id = obj.Id;
                user.Email = obj.Email;
                user.EmailConfirmed = obj.EmailConfirmed;
                user.PasswordHash = obj.PasswordHash;
                user.SecurityStamp = obj.SecurityStamp;
                user.PhoneNumber = obj.PhoneNumber;
                user.PhoneNumberConfirmed = obj.PhoneNumberConfirmed;
                user.TwoFactorAuthEnabled = obj.TwoFactorEnabled;
                user.LockoutEndDate = obj.LockoutEndDateUtc;
                user.LockoutEnabled = obj.LockoutEnabled;
                user.AccessFailedCount = obj.AccessFailedCount;
                user.UserName = obj.UserName;
                users.Add(user);
            }

            return users.AsQueryable<TUser>();
        }
        
        public TUser GetById(string userId)
        {
            aspnetusers obj = _context.aspnetusers.Find(userId);
            var user = (TUser)Activator.CreateInstance(typeof(TUser));
            user.Id = obj.Id;
            user.Email = obj.Email;
            user.EmailConfirmed = obj.EmailConfirmed;
            user.PasswordHash = obj.PasswordHash;
            user.SecurityStamp = obj.SecurityStamp;
            user.PhoneNumber = obj.PhoneNumber;
            user.PhoneNumberConfirmed = obj.PhoneNumberConfirmed;
            user.TwoFactorAuthEnabled = obj.TwoFactorEnabled;
            user.LockoutEndDate = obj.LockoutEndDateUtc;
            user.LockoutEnabled = obj.LockoutEnabled;
            user.AccessFailedCount = obj.AccessFailedCount;
            user.UserName = obj.UserName;
            return user;
        }

        public TUser GetByName(string userName)
        {
            aspnetusers obj = _context.aspnetusers.Where(a => a.UserName == userName).FirstOrDefault(); ;
            var user = (TUser)Activator.CreateInstance(typeof(TUser));

            if (obj != null) { 
                user.Id = obj.Id;
                user.Email = obj.Email;
                user.EmailConfirmed = obj.EmailConfirmed;
                user.PasswordHash = obj.PasswordHash;
                user.SecurityStamp = obj.SecurityStamp;
                user.PhoneNumber = obj.PhoneNumber;
                user.PhoneNumberConfirmed = obj.PhoneNumberConfirmed;
                user.TwoFactorAuthEnabled = obj.TwoFactorEnabled;
                user.LockoutEndDate = obj.LockoutEndDateUtc;
                user.LockoutEnabled = obj.LockoutEnabled;
                user.AccessFailedCount = obj.AccessFailedCount;
                user.UserName = obj.UserName;
            }

            return user;
        }

        public TUser GetByEmail(string email)
        {
            aspnetusers obj = _context.aspnetusers.Where(a => a.Email == email).FirstOrDefault();
            var user = (TUser)Activator.CreateInstance(typeof(TUser));
            if (obj != null)
            {
                user.Id = obj.Id;
                user.Email = obj.Email;
                user.EmailConfirmed = obj.EmailConfirmed;
                user.PasswordHash = obj.PasswordHash;
                user.SecurityStamp = obj.SecurityStamp;
                user.PhoneNumber = obj.PhoneNumber;
                user.PhoneNumberConfirmed = obj.PhoneNumberConfirmed;
                user.TwoFactorAuthEnabled = obj.TwoFactorEnabled;
                user.LockoutEndDate = obj.LockoutEndDateUtc;
                user.LockoutEnabled = obj.LockoutEnabled;
                user.AccessFailedCount = obj.AccessFailedCount;
                user.UserName = obj.UserName;
            }
            return user;
        }

        public void Update(TUser user)
        {
            //In previous version the code allow to change the primary key ID. I have remove this possibility.
            aspnetusers obj = _context.aspnetusers.Find(user.Id);

            obj.Email = user.Email;
            obj.EmailConfirmed = user.EmailConfirmed;
            obj.PasswordHash = user.PasswordHash;
            obj.SecurityStamp = user.SecurityStamp;
            obj.PhoneNumber = user.PhoneNumber;
            obj.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            obj.TwoFactorEnabled = user.TwoFactorAuthEnabled;
            obj.LockoutEndDateUtc = user.LockoutEndDate;
            obj.LockoutEnabled = user.LockoutEnabled;
            obj.AccessFailedCount = user.AccessFailedCount;
            obj.UserName = user.UserName;
            _context.SaveChanges();
        }
    }
}
