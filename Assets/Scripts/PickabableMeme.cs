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
        if(collision.GetComponent<Rigidbody>() != null)
        {
            collision.GetComponent<Rigidbody>().GetComponentInParent<Inventory>().pickMeme();
            Destroy(gameObject);
        }
    }
}
