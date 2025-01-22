using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class ChangeScenes : MonoBehaviour
    {
        public void GotoSceneTwo()
        {
            SceneManager.LoadScene("selectmap");
        }
    }
}
