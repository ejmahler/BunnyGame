using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance = null;
    public static AudioManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = ((GameObject)Instantiate(Resources.Load("Prefabs/AudioManager"))).GetComponent<AudioManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    [SerializeField]
    private AudioClip[] screamClips;

    [SerializeField]
    private AudioClip[] attackClips;

    [SerializeField]
    private AudioClip[] spawnClips;

    [SerializeField]
    private AudioClip[] monsterDieClips;

    private float lastScreamEffectTime = -1f;
    private float lastAttackEffectTime = -1f;

    public void BunnyScream()
    {
        if (Time.time > lastScreamEffectTime + 0.5f)
        {
            int random = Random.Range(0, screamClips.Length);
            AudioClip clip = screamClips[random];
            GetComponent<AudioSource>().PlayOneShot(clip);
            lastScreamEffectTime = Time.time;
        }
    }

    public void AttackSound()
    {
        if (Time.time > lastAttackEffectTime + 0.5f)
        {
            int random = Random.Range(0, attackClips.Length);
            AudioClip clip = attackClips[random];
            GetComponent<AudioSource>().PlayOneShot(clip);
            lastAttackEffectTime = Time.time;
        }
    }

    public void SpawnSound()
    {
        int random = Random.Range(0, spawnClips.Length);
        AudioClip clip = spawnClips[random];
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    public void MonsterDieSound()
    {
        int random = Random.Range(0, monsterDieClips.Length);
        AudioClip clip = monsterDieClips[random];
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
