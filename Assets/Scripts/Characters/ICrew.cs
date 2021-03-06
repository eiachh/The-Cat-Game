using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Characters
{
    public interface ICrew
    {
        IEnumerable<ICrewMember> Members();
        void AddMember(ICrewMember member);
        void RemoveMember(ICrewMember member);
    }
}
