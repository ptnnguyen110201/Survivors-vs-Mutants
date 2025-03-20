using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public bool leftMouse = false;
    public bool rightMouse = false;


    public Vector3 mouseWolrdPos;
    protected virtual void Update()
    {
        this.GetMouseWorldPos();
        this.GetInputMouse();
    }

    protected virtual void GetInputMouse()
    {
        this.leftMouse = Input.GetMouseButtonUp(0);
        this.rightMouse = Input.GetMouseButtonUp(1); 
    }

    protected  virtual void GetMouseWorldPos() 
    {
        this.mouseWolrdPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.mouseWolrdPos.z = 0;

    }
}
