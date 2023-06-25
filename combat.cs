using Entity;
using ScreenManager;

namespace GameManager {
    public class Combat {
        const int ATTACK_ADJUST = 500; 
        const int MAX_CRITICAL_STRIKE = 100;
        float attackPower;
        int criticalStrike;
        float defensePower;
        Character<EnemyType> currentEnemy;
        Screen currentScreen = new Screen();

        public Combat(Character<EnemyType> currentEnemy) { this.currentEnemy = currentEnemy; }

        public void DisplayCombatScreen(Character<EnemyType> currentEnemy) {
            switch(currentEnemy.Type) {
                case EnemyType.Regular: currentScreen.CombatScreen("regular-enemy.txt"); break;
                case EnemyType.Special: currentScreen.CombatScreen("special-enemy.txt"); break;
                case EnemyType.Rare: currentScreen.CombatScreen("rare-enemy.txt"); break;
            }
        }

        public float CalculateDamage(float dex, float strength, int level) { 
            attackPower = dex * strength * level;
            criticalStrike = (new Random()).Next(MAX_CRITICAL_STRIKE);
            return ((attackPower * criticalStrike) - defensePower) / ATTACK_ADJUST; 
        }

        public void CalculateDeffense(float armor, float speed) { defensePower = armor * speed; }
    }
}