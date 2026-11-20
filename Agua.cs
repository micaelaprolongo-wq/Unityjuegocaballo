using UnityEngine;
using TMPro;

public class Agua : MonoBehaviour
{
    public TextMeshProUGUI textoAgua;
    private int porcentajeAgua = 100;
    private float temporizadorAgua = 0f;
    private const float dosMinutos = 120f; 

    void Update()
    {
        if (porcentajeAgua > 0)
        {
            temporizadorAgua += Time.deltaTime;
            if (temporizadorAgua >= dosMinutos)
            {
                porcentajeAgua -= 5;
                if (porcentajeAgua < 0) porcentajeAgua = 0;
                temporizadorAgua = 0f;
            }
        }

        if (textoAgua != null)
        {
            textoAgua.text = porcentajeAgua.ToString() + "%";
        }
    }
}