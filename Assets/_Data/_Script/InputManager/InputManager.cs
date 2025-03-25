using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public bool leftMouse = false;  
    public bool rightMouse = false; 
    public bool isTouching = false; 

    public Vector3 mouseWolrdPos;

    protected virtual void Update()
    {
        this.GetMouseWorldPos();
        this.GetInput();
    }

    protected virtual void GetMouseWorldPos()
    {
        if (Camera.main == null)
        {
            return;
        }

        if (Application.isMobilePlatform)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0); 
                this.mouseWolrdPos = Camera.main.ScreenToWorldPoint(touch.position);
                this.mouseWolrdPos.z = 0;
            }
        }
        else
        {
            this.mouseWolrdPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.mouseWolrdPos.z = 0;
        }
    }


    protected virtual void GetInput()
    {
        if (Application.isMobilePlatform)
        {
            this.isTouching = Input.touchCount > 0;

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                this.leftMouse = touch.phase == TouchPhase.Ended; 
            }
            else
            {
                this.leftMouse = false;
            }

            if (Input.touchCount == 2)
            {
                this.rightMouse = true;
            }
            else
            {
                this.rightMouse = false;
            }
        }
        else
        {
            this.leftMouse = Input.GetMouseButtonUp(0);
            this.rightMouse = Input.GetMouseButtonUp(1);
        }
    }
}
