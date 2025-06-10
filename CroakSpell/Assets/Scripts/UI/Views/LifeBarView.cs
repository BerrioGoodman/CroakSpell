using UnityEngine;
using UnityEngine.UI;

public class LifeBarView : MonoBehaviour
{
   [SerializeField] private Slider lifeSlider;
   //[SerializeField] private Text lifeText;

    public void UpdateLifeBar(float current, float max)
    {
        if (lifeSlider != null) 
        {
            lifeSlider.maxValue = max;
            lifeSlider.value = current;
        }

        /*if (lifeText != null) 
        {
            lifeText.text = $"{current}/{max}";
        }*/
    }
}
