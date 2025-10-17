using TMPro;
using UnityEngine;

public class PlayerAmountCounter : MonoBehaviour
{
    public int PlayerCount = 0;
    public static PlayerAmountCounter Instance;
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
        Debug.Log("player amount = " + PlayerCount);
    }
    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
