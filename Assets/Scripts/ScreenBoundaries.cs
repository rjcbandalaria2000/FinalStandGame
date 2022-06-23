using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{
    public Camera mainCamera;
    Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, screenBounds.x * -1, screenBounds.x);
        viewPosition.y = Mathf.Clamp(viewPosition.y, screenBounds.y *-1, screenBounds.y);
        transform.position = viewPosition;
    }
}
