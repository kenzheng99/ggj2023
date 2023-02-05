using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskList : MonoBehaviour
{
    public Text tasks;
    public GameManager gm;

    [SerializeField] public List<string> names = new List<string>(new string[] 
        {"Jason", "Jackson", "Jamie", "Johnson", "James", "Jessica"}); 
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        tasks.text = gm.Tasks;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
