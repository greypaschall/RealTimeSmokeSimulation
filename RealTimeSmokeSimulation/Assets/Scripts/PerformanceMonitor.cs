using UnityEngine;

public class PerformanceMonitor : MonoBehaviour
{
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        Debug.Log("Performance Monitor Initialized");
    }

    public void MonitorPerformance()
    {
        Debug.Log("FPS: " + (1.0f / Time.deltaTime));
    }

    void Update()
    {
        MonitorPerformance();
    }
}
