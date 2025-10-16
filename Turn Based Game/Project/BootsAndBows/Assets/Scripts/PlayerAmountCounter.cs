using TMPro;
using UnityEngine;

public class PlayerAmountCounter : MonoBehaviour
{
    public int PlayerCount;
    public TextMeshProUGUI countText;
    public void CountUp()
    {
        PlayerCount++;
    }

    public void CountDown()
    {
        PlayerCount--;
    }

    public void Update()
    {
        if (PlayerCount <= 0)
        {
            PlayerCount = 0;
        }
        if (countText != null)
        {
            countText.text = PlayerCount.ToString();
        }
    }
}
