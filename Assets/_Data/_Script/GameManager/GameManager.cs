using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] protected float[] TimeScale = { 0.5f, 1f, 2f };
    [SerializeField] protected float currentTimeScale = 1f;
    public float CurrentTimeScale => currentTimeScale;
    [SerializeField] protected bool isStart = false;
    public bool IsStart => isStart;

    [SerializeField] protected bool isStoping = false;
    public bool IsStoping => isStoping;

    protected virtual void LateUpdate()
    {
        this.PauseGame();
    }
    protected virtual void PauseGame()
    {
        if (this.isStoping) Time.timeScale = 0;
        else Time.timeScale = this.currentTimeScale;
    }
    public void IncreaseTimeScale()
    {
        int currentIndex = 0;
   
        for (int i = 0; i < this.TimeScale.Length; i++)
        {
            if (this.TimeScale[i] == currentTimeScale)
            {
                currentIndex = i;
                break;
            }
        }
        currentIndex = (currentIndex + 1) % this.TimeScale.Length;
        this.currentTimeScale = this.TimeScale[currentIndex];
        Time.timeScale = this.currentTimeScale;
    }

    public bool SetStop(bool isStoping = false) => this.isStoping = isStoping;
    public bool StartGame() => this.isStart = true;
}
