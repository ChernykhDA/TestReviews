using Microsoft.EntityFrameworkCore;
using Review.Database;
using Reviews.Shared;
using Reviews.Shared.Services;
using System.Security.Cryptography;
using TestReviews.Common;

namespace TestReviews.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;

        public UserService()
        {
            _context = new ApplicationContext();
        }

        public async Task<User> GetUserByAccessTokenAsync(string accessToken)
        {
            var utoken = _context.UTokens.Include(u => u.User)
                                         .Include(u => u.User.Role)
                                         .Where(u => u.Token == accessToken).FirstOrDefault();

            return await Task.FromResult(utoken?.User);
        }

        public async Task<(User, string)> LoginAsync(User _user)
        {
            //Берем 
            _user.Password = Utility.Encrypt(_user.Password);
            //
            var user = await _context.Users.Include(u => u.Role)
                                            .Where(u => u.Login == _user.Login
                                                && u.Password == _user.Password)
                                            .FirstOrDefaultAsync();

            UToken Token = GenerateToken();

            if (user != null)
            {
                
                Token.UserId = user.Id;
                _context.UTokens.Add(Token);
                await _context.SaveChangesAsync();
            }

            return await Task.FromResult((user, Token.Token));
        }

        public Task<User> RegisterUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        private UToken GenerateToken()
        {
            UToken Token = new UToken();

            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                Token.Token = Convert.ToBase64String(randomNumber);
            }
            Token.ExpiryDate = DateTime.UtcNow.AddMonths(6);

            return Token;
        }
    }
}
