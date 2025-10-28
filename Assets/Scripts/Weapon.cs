using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public int damage;
    public IShootable Shooter;

    //variable for shooting weapon


    public abstract void Move();

    public abstract void OnHitWith(Charactor charactor);

    public void InitWeapon(int newDamage, IShootable newShooter)
    {
        damage = newDamage;
        Shooter = newShooter;
    }

    public int GetShootDirection()
    {
        float value = Shooter.ShootPoint.position.x -
            Shooter.ShootPoint.parent.position.x;

        if (value > 0)
            return 1;
        else return -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Charactor charactor = other.GetComponent<Charactor>();
        if (charactor != null)
        {
            OnHitWith(other.GetComponent<Charactor>());
            Destroy(this.gameObject, 5f);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
