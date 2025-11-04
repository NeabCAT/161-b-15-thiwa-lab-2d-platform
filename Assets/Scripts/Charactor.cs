using UnityEngine;

public class Charactor : MonoBehaviour
{
    //attributes
    private int health;
    private int maxHealth;

    public int Health
    {
        get { return health; }
        set
        {
            health = (value < 0 ? 0 : value);
            UpdateHealthBar();
        }
    }

    protected Animator anim;
    protected Rigidbody2D rb;

    // แก้ใหม่: ใช้ Interface แทน concrete class
    [SerializeField] private MonoBehaviour healthBarComponent;
    private IHealthDisplay healthBar;

    //Initialize variable
    public void Intialize(int startHealth)
    {
        maxHealth = startHealth;
        Health = startHealth;
        Debug.Log($"{this.name} is initialize Health Health : {this.Health}");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Setup health bar
        if (healthBarComponent != null)
        {
            healthBar = healthBarComponent as IHealthDisplay;

            if (healthBar == null)
            {
                Debug.LogError($"{healthBarComponent.name} must implement IHealthDisplay interface!");
            }
            else
            {
                healthBar.Initialize(maxHealth);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took damage {damage} , Current Health : {Health} ");
        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(Health, maxHealth);
        }
    }


    void Start()
    {

    }

    void Update()
    {

    }
}