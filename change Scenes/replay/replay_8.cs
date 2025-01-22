using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_8 : MonoBehaviour
    {
        public void RetryClicked()
        {
            //SceneManager.LoadScene(8);
            //Time.timeScale = 1;
            SceneManager.LoadScene("DesertRunLvl1_custom_timmy");
        }
    }
}
