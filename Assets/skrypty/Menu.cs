using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame() //to mi dzia�a tylko w graniu juz
    {
        SceneManager.LoadSceneAsync(1); //to mi wywo�uyje menad�er co mi �aduje sceny ktore tam sa w tym build setting
    }
    
}
