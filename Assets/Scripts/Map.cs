using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[System.Serializable]
class Map
{
    private Unit[] units;
    private Building[] buildings;
    Random r = new Random();

    public Unit[] Units
    {
        get { return units; }
        set { units = value; }
    }

    public Building[] Buildings
    {
        get { return buildings; }
        set { buildings = value; }
    }

    public Map(int maxX, int maxY, int numUnits, int numBuildings) // these will create the archer and melee units and place them within the units array 
    {
        int buildingX, buildingY;
        units = new Unit[numUnits];
        buildings = new Building[numBuildings];
        for (int i = 0; i < numUnits; i++)
        {
            if (i <= 10)
            {
                MeleeUnit M = new MeleeUnit(r.Next(0, maxX), r.Next(0, maxY), r.Next(10, 20) * 10, r.Next(10, 30), 1, 1, i % 2, "M", "Knight");
                Units[i] = M;
            }
            if (i > 10 && i <= 20)
            {
                RangedUnit R = new RangedUnit(r.Next(0, maxX), r.Next(0, maxY), r.Next(10, 20) * 10, r.Next(10, 30), 1, 1, i % 2, "R", "Archer");
                Units[i] = R;
            }
            if (i == 21)
            {
                WizardUnit W = new WizardUnit(r.Next(0, maxX), r.Next(0, maxY), r.Next(25, 35) * 10, r.Next(20, 40), 1, 1, 0, "W", "Wizard");
                Units[i] = W;
            }
            if (i == 22)
            {
                WizardUnit W = new WizardUnit(r.Next(0, maxX), r.Next(0, maxY), r.Next(25, 35) * 10, r.Next(20, 40), 1, 1, 1, "W", "Wizard");
                Units[i] = W;
            }
            if (i > 22 && i <= 27)
            {
                MeleeUnit MN = new MeleeUnit(r.Next(0, maxX), r.Next(0, maxY), r.Next(10, 20) * 10, r.Next(10, 30), 1, 1, 2, "M", "Knight");
                Units[i] = MN;
            }
            if (i > 27)
            {
                RangedUnit RN = new RangedUnit(r.Next(0, maxX), r.Next(0, maxY), r.Next(10, 20) * 10, r.Next(10, 30), 1, 1, 2, "R", "Archer");
                Units[i] = RN;
            }
        }

        for (int i = 0; i < numBuildings; i++) // these will create the buildings that will then be put into the buildings array 
        {
            if (i <= 5)
            {
                buildingX = r.Next(0, maxX);
                buildingY = r.Next(0, maxX);
                FactoryBuilding fb = new FactoryBuilding(buildingX, r.Next(0, maxY), r.Next(5, 10) * 10, i % 2, "FB", r.Next(0, 1), r.Next(5, 10), buildingX + 1, buildingY + 1);
                Buildings[i] = fb;
            }

            if (i > 5 && i <= 10)
            {
                ResourceBuilding rb = new ResourceBuilding(r.Next(0, maxX), r.Next(0, maxY), r.Next(5, 10) * 10, i % 2, "RB", "Gold", r.Next(5, 15), r.Next(100, 400));
                Buildings[i] = rb;
            }
        }
    }
}

