using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_7 : MonoBehaviour
    {
        public void RetryClicked()
        {
            //SceneManager.LoadScene(7);
            //Time.timeScale = 1;
            SceneManager.LoadScene("DesertRunLvl1_advance_timmy");
        }
    }
}
