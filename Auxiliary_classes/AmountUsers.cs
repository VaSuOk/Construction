using Construction.HttpRequests;
using Construction.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Сonstruction.Model;

namespace Construction.Auxiliary_classes
{
    public class AmountUsers
    {
        public static int Index;
        public string Amount { get; set; }
        public List<UserWorkInformation> users { get; set; }

        public override string ToString()
        {
            return Amount;
        }

        public static List<AmountUsers> GetAmounts()
        {
            return new List<AmountUsers>
            {
                new AmountUsers
                {
                    Amount = "4",
                    users = new List<UserWorkInformation>
                    {
                        new UserWorkInformation(),
                        new UserWorkInformation(),
                        new UserWorkInformation(),
                        new UserWorkInformation()
                    }
                },
                new AmountUsers
                {
                    Amount = "6",
                    users = new List<UserWorkInformation>
                    {
                        new UserWorkInformation(),
                        new UserWorkInformation(),
                        new UserWorkInformation(),
                        new UserWorkInformation(),
                        new UserWorkInformation(),
                        new UserWorkInformation()
                    }
                },
                new AmountUsers
                {
                    Amount = "8",
                    users = new List<UserWorkInformation>
                    {
                        new UserWorkInformation(),
                        new UserWorkInformation(),
                        new UserWorkInformation(),
                        new UserWorkInformation(),
                        new UserWorkInformation(),
                        new UserWorkInformation(),
                        new UserWorkInformation(),
                        new UserWorkInformation()
                    }
                },
            };
        }
        public static List<AmountUsers> GetAmountUsers(int size, Brigade brigade)
        {
            AmountUsers amountUsers = new AmountUsers();
            switch (size)
            {
                case 4:
                    {
                        amountUsers = new AmountUsers() { Amount = "4", users = new List<UserWorkInformation>() 
                        {  new UserWorkInformation(), new UserWorkInformation(), new UserWorkInformation(), new UserWorkInformation() }};

                        if (brigade.ID_user1 > 0) amountUsers.users[0] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user1);
                        if (brigade.ID_user2 > 0) amountUsers.users[1] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user2);
                        if (brigade.ID_user3 > 0) amountUsers.users[2] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user3);
                        if (brigade.ID_user4 > 0) amountUsers.users[3] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user4);
                        break;
                    }
                case 6:
                    {
                        amountUsers = new AmountUsers()
                        {
                            Amount = "6",
                            users = new List<UserWorkInformation>()
                        {  new UserWorkInformation(), new UserWorkInformation(), new UserWorkInformation(), new UserWorkInformation(), new UserWorkInformation(), new UserWorkInformation() }
                        };
                        if (brigade.ID_user1 > 0) amountUsers.users[0] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user1);
                        if (brigade.ID_user2 > 0) amountUsers.users[1] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user2);
                        if (brigade.ID_user3 > 0) amountUsers.users[2] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user3);
                        if (brigade.ID_user4 > 0) amountUsers.users[3] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user4);
                        if (brigade.ID_user5 > 0) amountUsers.users[4] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user5);
                        if (brigade.ID_user6 > 0) amountUsers.users[5] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user6);
                        break;
                    }
                case 8:
                    {
                        amountUsers = new AmountUsers()
                        {
                            Amount = "8",
                            users = new List<UserWorkInformation>()
                        {  new UserWorkInformation(), new UserWorkInformation(), new UserWorkInformation(), new UserWorkInformation(), new UserWorkInformation(), new UserWorkInformation(), new UserWorkInformation(), new UserWorkInformation() }
                        };
                        if (brigade.ID_user1 > 0) amountUsers.users[0] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user1);
                        if (brigade.ID_user2 > 0) amountUsers.users[1] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user2);
                        if (brigade.ID_user3 > 0) amountUsers.users[2] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user3);
                        if (brigade.ID_user4 > 0) amountUsers.users[3] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user4);
                        if (brigade.ID_user5 > 0) amountUsers.users[4] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user5);
                        if (brigade.ID_user6 > 0) amountUsers.users[5] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user6);
                        if (brigade.ID_user7 > 0) amountUsers.users[6] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user7);
                        if (brigade.ID_user8 > 0) amountUsers.users[7] = UserWorkInformationRequest.GetUserWIByID(brigade.ID_user8);
                        break;
                    }
                default:
                    {
                        return GetAmounts();
                    }
            }
            List<AmountUsers> temp =  GetAmounts();
            if (size == 4)
            {
                Index = 0;
                temp[0].users = amountUsers.users;
            }
            else if(size == 6)
            {
                Index = 1;
                temp[1].users = amountUsers.users;
            }
            else if (size == 8)
            {
                Index = 2;
                temp[2].users = amountUsers.users;
            }
            return temp;
        }
        public static void SetUsersID(ref Brigade brigade, AmountUsers amountUsers)
        {
            switch (brigade.Amount)
            {
                case 4:
                    {
                        brigade.ID_user1 = (int)amountUsers.users[0].ID;
                        brigade.ID_user2 = (int)amountUsers.users[1].ID;
                        brigade.ID_user3 = (int)amountUsers.users[2].ID;
                        brigade.ID_user4 = (int)amountUsers.users[3].ID;
                        break;
                    }
                case 6:
                    {
                        brigade.ID_user1 = (int)amountUsers.users[0].ID;
                        brigade.ID_user2 = (int)amountUsers.users[1].ID;
                        brigade.ID_user3 = (int)amountUsers.users[2].ID;
                        brigade.ID_user4 = (int)amountUsers.users[3].ID;
                        brigade.ID_user5 = (int)amountUsers.users[4].ID;
                        brigade.ID_user6 = (int)amountUsers.users[5].ID;
                        break;
                    }
                case 8:
                    {
                        brigade.ID_user1 = (int)amountUsers.users[0].ID;
                        brigade.ID_user2 = (int)amountUsers.users[1].ID;
                        brigade.ID_user3 = (int)amountUsers.users[2].ID;
                        brigade.ID_user4 = (int)amountUsers.users[3].ID;
                        brigade.ID_user5 = (int)amountUsers.users[4].ID;
                        brigade.ID_user6 = (int)amountUsers.users[5].ID;
                        brigade.ID_user7 = (int)amountUsers.users[6].ID;
                        brigade.ID_user8 = (int)amountUsers.users[7].ID;
                        break;
                    }
            }
        }
    }
}
