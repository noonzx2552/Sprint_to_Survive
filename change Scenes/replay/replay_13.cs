using UnityEngine;
using UnityEngine.SceneManagement;

public class replay_13 : MonoBehaviour
{
    // Start is called before the first frame update
    public void RetryClicked()
    {
        //SceneManager.LoadScene(13);
        //Time.timeScale = 1;
        SceneManager.LoadScene("green_custom_timmy");
    }
}
