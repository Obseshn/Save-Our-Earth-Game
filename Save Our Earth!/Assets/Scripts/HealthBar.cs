using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private Transform target;
    private Vector3 offset = new Vector3(0, 8, 0);
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        SetHealth(health);
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    private void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
       
    }
}
