using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public Slider emissionRateSlider;
    public Slider windSpeedSlider;
    public Slider gravitySlider;
    public ParticleSystemComponent particleSystemComponent;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        Debug.Log("User Interface Initialized");

        if (emissionRateSlider != null && particleSystemComponent != null)
        {
            emissionRateSlider.value = particleSystemComponent.emissionRate;
            emissionRateSlider.onValueChanged.AddListener(OnEmissionRateChanged);
        }
        else
        {
            Debug.LogError("Emission Rate Slider or ParticleSystemComponent not assigned!");
        }

        if (windSpeedSlider != null && particleSystemComponent != null)
        {
            windSpeedSlider.value = particleSystemComponent.windSpeed;
            windSpeedSlider.onValueChanged.AddListener(OnWindSpeedChanged);
        }
        else
        {
            Debug.LogError("Wind Speed Slider or ParticleSystemComponent not assigned!");
        }

        if (gravitySlider != null && particleSystemComponent != null)
        {
            gravitySlider.value = particleSystemComponent.gravityStrength;
            gravitySlider.onValueChanged.AddListener(OnGravityChanged);
        }
        else
        {
            Debug.LogError("Gravity Slider or ParticleSystemComponent not assigned!");
        }
    }

    public void OnEmissionRateChanged(float newValue)
    {
        if (particleSystemComponent != null)
        {
            float scaledValue = newValue * 10f; // Scale the slider value to match higher emissions
            particleSystemComponent.AdjustEmission(scaledValue);
        }
    }

    public void OnWindSpeedChanged(float newValue)
    {
        if (particleSystemComponent != null)
        {
            particleSystemComponent.AdjustWind(newValue);
        }
    }

    public void OnGravityChanged(float newValue)
    {
        if (particleSystemComponent != null)
        {
            particleSystemComponent.AdjustGravity(newValue);
        }
    }
}
