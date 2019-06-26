using System;
using System.Threading;
using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;

namespace Text_Based_Game {
    class Character {
        private string name;
        private int hp;
        private int healthPool;
        private int money;

        public Character(string name) {
            this.name = name;
            healthPool = 10;
            hp = healthPool;
            money = 10;
        }
        
        //Takes damage and returns whether or not the player has died

        public Boolean takeDamage(int dmg) {
            if (dmg > hp)
                return true;
            hp -= dmg;
            return false;
        }

    }
}
