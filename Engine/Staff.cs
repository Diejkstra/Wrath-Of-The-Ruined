namespace Engine
{
    public class Staff
    {
        public string StaffName { get; set; }
        public int StaffID { get; set; }
        public int BaseStaffDamage { get; set; }
        public int MaxStaffDamage { get; set; }
        public int Price { get; set; }

        public void AssignStaffStats(int StaffID)
        {
            switch (StaffID)
            {
                case -1:
                    BaseStaffDamage = 0;
                    StaffName = "None";
                    MaxStaffDamage = 3;
                    Price = 0;
                    break;
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    BaseStaffDamage = 1;
                    StaffName = "Oak Staff";
                    MaxStaffDamage = BaseStaffDamage + StaffID;
                    if (StaffID != 0)
                        StaffName += " +" + StaffID.ToString();
                    Price = 5 + StaffID;
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                    BaseStaffDamage = 10;
                    StaffName = "Willow Staff";
                    MaxStaffDamage = BaseStaffDamage + (StaffID - 1);
                    if (StaffID != 6)
                        StaffName += " +" + (StaffID - 6).ToString();
                    Price = 15 + StaffID;
                    break;
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                    BaseStaffDamage = 20;
                    StaffName = "Maple Staff";
                    MaxStaffDamage = BaseStaffDamage + (StaffID - 7);
                    if (StaffID != 12)
                        StaffName += " +" + (StaffID - 12).ToString();
                    Price = 30 + StaffID;
                    break;
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                    BaseStaffDamage = 30;
                    StaffName = "Mahogany Staff";
                    MaxStaffDamage = BaseStaffDamage + (StaffID - 13);
                    if (StaffID != 18)
                        StaffName += " +" + (StaffID - 18).ToString();
                    Price = 50 + StaffID;
                    break;
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                    BaseStaffDamage = 40;
                    StaffName = "Yew Staff";
                    MaxStaffDamage = BaseStaffDamage + (StaffID - 19);
                    if (StaffID != 24)
                        StaffName += " +" + (StaffID - 24).ToString();
                    Price = 150 + StaffID;
                    break;
                case 100:
                    BaseStaffDamage = 999;
                    MaxStaffDamage = 1000;
                    StaffName = "Yes";
                    break;
                default:
                    StaffName = "Error";
                    break;
            }

        }
    }
}
