using UnityEngine;
using UnityEngine.UI;

namespace Application.UI
{
  public class LeaderboardRow : MonoBehaviour
  {
    [SerializeField]
    private Text _number = default;
    
    [SerializeField]
    private Text _name = default;
    
    [SerializeField]
    private Text _bestResult = default;

    public void Initialize(string number, string playerName, string bestResult)
    {
      _number.text = number;
      _name.text = playerName;
      _bestResult.text = bestResult;
    }
  }
}