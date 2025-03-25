using UnityEngine;

public class InputKeyManager : Singleton<InputKeyManager>
{
    public bool isSpace = false;
    public bool isKeyM = false;

    protected virtual void Update() 
    {
        this.GetInputKey();
    }

    protected virtual void GetInputKey() 
    {
        this.isSpace = Input.GetKeyUp(KeyCode.Space);
        this.isKeyM = Input.GetKeyUp(KeyCode.M);
    }
}
