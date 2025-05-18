using System;
using System.Collections;
using System.Collections.Generic;
using ScarFramework.Button;
using TestTaskEisvil._Level;
using TestTaskEisvil.Characters._AI;
using TestTaskEisvil.Characters._AI._Components;
using TestTaskEisvil.Characters._AI._Components.States;
using UnityEngine;

public class TestAI : MonoBehaviour
{
  [SerializeField] private Monster monster;
  [SerializeField] private AIStateController stateController;
  [SerializeField] private MonsterData _monsterData;
  [SerializeField] private Level _level;
  [SerializeField] private float delay = 10f;
  [SerializeField] private AiStateID aiStateID;
  private IEnumerator Start()
  {
      monster.Init(_monsterData, _level);
      stateController = monster.GetComponentInChildren<AIStateController>();
      yield return new WaitForSeconds(delay);
      monster.OnSpawn();
  }

  [Button("Set State Forced")]
  public void SetStateForced()
  {
      stateController.SetState(aiStateID);
  }

  [Button("Reset Monster")]
  public void ResetMonster()
  {
      monster.Reset();
  }
}
