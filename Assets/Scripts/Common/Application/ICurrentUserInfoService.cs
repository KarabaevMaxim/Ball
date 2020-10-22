using System.Threading.Tasks;

namespace Common.Application
{
  public interface ICurrentUserInfoService
  {
    Task RegisterAsync(string name);
  }
}