using System.Threading.Tasks;

namespace Common.Application
{
  public interface ICurrentUserInfoService
  {
    User CurrentUser { get; }
    
    Task RegisterAsync(string name);

    Task SaveResultAsync(int newResult);
  }
}