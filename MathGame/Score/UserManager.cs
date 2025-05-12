using MathGame.Models;

namespace MathGame.Score
{
    internal class UserManager
    {
        private readonly List<User> _users;
        public UserManager()
        {
            _users = new List<User>();
        }
        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}
