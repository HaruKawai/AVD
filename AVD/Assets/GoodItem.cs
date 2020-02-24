using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodItem : MonoBehaviour
{
    public enum ItemType{ Cherry=0, Gem=1, Frog=2}
    public ItemType Type;
    private void Start() {
        GetComponent<Animator>().SetInteger("Type",(int)Type);
    }

    public void PickItem() {
        GetComponent<Animator>().SetTrigger("Pick");
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) PickItem();
    }
}
