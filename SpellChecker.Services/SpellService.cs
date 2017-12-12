using SpellChecker.Contracts;
using SpellChecker.Data;
using SpellChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Services
{
    public class SpellService : ISpell
    {
        public IEnumerable<SpellListItem> GetAllSpells()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return
                    ctx
                        .Spells
                        .Select(
                            e =>
                                new SpellListItem
                                {
                                    SpellId = e.SpellId,
                                    SpellName = e.SpellName,
                                    SpellLevel = e.SpellLevel,
                                    SpellSchool = e.SpellSchool,
                                    CastingTime = e.CastingTime,
                                    SpellRange = e.SpellRange,
                                    VComponents = e.VComponents,
                                    SComponents = e.SComponents,
                                    HasMComponents = e.HasMComponents,
                                    Duration = e.Duration
                                })
                            .ToArray();
            }
        }

        public SpellDetailModel GetSpellById(int spellId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Spells
                        .Single(e => e.SpellId == spellId);

                return
                    new SpellDetailModel
                    {
                        SpellId = entity.SpellId,
                        SpellName = entity.SpellName,
                        SpellLevel = entity.SpellLevel,
                        SpellSchool = entity.SpellSchool,
                        CastingTime = entity.CastingTime,
                        SpellRange = entity.SpellRange,
                        VComponents = entity.VComponents,
                        SComponents = entity.SComponents,
                        HasMComponents = entity.HasMComponents,
                        HasExpensiveMComponents = entity.HasExpensiveMComponents,
                        MComponents = entity.MComponents,
                        Duration = entity.Duration,
                        Ritual = entity.Ritual,
                        SpellTextA = entity.SpellTextA,
                        SpellTextB = entity.SpellTextB,
                        SpellTextC = entity.SpellTextC,
                        SpellTextD = entity.SpellTextD,
                        SpellTextE = entity.SpellTextE,
                        SpellTextF = entity.SpellTextF,
                        SpellTextG = entity.SpellTextG,
                        SpellTextH = entity.SpellTextH,
                        SpellTextI = entity.SpellTextI,
                        SpellSource = entity.SpellSource,
                        BrdSpell = entity.BrdSpell,
                        ClrSpell = entity.ClrSpell,
                        DrdSpell = entity.DrdSpell,
                        PalSpell = entity.PalSpell,
                        RngSpell = entity.RngSpell,
                        SorSpell = entity.SorSpell,
                        WarSpell = entity.WarSpell,
                        WizSpell = entity.WizSpell
                    };
            }
        }
    }
}
