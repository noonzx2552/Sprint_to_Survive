using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_4 : MonoBehaviour
    {
        public void RetryClicked()
        {
            //SceneManager.LoadScene(4);
            //Time.timeScale = 1;
            SceneManager.LoadScene("DesertRunLvl1_easy_timmy");
        }
    }
}
