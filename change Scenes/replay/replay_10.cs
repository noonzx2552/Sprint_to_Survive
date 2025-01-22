using UnityEngine;
using UnityEngine.SceneManagement;

public class replay_10 : MonoBehaviour
{
    // Start is called before the first frame update
    public void RetryClicked()
    {
        //SceneManager.LoadScene(10);
        //Time.timeScale = 1;
        SceneManager.LoadScene("green_normal_timmy");
    }
}
