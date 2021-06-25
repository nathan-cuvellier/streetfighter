using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class MovePerson2 : MonoBehaviour
{
    AudioSource m_Source;
    [SerializeField] AudioClip m_Aie;
    [SerializeField] AudioClip m_Ouch;
    [SerializeField] AudioClip m_Punch;
    [SerializeField] AudioClip m_Death;
    [SerializeField] AudioClip m_Winner;
    private List<AudioClip> audios = new List<AudioClip>();

    public Rigidbody rigidBody;
    public float speed;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        m_Source = GetComponent<AudioSource>();

        audios.Add(m_Aie);
        audios.Add(m_Ouch);
        audios.Add(m_Punch);

        if (rigidBody == null) rigidBody = GetComponent<Rigidbody>();

        if (anim == null) anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float mV = Input.GetAxis("Vertical");


        if (mV > 0 && CommunPerso.canMove)
        {
            anim.SetBool("Foreword", true);
            MovePlayer(mV);
        }
        else if (mV < 0 && CommunPerso.canMove)
        {
            anim.SetBool("Backword", true);
            MovePlayer(mV);
        }


        if (Input.GetKey(KeyCode.P))
        {
            if (!m_Source.isPlaying) m_Source.clip = audios[Random.Range(0, audios.Count)]; m_Source.Play();
            anim.SetBool("AttackKickL1", true);
        }
        if (Input.GetKey(KeyCode.O))
        {
            if (!m_Source.isPlaying) m_Source.clip = audios[Random.Range(0, audios.Count)]; m_Source.Play();
            anim.SetBool("AttackKickR1", true);
        }
        if (Input.GetKey(KeyCode.I))
        {
            if (!m_Source.isPlaying) m_Source.clip = audios[Random.Range(0, audios.Count)]; m_Source.Play();
            anim.SetBool("AttackR1", true);
        }
        if (Input.GetKey(KeyCode.U))
        {
            if (!m_Source.isPlaying) m_Source.clip = audios[Random.Range(0, audios.Count)]; m_Source.Play();
            anim.SetBool("AttackR2", true);
        }


        if (CommunPerso.life2 <= 0) anim.SetBool("Death", true);

    }

    public void EndVictory()
    {
        anim.SetBool("Victory", false);
        m_Source.clip = m_Winner;
        m_Source.Play();
    }

    public void EndForeward()
    {
        anim.SetBool("Foreword", false);
    }

    public void EndBackword()
    {
        anim.SetBool("Backword", false);
    }

    public void EndAttackKickL1()
    {
        anim.SetBool("AttackKickL1", false);
    }

    public void EndAttackKickR1()
    {
        anim.SetBool("AttackKickR1", false);
    }

    public void EndAttackR1()
    {
        anim.SetBool("AttackR1", false);
    }

    public void EndAttackR2()
    {
        anim.SetBool("AttackR2", false);
    }

    public void EndDeath()
    {
        anim.SetBool("Death", false);
    }

    public void Hit()
    {
        float distance = GameObject.FindWithTag("Perso2").transform.position.z - GameObject.FindWithTag("Perso1").transform.position.z;

        if (distance < 1)
        {
            CommunPerso.life1--;
        }

        if (CommunPerso.life1 <= 0)
        {
            CommunPerso.canMove = false;
            m_Source.clip = m_Death;
            m_Source.Play();

            anim.SetBool("Victory", true);
        }
    }

    public void MovePlayer(float coeff)
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.y, rigidBody.velocity.x, coeff * speed);
    }

    private void OnGUI()
    {
        if (CommunPerso.life2 > 0)
        {
            int width = 200;
            int widthShow = CommunPerso.life2 * 200 / 5;

            Texture2D texture = CommunPerso.life2 > 2 ? (Resources.Load("Images/life") as Texture2D) : (Resources.Load("Images/lowlife") as Texture2D);
            GUI.DrawTextureWithTexCoords(
                new Rect(Screen.width - width - 20, 20, widthShow, 20), texture, new Rect(0, 0, 1, 1));
        }
        else
        {
            CommunPerso.SetWinnerText("joueur n°1");
        }
       
    }
}
