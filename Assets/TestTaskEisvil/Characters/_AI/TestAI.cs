using System;
using System.Collections;
using System.Collections.Generic;
using TestTaskEisvil._Level;
using TestTaskEisvil.Characters._AI;
using UnityEngine;

public class TestAI : MonoBehaviour
{
  [SerializeField] private Monster monster;
  [SerializeField] private MonsterData _monsterData;
  [SerializeField] private Level _level;
  [SerializeField] private float delay = 10f;
  private IEnumerator Start()
  {
      yield return new WaitForSeconds(delay);
      monster.Init(_monsterData, _level);
  }
}
