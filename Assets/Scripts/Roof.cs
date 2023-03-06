using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Roof : MonoBehaviour
{
    TilemapRenderer TileRenderer;
    void Start()
    {
        TileRenderer = GetComponent<TilemapRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TileRenderer.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TileRenderer.enabled = true;
        }
    }

}
