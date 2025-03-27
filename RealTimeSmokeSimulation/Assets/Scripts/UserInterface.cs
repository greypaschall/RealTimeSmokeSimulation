using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInterface : MonoBehaviour
{
    public Slider emissionRateSlider;
    public Slider windSpeedSlider;
    public Slider gravitySlider;

    public TextMeshProUGUI emissionRateValueText;
    public TextMeshProUGUI windSpeedValueText;
    public TextMeshProUGUI gravityValueText;

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
            UpdateEmissionText(emissionRateSlider.value);
        }
        else
        {
            Debug.LogError("Emission Rate Slider or ParticleSystemComponent not assigned!");
        }

        if (windSpeedSlider != null && particleSystemComponent != null)
        {
            windSpeedSlider.value = particleSystemComponent.windSpeed;
            windSpeedSlider.onValueChanged.AddListener(OnWindSpeedChanged);
            UpdateWindText(windSpeedSlider.value);
        }
        else
        {
            Debug.LogError("Wind Speed Slider or ParticleSystemComponent not assigned!");
        }

        if (gravitySlider != null && particleSystemComponent != null)
        {
            gravitySlider.value = particleSystemComponent.gravityStrength;
            gravitySlider.onValueChanged.AddListener(OnGravityChanged);
            UpdateGravityText(gravitySlider.value);
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
            float scaledValue = newValue * 10f;
            particleSystemComponent.AdjustEmission(scaledValue);
            UpdateEmissionText(scaledValue);
        }
    }

    public void OnWindSpeedChanged(float newValue)
    {
        if (particleSystemComponent != null)
        {
            particleSystemComponent.AdjustWind(newValue);
            UpdateWindText(newValue);
        }
    }

    public void OnGravityChanged(float newValue)
    {
        if (particleSystemComponent != null)
        {
            particleSystemComponent.AdjustGravity(newValue);
            UpdateGravityText(newValue);
        }
    }

    private void UpdateEmissionText(float value)
    {
        if (emissionRateValueText != null)
        {
            emissionRateValueText.text = $"{value:F1}";
        }
    }

    private void UpdateWindText(float value)
    {
        if (windSpeedValueText != null)
        {
            windSpeedValueText.text = $"{value:F1}";
        }
    }

    private void UpdateGravityText(float value)
    {
        if (gravityValueText != null)
        {
            gravityValueText.text = $"{value:F1}";
        }
    }
}
