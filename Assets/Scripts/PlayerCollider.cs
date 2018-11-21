using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        GameObject collidedWith = collision.gameObject;
        Color color = collidedWith.tag == "WALL" ? Color.red : collidedWith.tag == "FLOOR" ? Color.yellow : Color.cyan;
        collidedWith.GetComponent<SpriteRenderer>().color = color;
        collidedWith.tag = "FLOOR_V";
    }
}
