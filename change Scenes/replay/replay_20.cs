using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_20 : MonoBehaviour
    {
        public void RetryClicked()
        {
            //SceneManager.LoadScene(20);
            //Time.timeScale = 1;
            SceneManager.LoadScene("DesertRunLvl1_hard");
        }
    }
}