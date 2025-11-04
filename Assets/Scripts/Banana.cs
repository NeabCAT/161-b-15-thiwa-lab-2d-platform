using System.Net.NetworkInformation;
using System.Threading;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Banana : Weapon
{
    [SerializeField] private float speed;

    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }

    public override void OnHitWith(Charactor charactor)
    {

        if (charactor is Enemy) 
        {
            charactor.TakeDamage(this.damage);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 4.0f * GetShootDirection();
        damage = 30;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
