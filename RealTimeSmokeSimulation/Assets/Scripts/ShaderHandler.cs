using UnityEngine;

public class ShaderHandler : MonoBehaviour
{
    public Material smokeMaterial;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        Debug.Log("Shader Handler Initialized");
    }

    public void UpdateShader()
    {
        if (smokeMaterial == null) return;
        float turbulence = Mathf.PerlinNoise(Time.time * 0.5f, 0.5f);
        smokeMaterial.SetFloat("_Turbulence", turbulence);
    }

    void Update()
    {
        UpdateShader();
    }
}
