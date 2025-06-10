using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Menu : MonoBehaviour
{
    public void StartLevel1(string Level1)
    {
        SceneManager.LoadScene(Level1);
    }

    public void LoadCredits(string credits)
    {
        SceneManager.LoadScene(credits);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Se cierra el juego");
    }
    public GameObject panelCreditos;
    public GameObject panelMenu;

    public void ShowCredits()
    {
    panelCreditos.SetActive(true);
    panelMenu.SetActive(false);
    }

    public void HideCredits()
    {
    panelCreditos.SetActive(false);
    panelMenu.SetActive(true);
    }


}
