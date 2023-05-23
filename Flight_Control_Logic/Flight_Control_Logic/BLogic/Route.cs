using System.Collections;

namespace Flight_Control_Logic.BLogic
{
    public class Route : IEnumerable<Station>, IEnumerable //DS_Graph
    {
        //Dictionary <key , value>         dict
        private Dictionary<Station, List<Station>> _dic =
            new Dictionary<Station, List<Station>>();

        public void Add(Station station)
        {
            if (_dic.ContainsKey(station))
                throw new Exception();
            _dic.Add(station, new List<Station>());
        }

        public void ConnectToStation(Station from, Station to)
        {
            if (!_dic.ContainsKey(from) || !_dic.ContainsKey(to))
                throw new Exception();
            _dic[from].Add(to);
        }

        public List<Station> GetNext(Station station)
        {
            return _dic[station];
        }

        public IEnumerator<Station> GetEnumerator()
        {
            return _dic.Keys.GetEnumerator();
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}