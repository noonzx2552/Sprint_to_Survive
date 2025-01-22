using UnityEngine;
using UnityEngine.SceneManagement;
public class replay_11 : MonoBehaviour
{
    // Start is called before the first frame update
    public void RetryClicked()
    {
        //SceneManager.LoadScene(11);
        //Time.timeScale = 1;
        SceneManager.LoadScene("green_easy_timmy");
    }
}
