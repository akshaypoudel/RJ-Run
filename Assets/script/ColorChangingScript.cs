using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingScript : MonoBehaviour
{
    public MeshRenderer _renderer;
    float timeLeft;
    public Color targetColor;
    private void Start() {
    }

    void Update()
    {
        // _renderer.material=material;
        if (timeLeft <= Time.deltaTime)
        {
            _renderer.material.color = targetColor;
            targetColor = new Color(Random.Range(0.7f,1),Random.Range(0.4f,1),Random.Range(0.7f,1f));
            timeLeft = 1.0f;
        }
        else
        {
            _renderer.material.color = Color.Lerp(_renderer.material.color, targetColor, Time.deltaTime / timeLeft);
            timeLeft -= Time.deltaTime;
        }
    }
}
