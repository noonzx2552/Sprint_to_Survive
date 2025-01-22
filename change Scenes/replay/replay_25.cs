using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_25 : MonoBehaviour
    {
        public void RetryClicked()
        {
            //SceneManager.LoadScene(25);
            //Time.timeScale = 1;
            SceneManager.LoadScene("green_hard");
        }
    }
}