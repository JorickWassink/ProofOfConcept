using UnityEngine;
using UnityEngine.AI;

public class SelectableCharacter : MonoBehaviour
{
    public bool isSelected = false;
    public float moveRange = 10f;
    public float attackRange = 5f;

    private SpriteRenderer sr;

    [SerializeField] RangeCircle moveCircle;
    [SerializeField] RangeCircle attackCircle;
    

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (moveCircle != null)
        {
            moveCircle.DrawCircle(moveRange);
            moveCircle.SetColor(new Color(0f, 0.8f, 1f, 0.5f));
            moveCircle.Show(false);
        }

        if (attackCircle != null)
        {
            attackCircle.DrawCircle(attackRange);
            attackCircle.SetColor(new Color(1f, 0f, 0f, 0.5f));
            attackCircle.Show(false);
        }
    }

    void Update()
    {
        moveCircle.Show(isSelected);
        attackCircle.Show(isSelected);
        if (isSelected)
        {
            sr.color = Color.yellow;

        }
        else
        {
            sr.color = Color.white;
        }
    }
}
