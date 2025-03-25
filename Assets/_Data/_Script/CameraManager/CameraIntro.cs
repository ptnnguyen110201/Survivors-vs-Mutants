using System.Collections;
using UnityEngine;

public class CameraIntro : LoadComPonent
{
    [SerializeField] protected Transform startPoint;
    [SerializeField] protected Transform endPoint;

    [SerializeField] protected Transform cameraHolder;   
    [SerializeField] protected float moveDuration = 1.5f;
    [SerializeField] protected bool isIntroducing = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadIntroPoint();
    }
    protected virtual void Start() 
    {
        this.StartCoroutine(this.PlayIntro());
    }

    protected virtual void LoadIntroPoint() 
    {
        if (this.startPoint != null && this.endPoint != null && this.cameraHolder != null) return;
        this.startPoint = transform.Find("CameraAreaPoint/SurvivorsArea").GetComponent<Transform>();
        this.endPoint = transform.Find("CameraAreaPoint/EnemyArea").GetComponent<Transform>();
        this.cameraHolder = transform.Find("CameraHolder").GetComponent<Transform>();
        Debug.Log(transform.name + "Load IntroPoint", gameObject);
    }

    protected virtual IEnumerator PlayIntro()
    {
        this.isIntroducing = true;
        yield return this.MoveCamera(this.startPoint, this.endPoint);
        yield return new WaitUntil(() => GameManager.Instance.IsStart);
        yield return this.MoveCamera(this.endPoint, this.startPoint);

    }

    protected virtual IEnumerator MoveCamera(Transform startPoint, Transform endPoint)
    {
        float elapsed = 0f;

        while (elapsed < this.moveDuration)
        {
            elapsed += Time.deltaTime;

            float t = Mathf.Clamp01(elapsed / this.moveDuration);
          
            t = Mathf.SmoothStep(0f, 1f, t);

            this.cameraHolder.transform.position = Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, t);
            yield return null;
        }

        this.cameraHolder.transform.position = endPoint.transform.position;
    }
}
