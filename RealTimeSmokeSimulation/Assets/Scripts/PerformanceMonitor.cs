using UnityEngine;
using System.IO;

public class PerformanceMonitor : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private float timer = 0f;
    private string logPath;

    void Start()
    {
        logPath = Application.dataPath + "/PerformanceData.csv";
        File.WriteAllText(logPath, "Time,FPS,ParticleCount\n");
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1.0f)
        {
            int particleCount = particleSystem.particleCount;
            float fps = 1.0f / Time.deltaTime;
            string line = $"{Time.time:F2},{fps:F2},{particleCount}\n";
            File.AppendAllText(logPath, line);
            timer = 0f;
        }
    }
}