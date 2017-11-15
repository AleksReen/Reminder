using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Domain.FakeModel
{
   public interface IFakeInterface
    {
        string GetStaticMessage();
        void CreateSomeError();
    }
}
