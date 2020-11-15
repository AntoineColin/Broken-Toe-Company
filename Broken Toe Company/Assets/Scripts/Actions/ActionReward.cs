using System;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    class ActionReward : Action
    {
        readonly System.Random random = new System.Random();
        [Range(0, 1)]
        public float chanceToReward = 0.5f;
        public int rewardGold = 10, rewardFood = 3;

        protected override void Begin() { }
        protected override void Effect()
        {
            GameManager.INSTANCE.company.SumToFood(-priceFood);
            GameManager.INSTANCE.company.SumToGold(-priceMoney);
            if(random.NextDouble() <= chanceToReward)
            {
                GameManager.INSTANCE.company.SumToFood(rewardFood);
                GameManager.INSTANCE.company.SumToGold(rewardGold);
            }
        }

        protected override void EndEffect() { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            if (priceMoney != 0) sb.AppendLine("Gold price : " + priceMoney);
            if (priceFood != 0) sb.AppendLine("Food price : " + priceFood);
            sb.AppendLine("");
            if (chanceToReward >= 0.8f) sb.AppendLine("Great chances to get");
            else if (chanceToReward >= 0.5f) sb.AppendLine("Good chances to get");
            else if (chanceToReward >= 0.3f) sb.AppendLine("Weak chances to get");
            else sb.AppendLine("Thin chances to get");
            if (rewardGold != 0) sb.AppendLine(rewardGold + " gold");
            if (rewardFood != 0) sb.AppendLine(rewardFood + " food");
            sb.Length--;
            return sb.ToString();
        }

        public static ActionReward GenerateActionReward(int goldPrice, int foodPrice, int gold, int food, float chance)
        {
            GameObject actionObject = (GameObject)Instantiate(Resources.Load("Action"));
            ActionReward action = actionObject.AddComponent<ActionReward>();
            actionObject.transform.SetParent(GameObject.Find("ActionsPanel").transform);
            action.priceMoney = goldPrice;
            action.priceFood = foodPrice;
            action.rewardGold = gold;
            action.rewardFood = food;
            action.chanceToReward = chance;
            return action;
        }
    }
}
