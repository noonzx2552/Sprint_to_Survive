using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_19 : MonoBehaviour
    {
        public void RetryClicked()
        {
            //SceneManager.LoadScene(19);
            //Time.timeScale = 1;
            SceneManager.LoadScene("DesertRunLvl1_easy");
        }
    }
}