using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class junglemode : MonoBehaviour
    {

        public void gotojungle()
        {
            SceneManager.LoadScene("selectmode-jungle");
        }
    }
}