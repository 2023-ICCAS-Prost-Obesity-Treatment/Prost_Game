using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UserManager : MonoBehaviour
{
    public long userScore;
    public long dietPoint;
    public long stepPoint;
    public Dictionary<int, string> buyedItem=new Dictionary<int, string>() ;
    
    // Awake is called when the script instance is being loaded
    
    public static UserManager Instance;

    private void Awake()
    {
        
        if(Instance !=null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

}
