using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tescior : MonoBehaviour
{
    private Rigidbody rb; //to jest zeby mi postac ogarnia³a ze ma rigidbody
    public float JumpForce = 5f; //to mi tworzy to z jaka moca moja kulka skacze i sie tam potem w unity pokazuje i moge sobie zmieniac
    public int coins; //to jest zmienna co mi okreœla moje monetki a jest public zeby mozna bylo jje uzyc w innym skrypcie
    public TextMeshProUGUI coinText; //to mi tworzy zmienna od tekstu ui co ma mi sie do gory pokazywac z zebranymi tymi tymi

    private void Awake()// to sprawia ze cos tam co tam pisze sie dzieje przed odpaleniem gry
    {
        rb = GetComponent<Rigidbody>();//no to znowu jest od rigidbody bo to nie dzia³a³o i dopiero jak pierdyliard razy to zrobi³am to zadzia³a³o
    }

    
    void FixedUpdate()//fixed update sie rozni tym od zwyk³ego update ze jest wywo³ywany raz na klatke przez co mi nie buguje ruchów imo sa bardziej p³ynne
    {
        if (Input.GetKey(KeyCode.A))//jezeli nacisne przycisk tu akurat a to...
        {
            transform.Translate(Vector3.back*0.1f);//no i tu pisze co sie dzieje z moja postacia po nacisnieciu w tym przypadku idzxie do tylu czyli w sumie w grze leci w ty³
        }
        if (Input.GetKey(KeyCode.D))//tu to samo co wczesniej czyli jak nacisne przycisk to...
        {
            transform.Translate(Vector3.forward * 0.1f);//i tak samno jak tam to tu leci do przodu a i tam nie doda³am ze to 0,1f to jest szybkosc zjaka leci/idzie
        }
        if (Input.GetKeyDown(KeyCode.Q))//tu znowy to samo tym razem z q tym razem tylko musze prztrzymac przycisk
        {
            transform.localScale+=Vector3.one;//no tu sie troche zmienia bo robi wziuuuum i sie powieksza
        }
        if (Input.GetKeyDown(KeyCode.E))//tu znowu to samo z przycisnieciem bo jest down
        {
            transform.localScale-=Vector3.one;//no i tu robi wziuuum ale w druga strone i sie zmniejsza
        }
        if (Input.GetKey(KeyCode.C))//no tu to co bylo z a i d czylio jak nacisne
        {
            transform.Rotate(new Vector3(0,1,0),Space.Self);//no i tu juz sie nie przemieszcza a obraca bo jest rotate no dalej jest ktora os sie obraca i no
        }

    }

    private void Update()//tak jak wczesniej wspomina³am to update jest klatka na sekunde po prostu jest go wiecej yk przez co np ruch moze sie bagowac
    {
        if (Input.GetKeyDown(KeyCode.Space))//tu znowu to co tam czyli wybrany przcisk tym razem spacja i ona cos tam ma robic
        {
            rb.AddForce(Vector3.up *JumpForce, ForceMode.Impulse);//i tu jest napisane co ma robic dokladnie czyli wykorzystujemyt tutaj ten jumpforce i rigidbody zeby no jak podskoczymy to zeby spada³a
        }
        Debug.Log("MONETKI: " + coins);// tutaj byl szybki check czy monetki/coinsy dzia³aja ogolnie debug sie nie pokazuje faktycznie w grze tylko  wtym panelu na dole przydatne
        coinText.text = "Coin: " + coins.ToString();//tu wykorzystujemy to z ta ui i jest napisane dok³adnie co ma sie tam wyswietlic i zeby dodawa³o do tego kolejne coinsy to tostring jest po to zeby na tekst sie to co tu pisz zmieni³o faktycznie o to w sumie sie teraz okazalo ze to tu nie musi byc tylko wtym fixed moze byc ig?
    }

    private void OnTriggerEnter(Collider other)//ontrigger no to jak sama nazwa wskazuje reaguje na jakis eeee bodziec? dunnno jak to nazwac ale no wiem o co chodzi bo to z tymi tagami jest o! zeby reagowa³o na tag ktorym jest oznaczony jakis element
    {
        if (other.gameObject.CompareTag("Bigger"))//no i tu ogolnie chodzi o zeby sprawdzalo czy jakis objekt z ktorym koliduje ziomek co ma ten skrypt ma ten tag co t u jest a wlasnie i zeby to w ogole dzialalo to obie rzeczy musza miec collider i ten ziomek co ma skrypt musi miec rigidbody
        {
            transform.localScale = new Vector3(10f, 10f, 10f);//no i ogolnie to tego juz nie uzywam ale tu jest a chodziu w tym oto ze jak ziomek wleci w jakas np platforme to robi sie wiekszy 
        }
        if (other.gameObject.CompareTag("Smaller"))//tu to to samo ale ma porownywac czy ma ten inny tag
        {
            transform.localScale = new Vector3(1f, 1f, 1f);//no i dzieje sie to samo co wczesniej czyli jak ziomek wleci w np sciane to sie robi mniejszy 
        }
        if(other.gameObject.CompareTag("coin"))//no i to jest od zbierania monetek i monetki maja tylko odpowiedni tag 
        {
            other.gameObject.SetActive(false);//no i to robi tak ze ziomek jak zderzy sie z monetka to ona znika 
            coins++;//to ma dodawac nam monetki jak znikna
        }
        if(other.gameObject.CompareTag("death"))//no i znowu to samo z tym tagiem 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//tu chodzi o to ze jezeli gosc dotknie tego co jest z tym tagiem to jakny umiera czyli scena jest na nowo ³adowana
        }
        if (other.gameObject.CompareTag("door") && coins >= 7)//tu znowy tag ale jeszcze on ma zareagowac dopiero jak monetek bedzie zebranych 7 albo wircej
        {
            other.GetComponent<Animator>().SetTrigger("Opening");//a to jest podlaczenie do animacji ze no jak juz sie otworza to maja byc zanimowane tak jak zostaly w tej animacji
        }
        if (other.gameObject.CompareTag("next"))//no znowu tag 
        {
            SceneManager.LoadScene(2);//znowu odwo³amnie do menadzera scen z tego build settings a i w ogole zeby to zadzialalo to musi byc nowa biblioteka dodana wlasnie ta scene menager no i laduje sie kolejna scena
            //Debug.Log("Next Level");
        }
        if (other.gameObject.CompareTag("next2"))//no i tu znowu tag ale do kolejnej sceny
        {
            SceneManager.LoadScene(3);//no i to samo czyli kolejna scena ladowanie
            //Debug.Log("Next Level");
        }



    }
    private void Start()//to ogolnie ma na samym poczatku po wystartowaniu gry sie za³adowac 
    {
        Physics.gravity = new Vector3(0, -100, 0);//tutaj dodawalam grawitacje zeby ziomek troche szybciej spadal
        CoinManager.coinCounter = 0;//no to na poczatku na 0 ustawia ten licznik
    }
     
    public void ReduceCoin(int p)//to jest taka zmienna co ja potem widac w unity i w niej cgodzi o zmniejszanie coinsow
    {
        coins -= p;//czyli no jak sie wyda te coinsy w sklepie to sie redukuja
        coinText.text = coins.ToString();//i to sprawia ze to sie pokazuje z tym teksie do gory zredukowane
    }
 
}
