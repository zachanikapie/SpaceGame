using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    // Method to return to the main menu
    public void ReturnMenuTrigger()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
 


