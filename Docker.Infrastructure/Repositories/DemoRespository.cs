using Docker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker.Infrastructure.Repositories
{
    public class DemoRepository : IDemoRepository
    {
        readonly List<Demo> _list;
        int cnt = 3;
        public DemoRepository()
        {
            _list = new List<Demo>();

            Demo demo = new()
            {
                DemoID = 1,
                DemoName = "Sam Johnson",
                Address = "12 Felix Drive",
                City = "Trenton",
                State = "NJ",
                Comments = "NJ Customer"
            };
            _list.Add(demo);

            demo = new()
            {
                DemoID = 2,
                DemoName = "Pam Michael",
                Address = "145 Maple Drive",
                City = "New York",
                State = "NY",
                Comments = "NY Customer"
            };
            _list.Add(demo);

            demo = new()
            {
                DemoID = 3,
                DemoName = "Jeff Byrce",
                Address = "15 Philadephia Avenue",
                City = "Philadephia",
                State = "PA",
                Comments = "PA Customer"
            };
            _list.Add(demo);

            demo = new()
            {
                DemoID = 4,
                DemoName = "Tom Walter",
                Address = "345 Fredrick Avenue",
                City = "Owensboro",
                State = "KY",
                Comments = "KY Customer"
            };
            _list.Add(demo);


        }
        public Demo AddDemo(Demo demo)
        {
            Demo demoAdd = new()
            {
                DemoID = cnt + 1,
                DemoName = demo.DemoName,
                Address = demo.Address,
                City = demo.City,
                State = demo.State,
                Comments = demo.Comments
            };
            _list.Add(demoAdd);

            return _list.FirstOrDefault(x => x.DemoID == cnt + 1);
        }

        public bool DeleteDemo(int demoId)
        {
            if (_list != null)
            {
                Demo deleteDemo = _list.FirstOrDefault(x => x.DemoID == demoId);

                _list.Remove(deleteDemo);

                return true;
            }

            return false;
        }

        public Demo GetDemoById(int demoId)
        {
            return _list.FirstOrDefault(x => x.DemoID == demoId);
        }

        public IEnumerable<Demo> GetDemos()
        {
            return _list;
        }

        public Demo UpdateDemo(Demo demo)
        {
            Demo demoUpd = _list.Where(x => x.DemoID == demo.DemoID).FirstOrDefault();

            if (demoUpd != null)
            {
                demoUpd.DemoName = demo.DemoName;
                demoUpd.Address = demo.Address;
                demoUpd.City = demo.City;
                demoUpd.State = demo.State;
                demoUpd.Comments = demo.Comments;
            }


            return demoUpd;
        }
    }
}
