using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[System.Serializable]
class WizardUnit : Unit
    {
        public int Xpos
        {
            get { return xPos; }
            set { xPos = value; }
        }

        public int Ypos
        {
            get { return yPos; }
            set { yPos = value; }
        }

        public int health
        {
            get { return Health; }
            set { Health = value; }
        }

        public int speed
        {
            get { return Speed; }
            set { Speed = value; }
        }

        public int attack
        {
            get { return Attack; }
            set { Attack = value; }
        }

        public int attackRange
        {
            get { return AttackRange; }
            set { AttackRange = value; }
        }

        public int faction
        {
            get { return Faction; }
            set { Faction = value; }
        }

        public string symbol
        {
            get { return Symbol; }
            set { Symbol = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public WizardUnit(int X_position, int Y_position, int Health, int Attack, int Speed, int Attack_range, int Faction1, string Symbol1, string name1) // thos is the wizard constrctor
        {
            Xpos = X_position;
            Ypos = Y_position;
            health = Health;
            attack = Attack;
            speed = Speed;
            attackRange = Attack_range;
            faction = Faction1;
            symbol = Symbol1;
            name = name1;
        }

        public override bool withinAttackRange(Unit u) // this will see what enemies are in attack range
        {
            if (u.GetType() == typeof(WizardUnit))
            {
                WizardUnit W = (WizardUnit)u;
                if (DistanceTo(u) <= attackRange)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public override void NewPos(Direction direction) // this will get the new position for the unit to move to 
        {
            switch (direction)
            {
                case Direction.North:
                    {
                        Ypos -= Speed;
                        break;
                    }
                case Direction.East:
                    {
                        Xpos += Speed;
                        break;
                    }
                case Direction.South:
                    {
                        Ypos += Speed;
                        break;
                    }
                case Direction.West:
                    {
                        Xpos -= Speed;
                        break;
                    }
            }
        }

        public override void combatWithUnit(Unit u) // this is the combat with units where it will decrease the enemies health from this units attack damage
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                ((MeleeUnit)u).health -= ((MeleeUnit)u).attack;
            }
            else if (u.GetType() == typeof(RangedUnit))
            {
                ((RangedUnit)u).health -= ((RangedUnit)u).attack;
            }
            else if (u.GetType() == typeof(WizardUnit))
            {
                ((WizardUnit)u).health -= ((WizardUnit)u).attack;
            }
        }
        public override bool isDead() // this will return true if the units health drops below 1
        {
            if (Health < 1)
            {
                return true;
            }
            else

                return false;
        }

        public override Unit UnitDistance(Unit[] units) // this will calculate the distance between this unit and the nemy unit
        {
            Unit closest = this;
            int closestDist = 50;
            foreach (Unit u in units)
            {
                if (((MeleeUnit)u).faction != faction)
                {
                    if (DistanceTo((MeleeUnit)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo((MeleeUnit)u);
                    }
                }
                if (u.GetType() == typeof(MeleeUnit))
                {
                    if (DistanceTo((MeleeUnit)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo(u);
                    }
                }
                else if (u.GetType() == typeof(RangedUnit))
                {
                    if (DistanceTo((RangedUnit)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo(u);
                    }
                }
                else if (u.GetType() == typeof(WizardUnit))
                {
                    if (DistanceTo((WizardUnit)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo(u);
                    }
                }
            }

            return closest;

        }

        public override string toString()
        {
            return "Name: " + name + "\r\nFaction: " + faction + "\r\nSymbol: " + Symbol + "\r\nRange: " + attackRange + "\r\nAttack Damage: " + attack + "\r\nHealth: " + health + "\r\nSpeed: " + speed + "\r\nY Postion: " + Xpos + "\r\nX Postion: " + Ypos;
        }

        public Direction Directionto(Unit u) // this will detect in which direction to move towards
        {
            if (u.GetType() == typeof(WizardUnit))
            {
                WizardUnit m = (WizardUnit)u;
                if (m.Xpos < Xpos)
                {
                    return Direction.North;
                }
                else if (m.Xpos > Xpos)
                {
                    return Direction.South;
                }
                else if (m.Ypos < Ypos)
                {
                    return Direction.West;
                }
                else
                {
                    return Direction.East;
                }
            }
            else
            {
                return Direction.North;
            }

        }

        private int DistanceTo(Unit u) // this uses the manhatten distance method to calculate distance
        {
            if (u.GetType() == typeof(WizardUnit))
            {
                WizardUnit w = (WizardUnit)u;
                int d = Math.Abs(Xpos - w.Xpos) + Math.Abs(Ypos - w.Ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }
    }

