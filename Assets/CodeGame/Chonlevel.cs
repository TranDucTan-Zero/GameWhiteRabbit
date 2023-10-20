using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chonlevel : MonoBehaviour
{
    [SerializeField] public int level;

    void Start()
    {

    }
   

    public void moLevel()
    {
        SceneManager.LoadScene("Level" + level.ToString());
    }
}
