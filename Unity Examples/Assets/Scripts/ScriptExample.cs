// #############################################################################################################################################
// SCRIPT EXAMPLE
// In questo script descriverò le varie cose che potreste trovare in uno script (classi, variabili, metodi/funzioni)
// Usatelo come riferimento per la nomenclatura e le funzionalità delle cose, così come la struttura del codice.
// Sappiate però che NON fa nulla, potete metterlo su un oggetto in quanto è monobehaviour ma non serve a nulla.
// #############################################################################################################################################

// USINGS
// Descrivono quali librerie aggiuntive utilizziamo o stiamo facendo riferimento
// Non tutte le funzioni o tipi di variabili esistono in assoluto, perché se no si finirebbe ad avere un sacco di cose che condivino il nome,
// cosa che renderebbe il codice errato a prescindere. Per questo bisgona definire cosa si usa e cosa no.
// Talvolta gli errori nel codice sono dovuti alla mancanza di uno using oppure uno using sbagliato.
// Vi lascio una piccola lista di using che potrebbero mancare.
// ESEMPI DI USINGS IMPORTANTI:
// - System.Collections.Generic -> Liste, tipo List<int>
// - System.Collections -> IEnumerator, ovvero il tipo di return delle coroutine
// - UnityEngine.UI -> UI di Unity, da non confondere con UnityEngine.UIElements, che è per l'altro sistema che sconsiglio.
// - TMPro -> il testo della UI di Unity ha il suo using a parte
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

// CLASS
// Un oggetto "contenitore" all'interno del quale possiamo definire variabili e metodi/funzioni
// Notate la struttura:
// public class NomeDellaClasse : NomeDellaClassePadre, PossibileInterfaccia, PossibileSecondaInterfaccia (, altre interfacce - quante ne vuoi)
// public class NomeDellaClasse - questa è la parte base
// : NomeDellaClassePadre - identifica la classe padre, ovvero quella da cui questa eredita tutti i membri (variabili e metodi/funzioni) - può esserci un solo padre
// , PossibileInterfaccia, PossibileSecondaInterfaccia (, altre interfacce - quante ne vuoi) - definiscono ulteriori proprietà e/o metodi/funzioni - una classe può avere un qualsiasi numero di interfacce
//
// Per quello che vi interessa TUTTO il codice sta dentro le classi o oggetti simili
// - in particolare questo significa che NON potete scrivere variabili o funzioni fuori dalla classe
//
// -     -       NOME      :     PADRE    ,    INTERFACCIA_1
public class ScriptExample : MonoBehaviour, IPointerClickHandler
{
    // MEMBER
    // Un membro è una qualsiasi cosa che sta dentro una classe, in particolare a voi interessano:
    // FIELDS - ovvero le variabili
    // METHODS - i metodi (spesso chiamati funzioni)

    // FIELD
    // I fields o, in italiano, i campi, sono le variabili definite per avere valore in tutta la classe
    // Si definiscono tipicamente in testa alla classe, prima dei metodi
    // Struttura:
    // private/public tipo nome = valore_default;
    // private - accessibile solo dentro questa classe - NON apparirà nell'inspector di Unity, a meno che non venga marcata con [SerializeField]
    // public - accessibile anche da fuori a questa classe - apparirà nell'inspector di Unity, a meno che non venga marcata con [HideInInspector]
    // tipo - che tipo di valore rappresenta (e.g. int -> numero intero, float -> numero reale (quelli con la virgola), List<List<ScriptExample>> -> una lista di liste di istanze di questa classe
    // nome il nome con cui identificare univocamente il campo/variabile dentro questa classe
    // = valore di default - se volete potete assegnare un valore di default
    //
    // Ecco alcuni differenti esempi commentati
    private int HealthPoints;                          // Una variabile privata che rappresenta un numero intero, chiamata HealthPoints
    public float ManaPercentage = 100;                 // Una variabile pubblica che rappresenta un numero reale, chiamata ManaPercentage, che ha un valore di default di 100
    [SerializeField] private string CharacterName;     // Una variabile privata di tipo stringa chiamata CharacterName, che apparirà in inspector nonostante sia privata
    [HideInInspector] public int NumberOfDeaths;       // Una variabile pubblica di tipo int chiamata NumberOfDeaths, che NON apparirà in inspector nonostante sia pubblica

    List<string> UnlockedCharacters;                   // Una variabile privata (default se non c'è ne public ne private) di tipo List<string> (ovvero una lista di stringhe)
    public int[] PartyMembersLevels = new int[4];      // Una variabile pubblica di tipo int[] (ovvero un array di int). Simile alla lista ma più leggero e meno flessibile - non potete cambiare il numero degli elementi

