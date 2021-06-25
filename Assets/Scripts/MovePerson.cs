using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class MovePerson : MonoBehaviour
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
        if (Input.GetKey("escape"))
            Application.Quit();


        float mV = Input.GetAxis("Horizontal");


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

        if (Input.GetKey(KeyCode.G))
        {
            if (!m_Source.isPlaying) m_Source.clip = audios[Random.Range(0, audios.Count)]; m_Source.Play();
            anim.SetBool("AttackKickL1", true);
        }
        if (Input.GetKey(KeyCode.H))
        {
            if (!m_Source.isPlaying) m_Source.clip = audios[Random.Range(0, audios.Count)]; m_Source.Play();
            anim.SetBool("AttackKickR1", true);
        }
        if (Input.GetKey(KeyCode.J))
        {
            if (!m_Source.isPlaying) m_Source.clip = audios[Random.Range(0, audios.Count)]; m_Source.Play();
            anim.SetBool("AttackR1", true);
        }
        if (Input.GetKey(KeyCode.K))
        {
            if (!m_Source.isPlaying) m_Source.clip = audios[Random.Range(0, audios.Count)]; m_Source.Play();
            anim.SetBool("AttackR2", true);
        }

        if (CommunPerso.life1 <= 0)
        {
            anim.SetBool("Death", true);
        }

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

        if (distance < 1) {
            CommunPerso.life2--;
        }

        if (CommunPerso.life2 <= 0)
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
        if (CommunPerso.life1 > 0)
        {
            Texture2D texture = CommunPerso.life1 > 2 ? (Resources.Load("Images/life") as Texture2D) : (Resources.Load("Images/lowlife") as Texture2D);
            GUI.DrawTextureWithTexCoords(
                new Rect(20, 20, CommunPerso.life1 * 200 / 5, 20),
                texture, new Rect(0, 0, 1, 1)
            );
        }
        else
        {
            CommunPerso.SetWinnerText("joueur n°2");
        }
    }


}
