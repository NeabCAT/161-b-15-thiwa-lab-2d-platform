using UnityEngine;

public class NoFlipHealthBar : MonoBehaviour
{
    private Transform parentTransform;
    private Vector3 originalScale;

    void Start()
    {
        parentTransform = transform.parent;
        originalScale = transform.localScale;
    }

    void LateUpdate()
    {
        if (parentTransform != null)
        {
            // เช็คว่า parent ถูก flip ไหม
            if (parentTransform.localScale.x < 0)
            {
                // ถ้า parent flip แล้วให้ health bar flip กลับ
                Vector3 newScale = originalScale;
                newScale.x = -Mathf.Abs(originalScale.x);
                transform.localScale = newScale;
            }
            else
            {
                // ถ้า parent ปกติให้ health bar ปกติ
                transform.localScale = originalScale;
            }
        }
    }
}