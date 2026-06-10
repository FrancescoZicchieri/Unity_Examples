using UnityEngine;

// GENERATO CON DEEPSEEK
// A SEGUIRE IL PROMPT:
//
// Capo, mi serve uno script per unity per il movimento di una macchina.
// In pratica, tieni premuto W e accelera, con S decelera (niente retro per semplciità).
// Con A, D sterza.
// Fammi la magia pls
//
// L'ho modificato in diversi punti, ma lascio il prompt come linea guida di come li scrivo quando succede (btw uso l'AI raramente, quindi non è oro colato il mio prompt)
// Al solito se PROPRIO dovete (eugh) usare un'AI per cose grosse fate attenzione, usatene una che sa gestire tanti script insieme e preparatevi a doverci lavorare anche voi

public class CarController : MonoBehaviour
{
    // Campi esposti nell'inspector di Unity - quelli con cui modificare il comportamento del veicolo
    [Header("Impostazioni Motore")]
    [SerializeField] private float accelerationForce = 1500f;
    [SerializeField] private float decelerationForce = 500f;
    [SerializeField] private float maxSpeed = 50f;

    [Header("Impostazioni Sterzo")]
    [SerializeField] private float turnSpeed = 200f;
    [SerializeField] private float maxTurnAngle = 7f;

    [Header("Impostazioni Frenata Naturale")]
    [SerializeField] private float naturalDrag = 0.5f;
    [SerializeField] private float brakingDrag = 3f;

    [Header("RICORDA DI SETTARE LA MASSA DEL RIGIDBODY A 100")] // cancella pure dopo aver settato la massa del rigidbody a 100 o qualcosa del genere
    [SerializeField] private bool SiMeLoRicordo = false;        // cancella pure dopo aver settato la massa del rigidbody a 100 o qualcosa del genere

    // Campi non esposti - generalmente riferimenti salvati e variabili per calcoli interni
    private Rigidbody rb;
    private float currentTurnAngle = 0f;
    private float moveInput;
    private float turnInput;

    // Funzione Start() di Unity - chiamata il primo frame in cui questo component esiste - prima del primo udpate
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Salviamo il riferimento al rigidbody perché GetComponent<>() è pesante e bisogna evitare di usarla spesso
        // UN ERRORE TI RIMANDA QUA? La tua macchina non ha un rigidbody

        rb.linearDamping = naturalDrag; // Settiamo tramite script una proprietà del rigidbody
    }

    // Funzione Update() di Unity - chiamata ogni frame
    void Update()
    {
        // Input
        HandleInput();

        // Sterzo (lo gestiamo in Update per maggiore reattività - qui è il disastro di avere alcune cose in Update e altre in FixedUpdate)
        HandleSteering();
    }

    // Funzione FixedUpdate() di Unity - chiamata ogni intervallo di tempo fisso e indipendente dal frame rate
    void FixedUpdate()
    {
        // Movimento (in FixedUpdate per la fisica)
        HandleMovement();
    }

    void HandleInput()
    {
        // Accelerazione / Decelerazione
        if (Input.GetKey(KeyCode.W))
        {
            moveInput = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveInput = -1f;
        }
        else
        {
            moveInput = 0f;
        }

        // Sterzo
        if (Input.GetKey(KeyCode.A))
        {
            turnInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            turnInput = 1f;
        }
        else
        {
            turnInput = 0f;
        }
    }

    void HandleSteering()
    {
        if (rb.linearVelocity.magnitude <= 0.01f) return; // Usiamo return per uscire immediatamente da questa funzione se non stiamo muovendoci: le macchine ferme non girano!

        turnInput *= rb.linearVelocity.magnitude; // Inoltre moltiplichiamo il turnInput per la velocità per un effetto più realistico (evitiamo calcoli matematici complessi)

        if (turnInput != 0) // Se turnInput non è 0 sterza in quella direzione
        {
            currentTurnAngle = Mathf.Lerp(currentTurnAngle, maxTurnAngle * turnInput, Time.deltaTime * 5f);
        }
        else // Se è 0 invece riporta gradualmente lo sterzo verso il centro
        {
            currentTurnAngle = Mathf.Lerp(currentTurnAngle, 0f, Time.deltaTime * 5f);
        }

        transform.Rotate(Vector3.up, currentTurnAngle * Time.deltaTime);
    }

    void HandleMovement()
    {
        if (moveInput > 0) // Accelerazione
        {
            // Controllo velocità massima
            if (rb.linearVelocity.magnitude < maxSpeed)
            {
                // Se non siamo sopra la velocità massima, acceleriamo applicando una forza al rigidbody
                rb.AddForce(accelerationForce * moveInput * transform.forward);
            }

            // Drag normale quando si accelera
            rb.linearDamping = naturalDrag;
        }
        else if (moveInput < 0) // Frenata
        {
            // Applica una forza contraria per frenare
            rb.AddForce(decelerationForce * moveInput * transform.forward);

            // Aumenta il drag quando si frena
            rb.linearDamping = brakingDrag;
        }
        else
        {
            // Drag naturale quando non si preme nulla
            rb.linearDamping = naturalDrag;
        }
    }
}