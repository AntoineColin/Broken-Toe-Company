using System.Text;

namespace Assets.Scripts.Actions
{
    class ActionBoost : Action
    {
        public int bonusStrength = 0;
        public int bonusSpeed = 0;
        public int bonusMind = 0;
        public int nbTurnMax = 1;
        int nbTurn;

        protected override void Begin() { }
        protected override void Effect()
        {
            nbTurn = nbTurnMax;
            available = false;
            GameManager.INSTANCE.company.SumToFood(-priceFood);
            GameManager.INSTANCE.company.SumToGold(-priceMoney);
            GameManager.INSTANCE.company.SumToStrength(bonusStrength);
            GameManager.INSTANCE.company.SumToSpeed(bonusSpeed);
            GameManager.INSTANCE.company.SumToMind(bonusMind);

            GameManager.INSTANCE.onEncounterChanged.AddListener(EndEffect);
        }

        protected override void EndEffect()
        {
            if (--nbTurn <= 0)
            {
                available = true;
                GameManager.INSTANCE.company.SumToStrength(-bonusStrength);
                GameManager.INSTANCE.company.SumToSpeed(-bonusSpeed);
                GameManager.INSTANCE.company.SumToMind(-bonusMind);
                if (nbUses == 0) RemoveAction();
            }
            text.text = ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            if (priceMoney != 0) sb.AppendLine("Gold price : " + priceMoney);
            if (priceFood != 0) sb.AppendLine("Food price : " + priceFood);
            if (bonusStrength != 0) sb.AppendLine("Gain " + bonusStrength + " strength");
            if (bonusSpeed != 0) sb.AppendLine("Gain " + bonusSpeed + " speed");
            if (bonusMind != 0) sb.AppendLine("Gain " + bonusStrength + " mind");
            sb.AppendLine("for the next " + (nbTurn == 0 ? nbTurnMax : nbTurn) + " encounters");
            return sb.ToString();
        }
    }
}
