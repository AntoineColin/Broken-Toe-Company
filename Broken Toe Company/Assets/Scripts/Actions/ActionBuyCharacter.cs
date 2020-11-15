using UnityEngine;
using System.Text;

namespace Assets.Scripts.Actions
{
    class ActionBuyCharacter : Action
    {
        BaseCharacter character;

        

        protected override void Effect()
        {
            GameManager.INSTANCE.company.SumToGold(-priceMoney);

            GameManager.INSTANCE.company.AddCharacter(character);
        }

        protected override void EndEffect(){}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            if (priceMoney != 0) sb.AppendLine("Gold price : " + priceMoney);
            sb.AppendLine("");
            sb.AppendLine("Get " + character.surname + " the " + character.currentSkill.ToString().ToLower());
            sb.Length--;
            return sb.ToString();
        }

        protected override void Begin()
        {
            character = BaseCharacter.GenerateCharacter();
            priceMoney = character.price;
        }

        public static ActionBuyCharacter GenerateActionBuyCharacter()
        {
            GameObject actionObject = (GameObject)Instantiate(Resources.Load("Action"));
            ActionBuyCharacter action = actionObject.AddComponent<ActionBuyCharacter>();
            actionObject.transform.SetParent(GameObject.Find("ActionsPanel").transform);
            return action;
        }
    }
}
