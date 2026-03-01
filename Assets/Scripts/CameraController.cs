
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Slider zoomSlider;
    public float zoomOutRate = 1f;
    public float lookUpRate = 1f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 5, -7-zoomOutRate*zoomSlider.value); 
        transform.rotation = Quaternion.Euler(-lookUpRate*zoomSlider.value, 0, 0);
    }
}
