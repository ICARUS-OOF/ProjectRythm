﻿namespace ColourCore
{
    namespace Interfaces
    {
        public interface IEntity
        {
            bool canDamage { get; set; }
            int Health { get; set; }
            void Damage();
        }
    }
}
