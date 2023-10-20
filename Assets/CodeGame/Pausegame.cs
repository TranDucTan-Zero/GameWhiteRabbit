
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pausegame : MonoBehaviour
{

    public GameObject menupause;
    public void Tamdunggame()
    {
        Time.timeScale = 0f;
       menupause.SetActive(true);
    }
    public void tieptucgame()
    {

        Time.timeScale = 1f;
        menupause.SetActive(false);
        
    }
    public void thoatgame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SelcetLevel");
    }
}
