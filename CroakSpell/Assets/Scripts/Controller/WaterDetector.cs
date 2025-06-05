using UnityEngine;

public class WaterDetector : MonoBehaviour
{
    //Using tags and triggers, wue detect if we're in the water or not
    [SerializeField] private PlayerController control;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water")) control.SetInWater(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water")) control.SetInWater(false);
    }
}
