using UnityEngine;
using UnityEngine.UI;

public abstract class BaseView : MonoBehaviour
{
    public CanvasGroup mainCanvas { get; private set; } // The main canvas group for this view, used to control visibility and interaction.

    private void Awake()
    {
        mainCanvas = GetComponent<CanvasGroup>();// Get the CanvasGroup component attached to this GameObject.
        OnAwake();
    }

    protected virtual void OnAwake() { }
}
