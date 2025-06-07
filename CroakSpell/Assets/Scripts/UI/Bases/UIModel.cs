using UnityEngine;

public abstract class UIModel : MonoBehaviour
{
    [Header("REFERENCES")]
    [SerializeField] private BaseView view;

    protected BaseController controller { get; set; } // Reference to the BaseController associated with this model.

    protected virtual void Start() 
    {
        Initialize();
    }

    protected virtual void Initialize() { }

    protected BaseView GetView() => view; // Returns the BaseView associated with this model.
}
