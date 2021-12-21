using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw2.Exercise5.Models
{
    internal class UserBalancesResponse : IUserBalancesResponse
    {
        public IDictionary<string, IDictionary<string, decimal>> Balances { get; }

        public UserBalancesResponse(Dictionary<string, Dictionary<string, decimal>> balances)
        {
            Balances = new Dictionary<string, IDictionary<string, decimal>>();
            foreach (var i in balances)
            {
                if (Balances.TryAdd(i.Key, i.Value))
                {

                }
            }
        }
    }
}
