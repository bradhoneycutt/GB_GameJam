using System.Linq;
using UnityEngine;

public class PowerBar : MonoBehaviour
{
    public float TravelTime;
    public float Ratio;

    private SpriteRenderer _needle;
    private Vector3 _startPoint;
    private Vector3 _endPoint;
    private float? _startTime;

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
        if (_startTime != null)
        {
            Ratio = (Time.time - _startTime ?? Time.time) / TravelTime;
            if (Ratio >= 1F)
            {
                _startTime = null;
                Ratio = 1F;
            }
        }
        _needle.transform.position = Vector3.Lerp(_startPoint, _endPoint, Ratio);
    }

    public void Reset()
    {
        Ratio = 0f;
    }

    public void StartMoving()
    {
        _startTime = Time.time;
    }

    public void StopMoving()
    {
        _needle.transform.position = Vector3.Lerp(_startPoint, _endPoint, Ratio);
        _startTime = null;
    }
}
