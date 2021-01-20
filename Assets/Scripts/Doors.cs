using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        door.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
