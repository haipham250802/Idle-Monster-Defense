using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpgrade : MonoBehaviour
{
    [SerializeField] private Text damageTxt;
    [SerializeField] private Text hpTxt;
    [FoldoutGroup("STAT")]
    [SerializeField] float rangeAttack;
    [FoldoutGroup("STAT")]
    [SerializeField] float rangeHitEnemy;
    [FoldoutGroup("STAT")]
    [SerializeField] float fireRate;
    [FoldoutGroup("STAT")]
    [SerializeField] float damage;
    [FoldoutGroup("STAT")]
    [SerializeField] float hp;

    [SerializeField] private List<UpgradeBase> listUpgradeBase;


    public float DamageStart = 0;
    public float HpStart = 0;
    public float AttackSpeedStart = 0;
    public float RangeAttackStart = 0;

    public int indexUpradeDamage;
    public int indexUpradeHp;
    public int indexUpradeRangeAttack;
    public int indexUpradeAttackSpeed;
    public float Damage => damage;
    public float AttackSpeed => fireRate;
    public float HP => hp;
    public float RangeAttack => rangeAttack;

    private void Start()
    {
        initIndexStat();
        initValueStatBase();
        initStatTurrent();
        initTextDamage();
        initTextHp();
    }
    public void OnStart()
    {
        initIndexStat();
        initValueStatBase();
        initStatTurrent();
        initTextDamage();
        initTextHp();
        ElementUpgradeOnStart();
    }
    private void ElementUpgradeOnStart()
    {
        foreach (UpgradeBase item in listUpgradeBase)
        {
            item.OnStart();
        }
    }
    private void initIndexStat()
    {
        indexUpradeDamage = DataController.Ins.DataPlayer.GetIndexUpgradeDamage();
        indexUpradeHp = DataController.Ins.DataPlayer.GetIndexUpgradeHP();
        indexUpradeAttackSpeed = DataController.Ins.DataPlayer.GetIndexUpgradeAttackSpeedPlayer();
        indexUpradeRangeAttack = DataController.Ins.DataPlayer.GetIndexUpgradeRangeAttackPlayer();
    }
    private void initValueStatBase()
    {
        DamageStart = DataController.Ins.DataSOController.DataSOPlayer.Player.Damage;
        HpStart = DataController.Ins.DataSOController.DataSOPlayer.Player.Hp;
        AttackSpeedStart = DataController.Ins.DataSOController.DataSOPlayer.Player.AttackSpeed;
        RangeAttackStart = DataController.Ins.DataSOController.DataSOPlayer.Player.RangeAttack;
    }
    private void initStatTurrent()
    {
        SetDamage(indexUpradeDamage);
        SetHp(indexUpradeHp);
        SetRangeAttack(indexUpradeRangeAttack);
        SetAttackSpeed(indexUpradeAttackSpeed);
    }
    private void initTextDamage()
    {
        damageTxt.text = damage.ToString();
    }
    private void initTextHp()
    {
        hpTxt.text = hp.ToString();
    }
    public void SetDamage(int index, float initBase = 1.1f, float value = 0.5f)
    {
        damage = CalculateStat(DamageStart, initBase, index, value);
    }
    public float GetNewDamage()
    {
        return CalculateStat(DamageStart, 1.1f, indexUpradeDamage + 1, 0.5f);
    }
    public void SetHp(int index, float initBase = 8f, float value = 2f)
    {
        hp = CalculateStat(HpStart, initBase, index, value);
    }
    public float GetNewHp()
    {
        return CalculateStat(HpStart, 8f, indexUpradeHp + 1, 2f);
    }
    public void SetRangeAttack(int index, float initBase = 0.4f, float value = 0.5f)
    {
        rangeAttack = CalculateStat(RangeAttackStart, initBase, index, value);
    }
    public float GetNewRangeAttack()
    {
        return CalculateStat(RangeAttackStart, 0.4f, indexUpradeRangeAttack + 1, 0.5f);
    }
    public void SetAttackSpeed(int index, float value = 0.5f)
    {
        fireRate = CalculateAttackSpeed(AttackSpeedStart, index, value);
    }
    public float GetNewAttackSpeed()
    {
        return CalculateAttackSpeed(AttackSpeedStart, indexUpradeAttackSpeed + 1, 0.5f);
    }
    public float CalculateAttackSpeed(float start, int index, float value)
    {
        float result = start - ((start * index * value) / 5);
        return result;
    }
    public float CalculateStat(float start, float init, int index, float value)
    {
        float result = start + index * (2 * init + value * (index + 1) - 2 * value) / 5;
        return result;
    }
    public int GetGoldUpgrade(int index, E_TypeUpgrade typeUpgrade)
    {
        switch (typeUpgrade)
        {
            case E_TypeUpgrade.NONE:
                break;
            case E_TypeUpgrade.DAMAGE:
                return index * 3 + ((index * 4) / 2);
            case E_TypeUpgrade.HP:
                return index * 2 + ((index * 3) / 2);
            case E_TypeUpgrade.RANGE_ATTACK:
                return index * 15 + ((index * 5) / 2);
            case E_TypeUpgrade.ATTACK_SPEED:
                return index * 5 + ((index * 3) / 2);
            default:
                break;
        }
        return 0;
    }
}
