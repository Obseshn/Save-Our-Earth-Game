using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text hPTExt;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        SetHealth(health);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        hPTExt.text = health.ToString();
    }
}
