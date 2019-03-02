using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float wetTime;
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {

            collision.gameObject.GetComponent<Debuffs>().ApplyWet(wetTime);

        }

    }

}
