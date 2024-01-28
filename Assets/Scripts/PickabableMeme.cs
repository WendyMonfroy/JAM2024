using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickabableMeme : MonoBehaviour
{

    public MemeTemplate template;

    public SpriteRenderer spriteRenderer;

    public void init()
    {
        if(template != null)
            spriteRenderer.sprite = template.sprite;
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
