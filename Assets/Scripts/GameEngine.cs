using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameEngine : MonoBehaviour
{

    Map map;
    public GameObject RedMelee;
    public GameObject BlueMelee;
    public GameObject GreyMelee;
    public GameObject RedRanged;
    public GameObject BlueRanged;
    public GameObject GreyRanged;
    public GameObject BlueWizard;
    public GameObject RedWizard;
    public GameObject BlueFactory;
    public GameObject RedFactory;
    public GameObject BlueMine;
    public GameObject RedMine;
    public GameObject RedDeath;
    public GameObject BlueDeath;
    public GameObject NeutralDeath;

    public Text timer;
    public Text info;

    int tick = 1;

    System.Random r = new System.Random();


    void Start()
    {
        map = new Map(10, 10, 33, 10);
        DisplayMap();
    }

    void FixedUpdate()
    {
        Timer();
        UpdateMap();
        DestroyChildren();
        DisplayMap();   
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left click, casting ray.");
            castRay();
        }
    }

    public void DisplayMap()
    {
        foreach (Unit u in map.Units)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                int start_x = 20;
                int start_Y = 20;
                MeleeUnit m = (MeleeUnit)u;
                if (m.health > 0)
                {
                    if (m.faction == 1)
                    {
                        GameObject dup = Instantiate(RedMelee, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;

                    }
                    else if (m.faction == 0)
                    {
                        GameObject dup = Instantiate(BlueMelee, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;

                    }
                    else
                    {
                        GameObject dup = Instantiate(GreyMelee, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;

                    }
                }
                if (m.isDead())
                {
                    m.symbol = "X";
                    if (m.faction == 1)
                    {
                        GameObject dup = Instantiate(RedDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                    else if (m.faction == 0)
                    {
                        GameObject dup = Instantiate(BlueDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                    else
                    {
                        GameObject dup = Instantiate(NeutralDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                }
            }

        }

        foreach (Unit u in map.Units)
        {
            if (u.GetType() == typeof(RangedUnit))
            {
                int start_x = 20;
                int start_Y = 20;
                RangedUnit m = (RangedUnit)u;
                if (m.health > 0)
                {
                    if (m.faction == 1)
                    {
                        GameObject dup = Instantiate(RedRanged, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;

                    }
                    else if (m.faction == 0)
                    {
                        GameObject dup = Instantiate(BlueRanged, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;

                    }
                    else
                    {
                        GameObject dup = Instantiate(GreyRanged, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;

                    }
                }
                if (m.isDead())
                {
                    m.symbol = "X";
                    if (m.faction == 1)
                    {
                        GameObject dup = Instantiate(RedDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                    else if (m.faction == 0)
                    {
                        GameObject dup = Instantiate(BlueDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                    else
                    {
                        GameObject dup = Instantiate(NeutralDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                }
            }

        }

        foreach (Unit u in map.Units)
        {
            if (u.GetType() == typeof(WizardUnit))
            {
                int start_x = 20;
                int start_Y = 20;
                WizardUnit m = (WizardUnit)u;
                if (m.health > 0)
                {
                    if (m.faction == 1)
                    {
                        GameObject dup = Instantiate(RedWizard, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;

                    }
                    else if (m.faction == 0)
                    {
                        GameObject dup = Instantiate(BlueWizard, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;

                    }
                }
                if (m.isDead())
                {
                    m.symbol = "X";
                    if (m.faction == 1)
                    {
                        GameObject dup = Instantiate(RedDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                    else if (m.faction == 0)
                    {
                        GameObject dup = Instantiate(BlueDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                }
            }

        }

        foreach (Building u in map.Buildings)
        {
            if (u.GetType() == typeof(FactoryBuilding))
            {
                int start_x = 20;
                int start_Y = 20;
                FactoryBuilding m = (FactoryBuilding)u;
                if (m.health > 0)
                {
                    if (m.faction == 1)
                    {
                        GameObject dup = Instantiate(RedFactory, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;

                    }
                    else if (m.faction == 0)
                    {
                        GameObject dup = Instantiate(BlueFactory, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;

                    }
                }
                if (m.isDead())
                {
                    m.symbol = "X";
                    if (m.faction == 1)
                    {
                        GameObject dup = Instantiate(RedDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                    else if (m.faction == 0)
                    {
                        GameObject dup = Instantiate(BlueDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                }
            }

        }

        foreach (Building u in map.Buildings)
        {
            if (u.GetType() == typeof(ResourceBuilding))
            {
                int start_x = 20;
                int start_Y = 20;
                ResourceBuilding m = (ResourceBuilding)u;
                if (m.health > 0)
                {
                    if (m.faction == 1)
                    {
                        GameObject dup = Instantiate(RedMine, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;

                    }
                    else if (m.faction == 0)
                    {
                        GameObject dup = Instantiate(BlueMine, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;

                    }
                }
                if (m.isDead())
                {
                    m.symbol = "X";
                    if (m.faction == 1)
                    {
                        GameObject dup = Instantiate(RedDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                    else if (m.faction == 0)
                    {
                        GameObject dup = Instantiate(BlueDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                }
            }
        }
    }

    private void UpdateMap() // this will cycle through all the units and buildisngs to see if they need to move and whether or not they have been killed in combat
    {
        foreach (Unit u in map.Units)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit m = (MeleeUnit)u;
                if (m.health > 1)
                {
                    if (m.health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: ((MeleeUnit)u).NewPos(Direction.North); break;
                            case 1: ((MeleeUnit)u).NewPos(Direction.East); break;
                            case 2: ((MeleeUnit)u).NewPos(Direction.South); break;
                            case 3: ((MeleeUnit)u).NewPos(Direction.West); break;
                        }
                    }
                    else if (m.health < 10)  // this method will check a units health to see if it below 10 and if it is there will be a 50% chance of that unit changing alleigance to the other team and the unit will gain a small amount of health as compensation for changing team
                    {
                        int teamChange = r.Next(0, 2);
                        if (teamChange == 0)
                        {
                            if (m.faction == 1)
                            {
                                m.faction = 0;
                                m.health = m.health + 5;
                            }
                            else
                            {
                                m.faction = 1;
                                m.health = m.health + 5;
                            }
                        }
                    }
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {
                            if (u.withinAttackRange(e))
                            {
                                u.combatWithUnit(e);
                                inCombat = true;
                            }
                        }
                        if (!inCombat)
                        {
                            Unit c = u.UnitDistance(map.Units);
                            m.NewPos(m.Directionto(c));
                        }
                    }
                }
                else
                {
                    m.symbol = "X";
                    if (m.faction == 1)
                    {
                        GameObject dup = Instantiate(RedDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                    else if (m.faction == 0)
                    {
                        GameObject dup = Instantiate(BlueDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                    else
                    {
                        GameObject dup = Instantiate(NeutralDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                }
            }


        }
        foreach (Unit u in map.Units)
        {
            if (u.GetType() == typeof(RangedUnit))
            {
                RangedUnit m = (RangedUnit)u;
                if (m.health > 1)
                {
                    if (m.health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: ((RangedUnit)u).NewPos(Direction.North); break;
                            case 1: ((RangedUnit)u).NewPos(Direction.East); break;
                            case 2: ((RangedUnit)u).NewPos(Direction.South); break;
                            case 3: ((RangedUnit)u).NewPos(Direction.West); break;
                        }
                    }
                    else if (m.health < 10)  // this method will check a units health to see if it below 10 and if it is there will be a 50% chance of that unit changing alleigance to the other team and the unit will gain a small amount of health as compensation for changing team
                    {
                        int teamChange = r.Next(0, 2);
                        if (teamChange == 0)
                        {
                            if (m.faction == 1)
                            {
                                m.faction = 0;
                                m.health = m.health + 5;
                            }
                            else
                            {
                                m.faction = 1;
                                m.health = m.health + 5;
                            }
                        }
                    }
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {
                            if (u.withinAttackRange(e))
                            {
                                u.combatWithUnit(e);
                                inCombat = true;
                            }
                        }
                        if (!inCombat)
                        {
                            Unit c = u.UnitDistance(map.Units);
                            m.NewPos(m.Directionto(c));
                        }
                    }
                }
                else
                {
                    m.symbol = "X";

                    if (m.faction == 1)
                    {
                        GameObject dup = Instantiate(RedDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                    else if (m.faction == 0)
                    {
                        GameObject dup = Instantiate(BlueDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                    else
                    {
                        GameObject dup = Instantiate(NeutralDeath, new Vector2(m.Xpos, m.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                }
            }
        }

        foreach (Unit u in map.Units)
        {
            if (u.GetType() == typeof(WizardUnit))
            {
                WizardUnit w = (WizardUnit)u;
                if (w.health > 1)
                {
                    if (w.health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: ((WizardUnit)u).NewPos(Direction.North); break;
                            case 1: ((WizardUnit)u).NewPos(Direction.East); break;
                            case 2: ((WizardUnit)u).NewPos(Direction.South); break;
                            case 3: ((WizardUnit)u).NewPos(Direction.West); break;
                        }
                    }

                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {
                            if (u.withinAttackRange(e))
                            {
                                u.combatWithUnit(e);
                                inCombat = true;
                            }
                        }
                        if (!inCombat)
                        {
                            Unit c = u.UnitDistance(map.Units);
                            w.NewPos(w.Directionto(c));
                        }
                    }
                }
                else
                {
                    w.symbol = "X";
                    if (w.faction == 1)
                    {
                        GameObject dup = Instantiate(RedDeath, new Vector2(w.Xpos, w.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                    else if (w.faction == 0)
                    {
                        GameObject dup = Instantiate(BlueDeath, new Vector2(w.Xpos, w.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                    else
                    {
                        GameObject dup = Instantiate(NeutralDeath, new Vector2(w.Xpos, w.Ypos), Quaternion.identity);
                        dup.transform.parent = transform;
                    }
                }
            }
        }

        foreach (Building b in map.Buildings)
        {
            if (b.GetType() == typeof(ResourceBuilding))
            {
                ResourceBuilding rb = (ResourceBuilding)b;
                rb.ResourceGenerate();
            }
        }

        foreach (Building b in map.Buildings)
        {
            if (b.GetType() == typeof(FactoryBuilding))
            {
                FactoryBuilding fb = (FactoryBuilding)b;
            }
        }
        #region SpawningOfUnits   
        foreach (Unit u in map.Units)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit mu = (MeleeUnit)u;
                if (mu.symbol == "X")
                {
                    int faction = mu.faction;
                    int rand = r.Next(0, 5);
                    FactoryBuilding fb = (FactoryBuilding)map.Buildings[rand];
                    fb.Spawner(20, 20, faction);
                }
            }
        }

        foreach (Unit u in map.Units)
        {
            if (u.GetType() == typeof(RangedUnit))
            {
                RangedUnit mu = (RangedUnit)u;
                if (mu.symbol == "X")
                {
                    int faction = mu.faction;
                    int rand = r.Next(0, 5);
                    FactoryBuilding fb = (FactoryBuilding)map.Buildings[rand];
                    fb.Spawner(20, 20, faction);
                }
            }
        }
        #endregion
    }

    public void btnSave_Click()  // when clicked this button will save the game
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fsout = new FileStream("GameSave.bat", FileMode.Create, FileAccess.Write, FileShare.None);

            using (fsout)
            {
                bf.Serialize(fsout, map);
            }
    }

    public void btnLoad_Click()// this button will load the previously saved game
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fsin = new FileStream("GameSave.bat", FileMode.Open, FileAccess.Read, FileShare.None);

      
            using (fsin)
            {
                map = (Map)bf.Deserialize(fsin);
            }
        DestroyChildren();
        UpdateMap();
        DisplayMap();
    }

    public void DestroyChildren()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void Timer()
    {
        timer.text = "" + tick;
        tick++;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnPauseGAme()
    {
        Time.timeScale = 1;
    }

    public void castRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if(hit)
        {
            float x = hit.collider.transform.position.x;
            float y = hit.collider.transform.position.y;


            Debug.Log("" + x + " " + y);

            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(RangedUnit))
                {
                    RangedUnit r = (RangedUnit)u;

                    if (r.Xpos == x && r.Ypos == y)
                    {
                        info.text = "" + r.toString();
                    }
                }

                else if (u.GetType() == typeof(MeleeUnit))
                {
                    MeleeUnit m = (MeleeUnit)u;

                    if (m.Xpos == x && m.Ypos == y)
                    {
                        info.text = "" + m.toString();
                    }
                }

                else if (u.GetType() == typeof(WizardUnit))
                {
                    WizardUnit m = (WizardUnit)u;

                    if (m.Xpos == x && m.Ypos == y)
                    {
                        info.text = "" + m.toString();
                    }
                }
            }

            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(FactoryBuilding))
                {
                    FactoryBuilding fb = (FactoryBuilding)b;

                    if (fb.Xpos == x && fb.Ypos == y)
                    {
                        info.text = "" + fb.toString();
                    }
                }

                else if (b.GetType() == typeof(ResourceBuilding))
                {
                    ResourceBuilding rb = (ResourceBuilding)b;

                    if (rb.Xpos == x && rb.Ypos == y)
                    {
                        info.text = "" + rb.toString();
                    }
                }
            }

        }
    }
}
