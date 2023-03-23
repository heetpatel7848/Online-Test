namespace OnlineTest.Models.Interfaces
{
    public interface IUserRoleRepository
    {
        List<string> GetRoles(int userId);
        bool AddRole(UserRole role);
    }
}