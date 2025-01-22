using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_23 : MonoBehaviour
    {
        public void RetryClicked()
        {
            //SceneManager.LoadScene(23);
            //Time.timeScale = 1;
            SceneManager.LoadScene("green_custom");
        }
    }
}