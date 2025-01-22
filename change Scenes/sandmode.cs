using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class sandmode : MonoBehaviour
    {

        public void gotosand()
        {
            SceneManager.LoadScene("selectmode-sand");
        }
    }
}