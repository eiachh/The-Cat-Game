using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presentation : MonoBehaviour
{
    // Start is called before the first frame update
    Transform myTransform;
    void Start()
    {
        var spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(255, 0, 250);

        GameObject anotherRandomAss = new GameObject("bobbbibibibi");
        var randomAssSpriteRenderer = anotherRandomAss.AddComponent<SpriteRenderer>();
        randomAssSpriteRenderer.color = spriteRenderer.color;
    }
}
