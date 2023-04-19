using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{

    [SerializeField] private AudioSource music1 = null;
    [SerializeField] private AudioSource music2 = null;
    [SerializeField] private AudioSource music3 = null;
    int rng=-1, oldrng=-1;




    // Start is called before the first frame update
    void Start()
    {
       {

      }
    }

    // Update is called once per frame
    void Update()
    {
      if (music1 != null && music2 != null && music3 != null) {
        if (!music1.isPlaying && !music2.isPlaying && !music3.isPlaying) {
          PlayRandomSong();
        }
      }
      else if (music1 != null && !music1.isPlaying){
        music1.Play();
      }
    }

    public void PlayRandomSong() {
      oldrng = rng;
      rng = Random.Range(0, 3);
      if (rng != oldrng) {
        if (rng == 0) {
          music1.Play();
        }
        else if (rng == 1) {
          music2.Play();
        }
        else if (rng == 2) {
          music3.Play();
        }
      }

    }
}
