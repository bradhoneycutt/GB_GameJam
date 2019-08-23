using System.Linq;
using UnityEngine;

public class PowerBar : MonoBehaviour
{
    public float TravelTime;
    public float Ratio;

    private SpriteRenderer _needle;
    private Vector3 _startPoint;
    private Vector3 _endPoint;
    private PowerBarStatus _powerBarStatus = PowerBarStatus.Stopped;

    // Start is called before the first frame update
    void Start()
    {
        var sprites = this.GetComponentsInChildren<SpriteRenderer>();
        _needle = sprites.FirstOrDefault(s => s.name == "Needle");
        _startPoint = new Vector3(_needle.transform.position.x, _needle.transform.position.y);
        _endPoint = this.GetComponentsInChildren<Transform>().FirstOrDefault(t => t.name == "EndPoint").position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_powerBarStatus)
        {
            case PowerBarStatus.Right:
                Ratio += Time.deltaTime / TravelTime;
                break;
            case PowerBarStatus.Left:
                Ratio -= Time.deltaTime / TravelTime;
                break;
            case PowerBarStatus.Stopped:
                return;
        }
        if (Ratio > 1F)
        {
            Ratio = 1F;
            _powerBarStatus = PowerBarStatus.Left;
        }
        if (Ratio < 0F)
        {
            Ratio = 0F;
            _powerBarStatus = PowerBarStatus.Right;
        }
        _needle.transform.position = Vector3.Lerp(_startPoint, _endPoint, Ratio);
    }

    public void Reset()
    {
        Ratio = 0f;
        _powerBarStatus = PowerBarStatus.Stopped;
    }

    public void StartMoving()
    {
        _powerBarStatus = PowerBarStatus.Right;
    }

    public void StopMoving()
    {
        _powerBarStatus = PowerBarStatus.Stopped;
    }
}

public enum PowerBarStatus
{
    Left,
    Stopped,
    Right
}
