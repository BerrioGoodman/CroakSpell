using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;
    private float speed;
    private Vector3 direction;
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    //Call from Magic attack
    public void Initialize(float dmg, float spd, Vector3 dir)
    {
        damage = dmg;
        speed = spd;
        direction = dir.normalized;
        Destroy(gameObject, 10);//Self destruction
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DummyHealth dummy))
        {
            dummy.TakeDamage(damage);//Make damage to the dummy
            Destroy(gameObject);//Destroy prefab at the impact
        }
    }
}