    private ScriptExample scriptExampleReference;      // Una variabile di tipo ScriptExample, ovvero che contiene un riferimento ad un'istanza ScriptExample - Notate che il nome della classe ScriptExample è il TIPO di questa variabile, non il nome, quello è scriptExampleReference

    // METHOD
    // I metodi sono le funzioni, ovvero pezzi di codice che "fanno qualcosa"
    // Si riconoscono per le parentesi tonde () dopo al nome, che possono - ma NON necessitano - di contenere parametri
    // Quando volete fare qualcosa con il codice dovete usare una funzione - in particolare non potete scrivere pezzi di codice che fanno cose come calcoli matematici fuori dalle funzioni
    // Struttura:
    // private/public tipoDiReturn NomeFunzione(PARAMETRI) { ... ... ... }
    // private/public - livello di accessibilità - stesso dei campi/variabili - se assente è private di default
    // tipoDiReturn - una funzione può (ma NON deve necessariamente) avere un output. Se ne ha uno, bisogna dire il tipo qua, se no (80% dei casi) si segna void
    // NomeFunzione - in nome della funzione, che possibilmente è grammaticalmente corretto e ne descrive il funzionamento e il ruolo - VI PREGO >_<
    // (PARAMETRI) - spesso creerete funzioni senza parametri, in quel caso aprite e chiudete le tonde () subito dopo al nome - in caso contrario dovete scrivete (TipoParametro1 NomeParametro1, TipoParametro2 NomeParametro2, etc.)
    // { ... ... ... } - a questo aprite le graffe e definite cosa va questa funzione scrivendo codice - la mia parte preferita, forse non la vostra :D
    //
    // Vediamo ora degli esempi!
    // Metterò la descrizione nelle triple /// così verrà proprio assegnata alla funzione come tooltip
    // Quindi passate il mouse sui nomi delle funzioni per capire cosa sono e cosa fanno

    /// <summary>
    /// Una funzione basilare che scrive Hello World nella console di Unity.
    /// </summary>
    public void HelloWorld()
    {
        Debug.Log("Hello World");
    }

    /// <summary>
    /// Una semplice funzione privata che somma due numeri.
    /// </summary>
    /// <param name="addendo1">Il primo addendo.</param>
    /// <param name="addendo2">Il secondo addendo.</param>
    /// <returns>La somma dei numeri dati.</returns>
    private int Somma(int addendo1, int addendo2)
    {
        int somma = addendo1 + addendo2;  // int somma è una variabile locale dove salviamo il risultato della somma
        return somma;                     // usa somma come output della funzione
    }

    /// <summary>
    /// Esempio di funzione pratica usata per subire danno.
    /// Il numero di danni ricevuti è l'unico parametro, verranno sottratti agli HP, uccidendo il pg se questi scendono a 0 o meno.
    /// C'è un terribile bug tra questa funzione e Die() - riuscite a trovarlo? La soluzione in fondo allo script! (non da errore in C# ma rendere il gioco ingiocabile)
    /// </summary>
    /// <param name="damageToTake">Quanti danni sono stati ricevuti?</param>
    public void TakeDamage(int damageToTake)
    {
        HealthPoints -= damageToTake;     // sottrae il danno agli hp
        if (HealthPoints < 0)             // controlla se gli hp sono scesi a 0 o meno
        {
            Die();                        // chiama un'altra funzione, Die()
            HealthPoints = 0;             // fissa gli hp a 0
        }
    }

    /// <summary>
    /// Funzione della morte del personaggio.
    /// Aumenta il conteggio delle morti, gettando disonore sul giocatore e la sua discendenza, ma lo cura riportandolo in vita a 3 hp.
    /// </summary>
    private void Die()
    {
        NumberOfDeaths++;                 // aumenta il numero di morti
        HealthPoints = 3;                 // porta gli hp a 3
    }

    /// <summary>
    /// La funzione dell'interfaccia implementata IPointerClickHandler (notate che se la cancellate l'interfaccia darà errore e chiederà di crearla).
    /// Non è definito qua, ma questa funzione associata a questa interfaccia viene chiamata quando l'oggetto con questo script è cliccato durante il gioco.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("SONO STATO PREMUTO!");
    }
}



// IL BUG DELLA MORTE
// Siccome la funzione morte - che resetta gli hp a 3 - è chiamata prima della riga che setta gli hp a 0, dopo la prima morte resterebbero fissi a 0 per il resto del gioco.
// Per risolverlo invertiamo le righe Die() e HealthPoints = 0 oppure togliamo quest'ultima che è inutile.