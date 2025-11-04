public interface IHealthDisplay
{
    void Initialize(int maxHealth);
    void UpdateHealthBar(int currentHealth, int maxHealth);
    void SetVisible(bool visible);
}