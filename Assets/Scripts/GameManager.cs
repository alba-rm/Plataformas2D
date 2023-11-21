using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set;}
    private int vidas = 3;
    public HUD hud;
    public int PuntosTotales {get; private set;}
    
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void SumarPuntos(int puntosASumar)
    {
        PuntosTotales += puntosASumar;
        hud.Puntos(PuntosTotales);
        
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
    }
    public void PerderVida()
    {
        vidas -= 1;
        if(vidas == 0)
        {
            SceneManager.LoadScene(1);
        }
        hud.DesactivarVida(vidas);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
