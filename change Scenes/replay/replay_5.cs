using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_5  : MonoBehaviour
    {
        public void RetryClicked()
        {
            //SceneManager.LoadScene(5);
            //Time.timeScale = 1;
            SceneManager.LoadScene("DesertRunLvl1_normal_timmy");
        }
    }
}
