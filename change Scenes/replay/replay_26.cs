using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_26 : MonoBehaviour
    {
        public void RetryClicked()
        {
            SceneManager.LoadScene(26);
            Time.timeScale = 1;
            SceneManager.LoadScene("green_normal");
        }
    }
}