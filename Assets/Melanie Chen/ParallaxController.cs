using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layer;
        public float parallaxFactor = 0.5f;
        [HideInInspector] public Vector3 initialPos;
    }

    public Transform cam; // Drag your Main Camera here
    public ParallaxLayer[] layers;

    private Vector3 camStartPos;

    void Start()
    {
        camStartPos = cam.position;

        foreach (var layer in layers)
        {
            layer.initialPos = layer.layer.position;
        }
    }

    void Update()
    {
        Vector3 camDelta = cam.position - camStartPos;

        foreach (var layer in layers)
        {
            Vector3 addedVector = new Vector3(camDelta.x * layer.parallaxFactor, layer.initialPos.y, 0);
            //camDelta.y * layer.parallaxFactor
            Vector3 newPos = layer.initialPos + addedVector;
            layer.layer.transform.position = newPos;
        }
    }
}
