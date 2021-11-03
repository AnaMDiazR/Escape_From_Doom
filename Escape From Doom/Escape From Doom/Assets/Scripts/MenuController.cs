using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    
    public void EscenaNivel()
    {
        SceneManager.LoadScene("Nivel");
        
    }
    public void EscenaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void SalirJuego()
    {
        Application.Quit();
    }
    
    
}
