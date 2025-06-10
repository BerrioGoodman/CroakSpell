using UnityEngine;
using UnityEngine.UI;

public class ManaBarView : MonoBehaviour
{
    [SerializeField] private Slider manaSlider;

    public void UpdateManaBar(float current, float max) 
    {
        if (manaSlider != null) 
        {
            manaSlider.maxValue = max;
            manaSlider.value = current;
        }
    }
}
