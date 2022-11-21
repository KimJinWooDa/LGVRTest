using UnityEngine;

public class Youtuber : Singleton<Youtuber>
{
    public Transform youtuber;
    
    public void Donation()
    {
        int RandomAnimation = Random.Range(0, 2);
        switch (RandomAnimation)
        {
            case 0:
                youtuber.GetComponent<Animator>().SetTrigger("Thank");
                break;
            case 1:
                youtuber.GetComponent<Animator>().SetTrigger("Dance");
                break;
        }
    }
    
    public void Happy() //그림메모 받았을 때
    {
        youtuber.GetComponent<Animator>().SetTrigger("Thank"); 
    }

}
