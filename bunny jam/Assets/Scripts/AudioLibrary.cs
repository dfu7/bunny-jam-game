using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLibrary : MonoBehaviour
{
    public static AudioLibrary S_library { get; private set; }
    [SerializeField] public AudioClip BunnyTransform;
    [SerializeField] public AudioClip GrassLand;
    [SerializeField] public AudioClip GrassWalk;
    [SerializeField] public AudioClip Jump;
    [SerializeField] public AudioClip MStage0;
    [SerializeField] public AudioClip MStage1;
    [SerializeField] public AudioClip MStage2;
    [SerializeField] public AudioClip RabbitDeath;
    [SerializeField] public AudioClip Rain;
    [SerializeField] public AudioClip SludgeLand;
    [SerializeField] public AudioClip SludgeWalk;
    [SerializeField] public AudioClip StoneLand;
    [SerializeField] public AudioClip StoneWalk;
    [SerializeField] public AudioClip WoodLand;
    [SerializeField] public AudioClip WoodWalk;

    public void BunnyTransformPlay(AudioSource AS)
    {
        AS.PlayOneShot(BunnyTransform);
    }

    public void GrassLandPlay(AudioSource AS)
    {
        AS.PlayOneShot(GrassLand);
    }

    public void GrassWalkPlay(AudioSource AS)
    {
        AS.PlayOneShot(GrassWalk);
    }

    public void JumpPlay(AudioSource AS)
    {
        AS.PlayOneShot(Jump);
    }

    public void MStage0Play (AudioSource AS)
    {
        AS.PlayOneShot(MStage0, 0.9f);
    }

    public void MStage1Play(AudioSource AS)
    {
        AS.PlayOneShot(MStage1);
    }

    public void MStage2Play(AudioSource AS)
    {
        AS.PlayOneShot(MStage2);
    }

    public void RabbitDeathPlay(AudioSource AS)
    {
        AS.PlayOneShot(RabbitDeath);
    }

    public void RainPLay(AudioSource AS)
    {
        AS.PlayOneShot(Rain);
    }

    public void SludgeLandPlay(AudioSource AS)
    {
        AS.PlayOneShot(SludgeLand);
    }

    public void SludgeWalkPlay(AudioSource AS)
    {
        AS.PlayOneShot(SludgeWalk);
    }

    public void StoneLandPlay(AudioSource AS)
    {
        AS.PlayOneShot(StoneLand);
    }

    public void StoneWalkPlay(AudioSource AS)
    {
        AS.PlayOneShot(StoneWalk);
    }

    public void WoodLandPlay(AudioSource AS)
    {
        AS.PlayOneShot(WoodLand);
    }

    public void WoodWalkPlay(AudioSource AS)
    {
        AS.PlayOneShot(WoodWalk);
    }
}
