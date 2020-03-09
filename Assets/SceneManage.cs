using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      

    }
    //Funcionpara cambiar a pel juego
      public  void Chargelevel(string level)
    {
        SceneManager.LoadScene (level);
    }


      public void ChargeOptions(string options)
      {
        SceneManager.LoadScene(options);
      }
    

}
