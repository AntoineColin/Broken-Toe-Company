﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Scripts.Actions
{
    class ActionBuyCharacter : Action
    {
        BaseCharacter character;

        void Start()
        {
            character = BaseCharacter.GenerateCharacter();
            priceMoney = character.price;
            btn = GetComponent<Button>();
            image = GetComponent<Image>();
            text = GetComponentInChildren<Text>();
            text.text = ToString();
            CheckAvailability();
        }

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
            sb.AppendLine("Get " + character.surname + " the " + character.currentSkill.ToString().ToLower());
            return sb.ToString();
        }
    }
}
