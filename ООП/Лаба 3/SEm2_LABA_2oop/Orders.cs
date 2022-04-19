using System;
using System.Collections.Generic;
using System.Text;

namespace laba_2
{
    [Serializable]
    public class Orders
    {
        public List<Tovar> ordersList { get; set; } = new List<Tovar>();
        public List<Tovar> SearchResult { get; set; } = new List<Tovar>();

    }
}
