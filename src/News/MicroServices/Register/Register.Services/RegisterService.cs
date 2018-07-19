using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Register.IServices;

namespace Register.Services
{
    public class RegisterService : IRegisterService
    {
        static List<Member> _membersDb = new List<Member>();

        public bool CheckName(string name)
        {
            return _membersDb.Any(x => x.Name == name);
        }

        public Task<bool> Register(string name, string nickname, string pwd)
        {
            if (!CheckName(name))
            {
                return Task.FromResult(false);
            }
            _membersDb.Add(new Member { Id = Guid.NewGuid(), Name = name, NickName = nickname, Pwd = pwd });
            return Task.FromResult(true);

        }
    }
}
