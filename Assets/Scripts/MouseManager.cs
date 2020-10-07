using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    public LayerMask clickableLayer;

    public Texture2D normalCursor;
    public Texture2D targetCursor;
    public Texture2D doorwayCursor;
    public Texture2D combatCursor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer))
        {
            bool door = false;

            if (hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorwayCursor, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }

            else
            {
                Cursor.SetCursor(targetCursor, new Vector2(16, 16), CursorMode.Auto);
            }


        }
        else
        {
            Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}
