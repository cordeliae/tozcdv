using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    [SerializeField] private GameObject _shop;//tam moge dac ten plik ze sklepem calym
    [SerializeField] private GameObject _hat1;// tu moge dac ta pierwsza czapke zebny sie pojawiala
    [SerializeField] private GameObject _hat2;//tu moge dac ta druga czapke
  


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))//juz pisalam
        {
            _shop.SetActive(!_shop.activeInHierarchy);//tu ma sie pokazywac albo znikac calyt canvas
        }
    }
    public void Hat1()//tro ma byc dla pierwsej czapki
    {
        if (GetComponent<tescior>().coins >= 1)//no i to dziala do tego ze jak jest 1 albo wiecej to dopiero mozna kupic
        {
            _hat1.SetActive(true);//sie wlacza
            _hat2.SetActive(false);//sie wylacza
            GetComponent<tescior>().ReduceCoin(1);//no i to redukuje mi z tego coins tekstu
        }
       
    }
    public void Hat2()//tu wszystko tak samo jak wyzej ale z druga czapka
    {
        if(GetComponent<tescior>().coins >= 4)
        {
            _hat2.SetActive(true);
            _hat1.SetActive(false);
            GetComponent<tescior>().ReduceCoin(4);
        }
       
    }
}
