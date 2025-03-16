using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] protected bool isStart = false;
    public bool IsStart => isStart;



    public bool StartGame() => this.isStart = true;
}
