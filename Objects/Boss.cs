using System.Collections.Generic;
using TeamWork.Field;

namespace TeamWork.Objects
{
    public class Boss : Entity
    {
        public enum BossType
        {
            WierdGuy,
        }

        public bool movealbe = true;
        public int bossLife;
        private BossType bossType;
        public Boss(int type)
        {
            bossType = (BossType) type;
            this.Point = new Point2D(58,14);
            switch (bossType)
            {
                    case BossType.WierdGuy:
                    bossLife = 40;
                    break;
            }
        }

        private void BossPrint()
        {
            Printing.DrawAt(this.Point.X+13, this.Point.Y - 12, @",");
            Printing.DrawAt(this.Point.X+12, this.Point.Y - 11, @"/(");
            Printing.DrawAt(this.Point.X+12, this.Point.Y - 10, @"\ \___   /");
            Printing.DrawAt(this.Point.X+12, this.Point.Y - 9, @"/- _  `-/");
            Printing.DrawAt(this.Point.X+11, this.Point.Y - 8, @"(/\/ \ \");
            Printing.DrawAt(this.Point.X+11, this.Point.Y - 7, @"/ /   | `");
            Printing.DrawAt(this.Point.X+11, this.Point.Y - 6, @"O O   ) /");
            Printing.DrawAt(this.Point.X+11, this.Point.Y - 5, @"`-^--'`<");
            Printing.DrawAt(this.Point.X+11, this.Point.Y - 4, @"(_.)  _  )");
            Printing.DrawAt(this.Point.X+11, this.Point.Y - 3, @"`.___/`");
            Printing.DrawAt(this.Point.X+13, this.Point.Y - 2, @"`-----' /");
            Printing.DrawAt(this.Point.X, this.Point.Y - 1, @"<----.     __ / __   \");
            Printing.DrawAt(this.Point,                     @"<----|====O)))==) \) /");
            Printing.DrawAt(this.Point.X, this.Point.Y+1,   @"<----'    `--' `.__,'");
            Printing.DrawAt(this.Point.X+13, this.Point.Y+2,   @"|");
            Printing.DrawAt(this.Point.X+14, this.Point.Y+3,   @"\");
            Printing.DrawAt(this.Point.X+9, this.Point.Y+4,   @"______( (_  /");
            Printing.DrawAt(this.Point.X+7, this.Point.Y+5,   @",'  ,-----'   |");
            Printing.DrawAt(this.Point.X+7, this.Point.Y+6,   @"`--{__________)");
        }

        private void BossClear()
        {
            Printing.DrawAt(this.Point.X + 13, this.Point.Y - 12, @" ");
            Printing.DrawAt(this.Point.X + 12, this.Point.Y - 11, @"  ");
            Printing.DrawAt(this.Point.X + 12, this.Point.Y - 10, @"          ");
            Printing.DrawAt(this.Point.X + 12, this.Point.Y - 9, @"         ");
            Printing.DrawAt(this.Point.X + 11, this.Point.Y - 8, @"        ");
            Printing.DrawAt(this.Point.X + 11, this.Point.Y - 7, @"         ");
            Printing.DrawAt(this.Point.X + 11, this.Point.Y - 6, @"         ");
            Printing.DrawAt(this.Point.X + 11, this.Point.Y - 5, @"        ");
            Printing.DrawAt(this.Point.X + 11, this.Point.Y - 4, @"          ");
            Printing.DrawAt(this.Point.X + 11, this.Point.Y - 3, @"       ");
            Printing.DrawAt(this.Point.X + 13, this.Point.Y - 2, @"         ");
            Printing.DrawAt(this.Point.X     , this.Point.Y - 1, @"                      ");
            Printing.DrawAt(this.Point.X     , this.Point.Y,     @"                      ");
            Printing.DrawAt(this.Point.X     , this.Point.Y + 1, @"                     ");
            Printing.DrawAt(this.Point.X + 13, this.Point.Y + 2, @" ");
            Printing.DrawAt(this.Point.X + 14, this.Point.Y + 3, @" ");
            Printing.DrawAt(this.Point.X + 9 , this.Point.Y + 4, @"             ");
            Printing.DrawAt(this.Point.X + 7 , this.Point.Y + 5, @"               ");
            Printing.DrawAt(this.Point.X + 7 , this.Point.Y + 6, @"               ");
        }

        private List<BossObject> bossGameObjects = new List<BossObject>();
        private int counter = 1;
        private int chance = 30;
        private bool entryAnimationPlayed = false;
        public void BossAI()
        {
            if (!entryAnimationPlayed)
            {

                BossEntryAnimation();
                entryAnimationPlayed = true;
            }
            if (this.bossLife <= 0)
            {
                Engine.BossActive = false;
                foreach (var bossGameObject in bossGameObjects)
                {
                    bossGameObject.ClearObject();
                }
                BossDeathAnimation();
                Printing.Player.IncreasePoints(90);
                Interface.UIDescription();
                return;
            }
            int type = Engine.rnd.Next(0, 4);
            if (counter % chance == 0)
            {
                switch (type)
                {
                    case 0: 
                        for (int i = 0; i < 10; i++)
                        {
                            bossGameObjects.Add(new BossObject(new Point2D(this.Point.X - 5, this.Point.Y + Engine.rnd.Next(-5,5)), type));
                        }
                        break;
                    case 1: bossGameObjects.Add(new BossObject(new Point2D(this.Point.X - 5, this.Point.Y), type));
                        break;
                    case 2: bossGameObjects.Add(new BossObject(new Point2D(this.Point.X - 5, this.Point.Y), type));
                        break;
                    case 3: bossGameObjects.Add(new BossObject(new Point2D(this.Point.X - 5, this.Point.Y), type));
                        break;
                    case 4: bossGameObjects.Add(new BossObject(new Point2D(this.Point.X - 5, this.Point.Y), type));
                        break;
                }
            }
            counter++;
            int move = Engine.rnd.Next(0, 100);
            if (move > 20 && move < 30 && movealbe && this.Point.Y + 1 <= Engine.WindowHeight - 9)
            {
                BossClear();
                this.Point.Y++;
            }
            if (move > 80 && move < 90 && movealbe && this.Point.Y - 1 >= 14)
            {
                BossClear();
                this.Point.Y--;
            }
            BossPrint();
            BossObjectsMoveAndDraw();
            
        }

        private void BossObjectsMoveAndDraw()
        {
            List<BossObject> newObjects = new List<BossObject>();
            foreach (var bossGameObject in bossGameObjects)
            {
                bossGameObject.ClearObject();
                
                    if (bossGameObject.GetLifeOnScreen() <= 0 ||
                        (bossGameObject.Point.X < 5 || bossGameObject.Point.X > Engine.WindowWidth -5 || bossGameObject.Point.Y < 3 || bossGameObject.Point.Y >= Engine.WindowHeight - 3))
                    {

                    }
                    else
                    {
                        bossGameObject.MoveObject();
                        bossGameObject.PrintObject();
                        newObjects.Add(bossGameObject);
                    } 
                
            }
            bossGameObjects = newObjects;
        }

        public bool BossHit(Point2D point )
        {
            if (((point.X == this.Point.X + 13 || point.X == this.Point.X + 14) && point.Y == this.Point.Y - 12) ||
                ((point.X == this.Point.X + 12 || point.X == this.Point.X + 13) && point.Y == this.Point.Y - 11) ||
                ((point.X == this.Point.X + 12 || point.X == this.Point.X + 13) && point.Y == this.Point.Y - 10) ||
                ((point.X == this.Point.X + 12 || point.X == this.Point.X + 13) && point.Y == this.Point.Y - 9) ||
                ((point.X == this.Point.X + 11 || point.X == this.Point.X + 12) && point.Y == this.Point.Y - 8) ||
                ((point.X == this.Point.X + 11 || point.X == this.Point.X + 12) && point.Y == this.Point.Y - 7) ||
                ((point.X == this.Point.X + 11 || point.X == this.Point.X + 12) && point.Y == this.Point.Y - 6) ||
                ((point.X == this.Point.X + 11 || point.X == this.Point.X + 12) && point.Y == this.Point.Y - 5) ||
                ((point.X == this.Point.X + 11 || point.X == this.Point.X + 12) && point.Y == this.Point.Y - 4) ||
                ((point.X == this.Point.X + 11 || point.X == this.Point.X + 12) && point.Y == this.Point.Y - 3) ||
                ((point.X == this.Point.X + 13 || point.X == this.Point.X + 14) && point.Y == this.Point.Y - 2) ||
                ((point.X == this.Point.X + 0 || point.X == this.Point.X + 1) && point.Y == this.Point.Y - 1) ||
                ((point.X == this.Point.X + 0 || point.X == this.Point.X + 1) && point.Y == this.Point.Y - 0) ||
                ((point.X == this.Point.X + 0 || point.X == this.Point.X + 1) && point.Y == this.Point.Y + 1) ||
                ((point.X == this.Point.X + 13 || point.X == this.Point.X + 14) && point.Y == this.Point.Y + 2) ||
                ((point.X == this.Point.X + 14 || point.X == this.Point.X + 15) && point.Y == this.Point.Y + 3) ||
                ((point.X == this.Point.X + 9 || point.X == this.Point.X + 10) && point.Y == this.Point.Y + 4) ||
                ((point.X == this.Point.X + 7 || point.X == this.Point.X + 8) && point.Y == this.Point.Y + 5) ||
                ((point.X == this.Point.X + 7 || point.X == this.Point.X + 8) && point.Y == this.Point.Y + 6))
            {
                this.bossLife--;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BossDeathAnimation()
        {
            Printing.DrawStringCharByChar(this.Point.X + 13, this.Point.Y - 12, @" ",5,false);
            Printing.DrawStringCharByChar(this.Point.X + 12, this.Point.Y - 11, @"  ",5,true);
            Printing.DrawStringCharByChar(this.Point.X + 12, this.Point.Y - 10, @"          ",5,false);
            Printing.DrawStringCharByChar(this.Point.X + 12, this.Point.Y - 9, @"         ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 8, @"        ", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 7, @"         ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 6, @"         ", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 5, @"        ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 4, @"          ", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 3, @"       ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X + 13, this.Point.Y - 2, @"         ", 5, false);
            Printing.DrawStringCharByChar(this.Point.X, this.Point.Y - 1, @"                      ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X, this.Point.Y, @"                      ", 5, false);
            Printing.DrawStringCharByChar(this.Point.X, this.Point.Y + 1, @"                     ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X + 13, this.Point.Y + 2, @" ", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 14, this.Point.Y + 3, @" ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X + 9, this.Point.Y + 4, @"             ", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 7, this.Point.Y + 5, @"               ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X + 7, this.Point.Y + 6, @"               ", 5, false);
        }

        private void BossEntryAnimation()
        {
            Printing.DrawStringCharByChar(this.Point.X + 13, this.Point.Y - 12, @",", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 12, this.Point.Y - 11, @"/(", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 12, this.Point.Y - 10, @"\ \___   /", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 12, this.Point.Y - 9, @"/- _  `-/", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 8, @"(/\/ \ \", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 7, @"/ /   | `", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 6, @"O O   ) /", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 5, @"`-^--'`<", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 4, @"(_.)  _  )", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 3, @"`.___/`", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 13, this.Point.Y - 2, @"`-----' /", 5, false);
            Printing.DrawStringCharByChar(this.Point.X, this.Point.Y - 1, @"<----.     __ / __   \", 5, false);
            Printing.DrawStringCharByChar(this.Point.X, this.Point.Y, @"<----|====O)))==) \) /", 5, false);
            Printing.DrawStringCharByChar(this.Point.X, this.Point.Y + 1, @"<----'    `--' `.__,'", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 13, this.Point.Y + 2, @"|", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 14, this.Point.Y + 3, @"\", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 9, this.Point.Y + 4, @"______( (_  /", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 7, this.Point.Y + 5, @",'  ,-----'   |", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 7, this.Point.Y + 6, @"`--{__________)", 5, false);
        }

        
    }
}
  
