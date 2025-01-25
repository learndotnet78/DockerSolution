using Docker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker.Infrastructure.Repositories
{
    public interface IDemoRepository
    {
        public IEnumerable<Demo> GetDemos();
        public Demo GetDemoById(int demoId);
        public Demo AddDemo(Demo demo);
        public Demo UpdateDemo(Demo demo);
        public bool DeleteDemo(int demoId);
    }
}
