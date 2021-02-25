using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float ScreenWidthInUnits = 16f;

    [SerializeField] float minX = 2.5f, maxX = 13.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        float y = 1f;
      
        Vector2 paddlePos = new Vector2(MouseX,y);

        paddlePos.x = Mathf.Clamp(MouseX, minX, maxX);

        transform.position = paddlePos;
    }
}
