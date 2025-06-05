using UnityEngine;

[CreateAssetMenu(fileName = "Enviroment", menuName = "Scriptable Objects/Enviroment")]
public class Enviroment : ScriptableObject
{
    [SerializeField] private float gravity;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float verticalSwimSpeed;

    public float Gravity => gravity;
    public float Speed => speed;
    public float JumpSpeed => jumpSpeed;
    public float VerticalSwimSpeed => verticalSwimSpeed;

}
