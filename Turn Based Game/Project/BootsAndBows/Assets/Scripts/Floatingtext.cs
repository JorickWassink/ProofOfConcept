using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float fadeTime = 1f;
    private TextMeshPro textMesh;
    private Color originalColor;

    public void Initialize(string text, Color color)
    {
        if (textMesh == null)
        {
            textMesh = GetComponent<TextMeshPro>();
            originalColor = textMesh.color;
        }

        textMesh.text = text;
        textMesh.color = color;
        Destroy(gameObject, fadeTime);
    }

    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        if (textMesh != null)
        {
            Color c = textMesh.color;
            c.a -= Time.deltaTime / fadeTime;
            textMesh.color = c;
        }
    }
}
