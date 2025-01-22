using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_18 : MonoBehaviour
    {
        public void RetryClicked()
        {
            //SceneManager.LoadScene(18);
            //Time.timeScale = 1;
            SceneManager.LoadScene("DesertRunLvl1_custom");
        }
    }
}

