using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class back_selectmap : MonoBehaviour
    {
        public void Gotoselectmenu()
        {
            SceneManager.LoadScene("selectmap");
        }
    }

}
