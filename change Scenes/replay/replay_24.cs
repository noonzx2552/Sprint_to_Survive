using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_24 : MonoBehaviour
    {
        public void RetryClicked()
        {
            //SceneManager.LoadScene(24);
            //Time.timeScale = 1;
            SceneManager.LoadScene("green_easy");
        }
    }
}