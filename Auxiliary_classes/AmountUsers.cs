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
        public string Amount { get; set; }
        public ObservableCollection<UserWorkInformation> users { get; set; }

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
                    users = new ObservableCollection<UserWorkInformation>
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
                    users = new ObservableCollection<UserWorkInformation>
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
                    users = new ObservableCollection<UserWorkInformation>
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
    }
}
