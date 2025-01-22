using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_17 : MonoBehaviour
    {
        public void RetryClicked()
        {
            //SceneManager.LoadScene(17);
            //Time.timeScale = 1;
            SceneManager.LoadScene("DesertRunLvl1_advance");
        }
    }
}