using UnityEngine;
using UnityEngine.UI;

public class UltBar : MonoBehaviour
{
    public Slider Slider;

    public void SetUlt(float ult)
    {
        Slider.value = ult;
    }

    public void SetMaxUlt(float maxUlt)
    {
        Slider.maxValue = maxUlt;
        Slider.value = 50f;
    }
}
