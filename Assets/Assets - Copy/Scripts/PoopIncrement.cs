using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoopIncrement : MonoBehaviour
{
    [SerializeField]
    Slider CacaPorcentage; // Slider UI para medir porcentaje

    [SerializeField]
    float scaleIncrement=0.01f, maxScale=2f; //Valores para maxima escala y ratio de inclemento

    [SerializeField]
    Personaje playerForward;//Referencia al player

    Vector3 InitScale;//Para guardar la escala inicial de la caca

    Vector3 sumV;//Vector para escalar la caca

    float diferencial;// Float para calcular la diferencia en tre escala actual y final

    // Start is called before the first frame update
    void Start()
    {
        InitScale = transform.localScale; 
        sumV = Vector3.one;
        diferencial = maxScale - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerForward.IsMoving && transform.localScale.y<maxScale) //Revisa si esta en movimietno la caca y si no ha llegado a su maxima escala
        {
            transform.localScale += sumV*scaleIncrement*Time.deltaTime;  //Aumenta el tamaño
            CacaPorcentage.value = (transform.localScale.y - InitScale.y) / diferencial; //Modifica el valor en porcentaje
        }
    }

    public void RestartScale() //Reinicia los stats a los iniciales
    {
        transform.localScale = InitScale;
        CacaPorcentage.value = 0f;
    }
}
