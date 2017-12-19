using SpellChecker.Contracts;
using SpellChecker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Services
{
    public class CurrentService : ICurrent
    {
        private readonly Guid _userId;

        public CurrentService(Guid userId)
        {
            _userId = userId;
        }

        public int GetUserSpellbook()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Users
                    .SingleOrDefault(e => Guid.Parse(e.Id) == _userId);

                return entity.CurrentSpellbook;
            }
        }
    }
}
