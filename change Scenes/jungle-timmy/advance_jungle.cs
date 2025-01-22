using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class advance_jungle : MonoBehaviour
    {
        public void Gonadvance()
        {
            SceneManager.LoadScene("green_advance");
        }
    }
}
