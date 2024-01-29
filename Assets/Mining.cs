using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    public Texture2D cursorArrow;
    public Texture2D cursorMining;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null) 
            {   if (hit.collider.gameObject == gameObject) 
                    Destroy(gameObject);
                    Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
            }
        }
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorMining, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
}
