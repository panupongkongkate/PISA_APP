using PISA_APP.Models;

namespace PISA_APP.Services
{
    public class AuthenticationService
    {
        private User? _currentUser;
        private readonly MockDataService _mockDataService;

        public AuthenticationService(MockDataService mockDataService)
        {
            _mockDataService = mockDataService;
        }

        public User? CurrentUser => _currentUser;
        public bool IsAuthenticated => _currentUser != null;

        public event Action? AuthenticationStateChanged;

        public async Task<bool> LoginAsync(string username, string password)
        {
            var user = _mockDataService.GetAllUsers()
                .FirstOrDefault(u => u.Username == username && u.Password == password && u.IsActive);

            if (user != null)
            {
                _currentUser = user;
                AuthenticationStateChanged?.Invoke();
                return true;
            }

            return false;
        }

        public async Task LogoutAsync()
        {
            _currentUser = null;
            AuthenticationStateChanged?.Invoke();
            await Task.CompletedTask; // Make it truly async
        }

        public bool HasRole(UserRole role)
        {
            return _currentUser?.Role == role;
        }

        public bool IsAdmin()
        {
            return _currentUser?.Role == UserRole.Admin;
        }

        public bool IsTeacher()
        {
            return _currentUser?.Role == UserRole.Teacher;
        }

        public bool IsStudent()
        {
            return _currentUser?.Role == UserRole.Student;
        }
    }
}