using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SYM.DataAccessLayer;

namespace MySql.AspNet.Identity.Repositories
{
    public class RoleRepository<TRole> where TRole: IdentityRole
    {
        private Entities _context = new Entities();

        public RoleRepository()
        {        
        }

        public IQueryable<TRole> GetRoles()
        {
            var roles = new List<TRole>();

            List<aspnetroles> list = _context.aspnetroles.ToList();

            foreach (aspnetroles obj in list)
            {
                var role = (TRole)Activator.CreateInstance(typeof(TRole));
                role.Id = obj.Id;
                role.Name = obj.Name;
                roles.Add(role);
            }

            return roles.AsQueryable();
        }

        public void Insert(IdentityRole role)
        {

            aspnetroles obj = new aspnetroles();
            obj.Id = role.Id;
            obj.Name = role.Name;

            _context.aspnetroles.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(string roleId)
        {
            aspnetroles obj = _context.aspnetroles.Find(roleId);
            _context.aspnetroles.Remove(obj);
            _context.SaveChanges();
        }

        public IdentityRole GetRoleById(string roleId)
        {
            aspnetroles obj = _context.aspnetroles.Find(roleId);
            IdentityRole role = null;

            if (obj != null)
            {
                role = new IdentityRole(obj.Name, obj.Id);
            }
            return role;

        }

        private string GetRoleName(string roleId)
        {
            aspnetroles obj = _context.aspnetroles.Find(roleId);

            if (obj != null)
                return obj.Name;
            else
                return null;
        }

        public IdentityRole GetRoleByName(string roleName)
        {
            aspnetroles obj = _context.aspnetroles.Where(a => a.Name == roleName).First();
            IdentityRole role = null;

            if (obj != null)
            {
                role = new IdentityRole(obj.Name, obj.Id);
            }

            return role;
        }

        private string GetRoleId(string roleName)
        {
            aspnetroles obj = _context.aspnetroles.Where(a => a.Name == roleName).First();
            if (obj != null)
                return obj.Id;
            else
                return null;
        }

        public void Update(IdentityRole role)
        {
            aspnetroles obj = _context.aspnetroles.Find(role.Id);
            obj.Name = role.Name;
            _context.SaveChanges();
        }


    }
}
