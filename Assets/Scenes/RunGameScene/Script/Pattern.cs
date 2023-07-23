/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    private Rigidbody2D patternRB;
    private const float ENDPOSX = -24.0f;

    public void Init(float moveSpeed)
    {
        patternRB = GetComponent<Rigidbody2D>();
        patternRB.velocity = new Vector2(-moveSpeed, 0.0f);
    }

    private void Update()
    {
        if (ENDPOSX >= transform.position.x)
        {
            Destroy(gameObject);
        }

        if (GameManager.instance.gameOver)
        {
            patternRB.velocity = Vector2.zero;
        }
    }
}

*/