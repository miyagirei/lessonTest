using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]CharacterStatus _player;
    [SerializeField]CharacterStatus _enemy;

    float _damage;

    [SerializeField] Slider _hpSlider;
    [SerializeField] Text _levelText;

    /// <summary>
    /// testSave
    /// </summary>
    public void SavePlayerData()
    {
        PlayerPrefs.SetFloat(PlayerPrefsKey.playerLevel, _player.Level);
        PlayerPrefs.SetFloat(PlayerPrefsKey.playerHP, _player.In_HP);
        PlayerPrefs.SetFloat(PlayerPrefsKey.playerATK, _player.ATK);
        PlayerPrefs.SetFloat(PlayerPrefsKey.playerVIT, _player.VIT);
        PlayerPrefs.SetFloat(PlayerPrefsKey.playerAGI, _player.AGI);
        PlayerPrefs.SetFloat(PlayerPrefsKey.playerEXP, _player.In_EXP);
        PlayerPrefs.SetFloat(PlayerPrefsKey.playerSP, _player.SP);
        PlayerPrefs.Save();
    }
    void LoadPlayerData()
    {
        _player.Level = PlayerPrefs.GetFloat(PlayerPrefsKey.playerLevel);
        _player.In_HP = PlayerPrefs.GetFloat(PlayerPrefsKey.playerHP);
        _player.ATK = PlayerPrefs.GetFloat(PlayerPrefsKey.playerATK);
        _player.VIT = PlayerPrefs.GetFloat(PlayerPrefsKey.playerVIT);
        _player.AGI = PlayerPrefs.GetFloat(PlayerPrefsKey.playerAGI);
        _player.In_EXP = PlayerPrefs.GetFloat(PlayerPrefsKey.playerEXP);
        _player.SP = PlayerPrefs.GetFloat(PlayerPrefsKey.playerSP);
    }
    void Start()
    {
        LoadPlayerData();
        _enemy.In_HP = _enemy.HP;
        _player.In_HP = _player.HP;

        _hpSlider.maxValue = _player.In_HP;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PhysicsAttack();
        }
        LevelUp();

        _hpSlider.value = _player.HP;
        _levelText.text = _player.Level.ToString();
    }

    void PhysicsAttack()
    {
        if(_player.ATK > _enemy.VIT)
        {
            _damage = _player.ATK - _enemy.VIT;
        }
        else
        {
            print("ƒ_ƒ[ƒW‚ª“ü‚ç‚È‚¢!!");
        }
        
        if(_enemy.HP > _damage)
        {
            _enemy.HP -= _damage;
        }
        else if(_enemy.HP <= _damage)
        {
            DeathProcessing();
        }
        
    }

    void DeathProcessing()
    {
        _enemy.HP = _enemy.In_HP;
        _player.EXP += _enemy.EXP;
    }

    void LevelUp()
    {
        if(_player.EXP >= _player.Level * _player.Level)
        {
            _player.Level += 1;
            _player.SP += 1;
            _player.EXP = 0;
        }
    }
}
