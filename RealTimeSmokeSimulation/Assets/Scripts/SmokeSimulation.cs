using UnityEngine;

public class SmokeSimulation : MonoBehaviour
{
    public ParticleSystemComponent smokeSystem;

    void Start()
    {
        if (smokeSystem != null)
        {
            smokeSystem.Initialize();
        }
        else
        {
            Debug.LogError("[SmokeSimulation] SmokeSystem is not assigned!");
        }
    }

    void Update()
    {
        if (smokeSystem != null)
        {
            smokeSystem.UpdateParticles();
        }
    }
}
