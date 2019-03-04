using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSegment : MonoBehaviour
{
    public Sprite[] sprites;

    private Health health => GetComponent<Health>() ?? gameObject.AddComponent<Health>();

    private void Update()
    {
        if (health.hp >= sprites.Length)
            return;

        if (health.isDead)
        {
            Destroy(gameObject);

            return;
        }

        GetComponent<SpriteRenderer>().sprite = sprites[health.hp - 1];
    }
}
