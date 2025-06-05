using UnityEngine;

public class WaterDetector : MonoBehaviour
{
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
