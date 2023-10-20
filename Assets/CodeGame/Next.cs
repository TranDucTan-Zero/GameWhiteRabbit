using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Next : MonoBehaviour
{
    public Button nextButton;

    void Start()
    {
        nextButton.onClick.AddListener(NextButtonOnClick);
    }
    void NextButtonOnClick()
    {
        SceneManager.LoadScene("SelcetLevel");
    }
}
