using UnityEngine;

public class HealthBar2D : MonoBehaviour, IHealthDisplay
{
    [SerializeField] private Transform fillTransform;
    [SerializeField] private SpriteRenderer fillRenderer;
    [SerializeField] private Gradient healthGradient;

    private float maxWidth = 1f;
    private Vector3 initialScale;

    void Start()
    {
        if (fillTransform != null)
        {
            initialScale = fillTransform.localScale;
            maxWidth = initialScale.x;
        }
    }

    public void Initialize(int maxHealth)
    {
        if (fillTransform != null)
        {
            initialScale = fillTransform.localScale;
            maxWidth = initialScale.x;
        }
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (fillTransform == null) return;

        float healthPercent = (float)currentHealth / maxHealth;
        healthPercent = Mathf.Clamp01(healthPercent);

        // ปรับขนาด Fill
        Vector3 newScale = initialScale;
        newScale.x = maxWidth * healthPercent;
        fillTransform.localScale = newScale;

        // ปรับตำแหน่ง
        Vector3 newPos = fillTransform.localPosition;
        newPos.x = -(maxWidth - newScale.x) / 2f;
        fillTransform.localPosition = newPos;

        // เปลี่ยนสี
        if (fillRenderer != null)
        {
            if (healthGradient != null && healthGradient.colorKeys.Length > 0)
            {
                fillRenderer.color = healthGradient.Evaluate(healthPercent);
            }
            else
            {
                if (healthPercent > 0.5f)
                    fillRenderer.color = Color.green;
                else if (healthPercent > 0.2f)
                    fillRenderer.color = Color.yellow;
                else
                    fillRenderer.color = Color.red;
            }
        }
    }

    public void SetVisible(bool visible)
    {
        gameObject.SetActive(visible);
    }
}