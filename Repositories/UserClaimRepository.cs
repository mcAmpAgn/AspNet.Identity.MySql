using System.Collections.Generic;
using System.Security.Claims;
using SYM.DataAccessLayer;

namespace MySql.AspNet.Identity.Repositories
{
    public class UserClaimRepository<TUser>  where TUser : IdentityUser
    {
        //private readonly string _connectionString;
        private Entities _context = new Entities();

        public UserClaimRepository()
        {
        }

        public void Insert(TUser user, Claim claim)
        {

            aspnetuserclaims obj = new aspnetuserclaims();
            obj.UserId = user.Id;
            obj.ClaimType = claim.Type;
            obj.ClaimValue = claim.Value;

            _context.aspnetuserclaims.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(TUser user, Claim claim)
        {
            //using (var conn = new MySqlConnection(_connectionString))
            //{
            //    var parameters = new Dictionary<string, object>
            //    {
            //        {"@UserId", user.Id},
            //        {"@ClaimType", claim.Type},
            //        {"@ClaimValue", claim.Value}
            //    };

            //    MySqlHelper.ExecuteNonQuery(conn,
            //        @"DELETE FROM aspnetuserclaims WHERE UserId=@UserId AND ClaimType=@ClaimType AND ClaimValue=@ClaimValue", parameters);
            //}

            //aspnetuserclaims obj = _context.aspnetuserclaims.Where(a => UserId = user.Id).;

            //_context.aspnetuserclaims.Remove(obj);
            //_context.SaveChanges();
        }

        public List<IdentityUserClaim> PopulateClaims(string userId)
        {
            var claims = new List<IdentityUserClaim>();

            //using (var conn = new MySqlConnection(_connectionString))
            //{
            //    var parameters = new Dictionary<string, object>
            //    {
            //        {"@Id", userId}
            //    };

            //    var reader = MySqlHelper.ExecuteReader(conn, CommandType.Text,
            //        @"SELECT ClaimType,ClaimValue FROM aspnetuserclaims WHERE UserId=@Id", parameters);
            //    while (reader.Read())
            //    {
            //        claims.Add(new IdentityUserClaim() { ClaimType = reader[0].ToString(), ClaimValue = reader[1].ToString() });
            //    }

            //}
            return claims;
        }
    }
}
