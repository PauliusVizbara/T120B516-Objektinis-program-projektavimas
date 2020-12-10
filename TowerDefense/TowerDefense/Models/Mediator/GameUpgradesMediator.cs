using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Models.Monster;
using TowerDefense.SignalR.Models;

namespace TowerDefense.Models.Mediator
{
    public interface IMediator
    {
        void Notify(object sender, string upgradeType);
    }

    // Concrete Mediators implement cooperative behavior by coordinating several
    // components.
    public class GameUpgradesMediator : IMediator
    {
        private AttackSpeedUpgrade _attackSpeedUpgrade;

        private DamageUpgrade _damageUpgrade;

        public GameUpgradesMediator(AttackSpeedUpgrade attackSpeedUpgrade, DamageUpgrade damageUpgrade)
        {
            this._attackSpeedUpgrade = attackSpeedUpgrade;
            this._attackSpeedUpgrade.SetMediator(this);

            this._damageUpgrade = damageUpgrade;
            this._damageUpgrade.SetMediator(this);
        }

        public void Notify(object sender, string upgradeType)
        {
            if (upgradeType == "AttackSpeed")
            {
                this._attackSpeedUpgrade.ActivateUpgrade();
                this._damageUpgrade.CancelUpgrade();
            }
            if (upgradeType == "Damage")
            {
                this._damageUpgrade.ActivateUpgrade();
                this._attackSpeedUpgrade.CancelUpgrade();
            }
        }
    }

    // The Base Component provides the basic functionality of storing a
    // mediator's instance inside component objects.
    public class BaseComponent
    {
        protected IMediator _mediator;

        public BaseComponent(IMediator mediator = null)
        {
            this._mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }

    // Concrete Components implement various functionality. They don't depend on
    // other components. They also don't depend on any concrete mediator
    // classes.
    public class AttackSpeedUpgrade : BaseComponent
    {
        public bool Active = false;

        public void ActivateUpgrade()
        {
            if (!Active)
            {
                Active = true;
                this._mediator.Notify(this, "AttackSpeed");
            }
        }

        public void CancelUpgrade()
        {
            Active = false;
        }
    }

    public class DamageUpgrade : BaseComponent
    {
        public bool Active = false;

        public void ActivateUpgrade()
        {
            if (!Active)
            {
                Active = true;
                this._mediator.Notify(this, "Damage");
            }
        }

        public void CancelUpgrade()
        {
            Active = false;
        }
    }
}
