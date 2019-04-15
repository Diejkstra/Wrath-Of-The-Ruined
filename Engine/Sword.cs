namespace Engine
{
    public class Sword : Item
    {
        public int BaseSwordDamage { get; set; } //dagger = 1, bronze = 10, etc
        public int MaxSwordDamage { get; set; }  //dagger = 5, dagger+5 = 10, bronze = 5, bent+5 = 10, etc.

        public Sword() { }

        public Sword(int SwordID)
        {
            ID = SwordID;
            switch (SwordID)
            {
                case -1:
                    BaseSwordDamage = 0;
                    Name = "None";
                    MaxSwordDamage = 3;
                    Price = 0;
                    break;
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    BaseSwordDamage = 1;
                    Name = "Dagger";
                    MaxSwordDamage = BaseSwordDamage + SwordID;
                    if (SwordID != 0)
                        Name += " +" + SwordID.ToString();
                    Price = 5 + SwordID;
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                    BaseSwordDamage = 10;
                    Name = "Bronze Sword";
                    MaxSwordDamage = BaseSwordDamage + (SwordID - 1);
                    if (SwordID != 6)
                        Name += " +" + (SwordID - 6).ToString();
                    Price = 15 + SwordID;
                    break;
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                    BaseSwordDamage = 20;
                    Name = "Iron Sword";
                    MaxSwordDamage = BaseSwordDamage + (SwordID - 7);
                    if (SwordID != 12)
                        Name += " +" + (SwordID - 12).ToString();
                    Price = 30 + SwordID;
                    break;
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                    BaseSwordDamage = 30;
                    Name = "Steel Sword";
                    MaxSwordDamage = BaseSwordDamage + (SwordID - 13);
                    if (SwordID != 18)
                        Name += " +" + (SwordID - 18).ToString();
                    Price = 50 + SwordID;
                    break;
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                    BaseSwordDamage = 40;
                    Name = "Silver Sword";
                    MaxSwordDamage = BaseSwordDamage + (SwordID - 19);
                    if (SwordID != 24)
                        Name += " +" + (SwordID - 24).ToString();
                    Price = 150 + SwordID;
                    break;
                case 30:
                    BaseSwordDamage = 15;
                    Name = "Claws";
                    MaxSwordDamage = 20;
                    Price = 0;
                    break;
                case 100:
                    BaseSwordDamage = 999;
                    MaxSwordDamage = 1000;
                    Name = "Wireshark";
                    Price = 100000;
                    break;
                case 200:
                    BaseSwordDamage = 999;
                    MaxSwordDamage = 1000;
                    Name = "Go To Help Night";
                    Price = 100000;
                    break;
                default:
                    Name = "Error";
                    break;
            }
        }
    }
}
