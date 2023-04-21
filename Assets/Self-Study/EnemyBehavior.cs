using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] CharacterStatus _player;
    [SerializeField] CharacterStatus _enemy;

    float _damage;

    float _completeAttack = 10000;
    [SerializeField]float _attack;

    [SerializeField] Slider _attackSpeedSlider;
    [SerializeField] Slider _hpSlider;
    private void Start()
    {
        _enemy.In_HP = _enemy.HP;
        _attackSpeedSlider.maxValue = _completeAttack;
        _hpSlider.maxValue = _enemy.In_HP;
    }
    private void Update()
    {
        _attack += _enemy.AGI;
        if (_completeAttack < _attack)
        {
            AutoAttack();
            _attack = 0;
            
        }

        _attackSpeedSlider.value = _attack;
        _hpSlider.value = _enemy.HP;
    }

    void AutoAttack()
    {
        if (_enemy.ATK > _player.VIT)
        {
            _damage = _enemy.ATK - _player.VIT;
        }
        else
        {
            print("É_ÉÅÅ[ÉWÇéÛÇØÇ»Ç©Ç¡ÇΩ!!");
        }

        _player.HP -= _damage;
    }
}
