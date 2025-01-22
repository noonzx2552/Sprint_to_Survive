using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_6 : MonoBehaviour
    {
        public void RetryClicked()
        {
            //SceneManager.LoadScene(6);
            //Time.timeScale = 1;
            SceneManager.LoadScene("DesertRunLvl1_hard_timmy");
        }
    }
}
