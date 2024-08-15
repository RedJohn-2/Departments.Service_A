using Microsoft.AspNetCore.Identity;

namespace Departments.Service_A
{
    public interface IKeyHasher
    {
        string Hash(string key);

        bool Verify(string key, string hash);
    }
}
