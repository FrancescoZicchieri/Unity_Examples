using UnityEngine;
using UnityEngine.UI;

// Una classe molto semplice contenente un singolo metodo che può essere chiamato da un pulsante
// Nota che il metodo deve essere pubblico
// Per ulteriori info su come scrivere e leggere codice creerò uno script a parte :D
public class ButtonChangeColor : MonoBehaviour
{
    // FIELDS
    [SerializeField] private Image targetImage;

    // METHODS
    public void Clicked() // Il metodo che richiameremo con il pulsante
    {
        Image myImage = GetComponent<Image>();
        // UN ERRORE TI RIMANDA QUA? Questo pulsante non ha un component di tipo Image, devi aggiungerlo (il che è strano, che razza di pulsante stai usando senza image?!)

        Color myColor = myImage.color;

        targetImage.color = myColor;
        // UN ERRORE TI RIMANDA QUA? Probabilmente ti sei dimenticato di assegnare targetImage!
    }
}
