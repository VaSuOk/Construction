using System;
using System.Collections.Generic;
using System.Text;
using Сonstruction.Model;

namespace Construction.Auxiliary_classes
{
    public class AmountUsers
    {
        public string Amount { get; set; }
        public List<User> users { get; set; }

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
                    users = new List<User>
                    {
                        new User(),
                        new User(),
                        new User(),
                        new User()
                    }
                },
                new AmountUsers
                {
                    Amount = "6",
                    users = new List<User>
                    {
                        new User(),
                        new User(),
                        new User(),
                        new User(),
                        new User(),
                        new User()
                    }
                },
                new AmountUsers
                {
                    Amount = "8",
                    users = new List<User>
                    {
                        new User(),
                        new User(),
                        new User(),
                        new User(),
                        new User(),
                        new User(),
                        new User(),
                        new User()
                    }
                },
            };
        }
    }
}
