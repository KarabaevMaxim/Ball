using Common.Signals;

namespace Common
{
  public interface IStairsObject
  {
    int Height { get; }

    int Length { get; }
    
    YZ[] StairsCoords { get; }
  }
}