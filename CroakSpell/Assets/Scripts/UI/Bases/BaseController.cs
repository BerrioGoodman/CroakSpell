using UnityEngine;
using UnityEngine.UI;

public abstract class BaseController
{
    protected BaseView view { get; private set; } //Reference BaseView

    protected BaseController(BaseView View, bool init)
    {
        view = View;
        if (init)
        {
            Initialize();
        }
    }

    public abstract void Initialize();

    /// Show and Hide methods to control the visibility of the view's main canvas.
    public virtual void Show()
    {
        if (view && view.mainCanvas) 
        {
            ToggleCanvas(view.mainCanvas, true);
        }
    }

    public virtual void Hide()
    {
        if (view && view.mainCanvas)
        {
            ToggleCanvas(view.mainCanvas, true);
        }
    }

    protected void ToggleCanvas(CanvasGroup canvas, bool visible, bool interactable = true, bool blockRaycast = true) 
    {
        if (!canvas) return;

        canvas.alpha = visible ? 1f : 0f;// Set the alpha to 1 if visible, otherwise set it to 0.
        canvas.interactable = interactable && visible;// Set interactable to true if visible, otherwise false.
        canvas.blocksRaycasts = blockRaycast && visible;// Set blocksRaycasts to true if visible, otherwise false.
    }
}
