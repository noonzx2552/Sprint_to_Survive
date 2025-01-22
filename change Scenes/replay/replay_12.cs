using UnityEngine;
using UnityEngine.SceneManagement;

public class replay_12 : MonoBehaviour
{
    // Start is called before the first frame update
    public void RetryClicked()
    {
        //SceneManager.LoadScene(12);
        //Time.timeScale = 1;
        SceneManager.LoadScene("green_advance_timmy");
    }
}
