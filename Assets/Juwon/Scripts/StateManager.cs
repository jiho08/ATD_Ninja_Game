using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private Mugunghwa _mugung;


}

public class Mugunghwa
{
    public float health = 10f; //체력
    public float speed = 10f; //속도
    public float atk = 20f; //공격력
    public float coolTime = 10f; //쿨타임
}
