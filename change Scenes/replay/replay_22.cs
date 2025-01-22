using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_22 : MonoBehaviour
    {
        public void RetryClicked()
        {
            //SceneManager.LoadScene(22);
            //Time.timeScale = 1;
            SceneManager.LoadScene("green_advance");
        }
    }
}