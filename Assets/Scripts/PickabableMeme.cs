using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickabableMeme : MonoBehaviour
{

    public MemeTemplate template;
    public SpriteRenderer spriteRenderer;

    public float size = 1;

    public void init()
    {
        if (template != null)
        {
            spriteRenderer.sprite = template.sprite;
            float width = template.sprite.rect.width;
            transform.localScale = transform.localScale * (size/width) * 500;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        print(gameObject.name +  "by" + collision.name);
        if(collision.GetComponentInParent<Inventory>() != null)
        {
            collision.GetComponentInParent<Inventory>().pickMeme();
            Destroy(gameObject);
        }
    }
}
