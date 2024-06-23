using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    private int Count = 0;

    private void Start()
    {
        UpdateCounterText();
    }

    public void IncrementCount(int points)
    {
        Count += points;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        CounterText.text = "Points: " + Count;
    }
}
