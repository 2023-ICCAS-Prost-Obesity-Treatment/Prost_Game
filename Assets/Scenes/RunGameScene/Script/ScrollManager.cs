/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public Sprite BackGround2;
    public Sprite BackGround3;
    public float scrollSpeed;
    private SpriteRenderer Scroller;
    private Vector2 scrollOffset = Vector2.zero;

    void Start()
    {
        Scroller = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!GameManager.instance.gameOver)
        {
            scrollOffset = Scroller.material.mainTextureOffset;
            scrollOffset.x += (scrollSpeed * Time.deltaTime);
            Scroller.material.mainTextureOffset = scrollOffset;
        }

        switch (GameManager.instance.stage)
        {
            case 2:
                Scroller.sprite = BackGround2;
                Scroller.transform.localScale = new Vector3(4.15f, 3.112499f, 1.0f);
                break;
            case 3:
                Scroller.sprite = BackGround3;
                Scroller.transform.localScale = new Vector3(15.67497f, 12.37498f, 1.0f);
                break;
        }
    }
}
*/