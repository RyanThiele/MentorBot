using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Registry
{
    public class Mentee : User
    {
        public Mentee(Guid id) : base(id)
        {

        }

        public override void Subscribe()
        {
            throw new NotImplementedException();
        }

        public override void UnSubscribe()
        {
            throw new NotImplementedException();
        }
    }
}
