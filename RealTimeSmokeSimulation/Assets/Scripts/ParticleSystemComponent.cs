using UnityEngine;

public class ParticleSystemComponent : MonoBehaviour
{
    public ParticleSystem smokeParticles;
    public float emissionRate = 150.0f;
    public float windSpeed = 2.0f;
    public float gravityStrength = -0.3f;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        Debug.Log("Particle System Initialized");
        AdjustEmission(emissionRate);
        AdjustGravity(gravityStrength);
        AdjustWind(windSpeed);
    }

    public void AdjustEmission(float rate)
    {
        if (smokeParticles == null) return;

        var emission = smokeParticles.emission;
        emission.rateOverTime = new ParticleSystem.MinMaxCurve(rate);
    }

    public void AdjustGravity(float gravity)
    {
        if (smokeParticles == null) return;

        var main = smokeParticles.main;
        main.gravityModifier = gravity;
    }

    public void AdjustWind(float wind)
    {
        if (smokeParticles == null) return;

        var velocity = smokeParticles.velocityOverLifetime;
        velocity.enabled = true;

        float noiseX = Mathf.PerlinNoise(Time.time * 0.5f, 0.5f) - 0.5f;
        float noiseY = Mathf.PerlinNoise(Time.time * 0.3f, 0.8f) - 0.5f;

        velocity.x = new ParticleSystem.MinMaxCurve(wind + noiseX * 3.0f);
        velocity.y = new ParticleSystem.MinMaxCurve(1.0f + noiseY * 1.5f);
    }

    public void UpdateParticles()
    {
        if (smokeParticles == null) return;

        var main = smokeParticles.main;
        main.startSize = new ParticleSystem.MinMaxCurve(2.5f, 5.5f);
        main.startLifetime = new ParticleSystem.MinMaxCurve(3f, 8f);

        var colorOverLifetime = smokeParticles.colorOverLifetime;
        colorOverLifetime.enabled = true;

        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(Color.white, 0.0f),
                new GradientColorKey(Color.gray, 0.7f),
                new GradientColorKey(Color.white, 1.0f)
            },
            new GradientAlphaKey[] {
                new GradientAlphaKey(1.0f, 0.0f),
                new GradientAlphaKey(1.0f, 0.6f),
                new GradientAlphaKey(0.0f, 1.0f)
            }
        );
        colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);
    }

    void Update()
    {
        UpdateParticles();
    }
}
