namespace Common.ObjectsModel
{
  public interface IDroppingObject
  {
    bool IsDropping { get; }
    
    void StartDrop();
  }
}