using RSSManagmentService.DataAccess.Repository;
using RSSManagmentService.Entities;

namespace RSSManagmentService.BLL
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegistrationAsync(User user)
        {
            var isExist = await _userRepository.IsExistAsync(user.Login);

            if (isExist == true)
            {
                throw new Exception("This login already exists!");
            }
            await _userRepository.AddAsync(user);
        }

        public async Task<User> LoginAsync(User user)
        {
            var response = await _userRepository.GetAsync(user);

            if (response == null)
            {
                throw new Exception("Invalid login or password");
            }
            return response;
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }
    }
}
