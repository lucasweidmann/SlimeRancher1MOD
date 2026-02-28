using AssetsLib;
using SimpleSRmodLibrary.Creation;
using SRML;
using SRML.SR;
using SRML.Utils.Enum;
using System.Collections.Generic;
using UnityEngine;
using static SRML.SR.AchievementRegistry;
using SRML.SR.Templates.Identifiables;

namespace EmeraldSlime
{
    [EnumHolder]
    public static class Ids
    {
        public static readonly Identifiable.Id EMERALD_SLIME;
        public static readonly Identifiable.Id EMERALD_PLORT;
        public static readonly Identifiable.Id EMERALD_GORDO;
        public static readonly PediaDirector.Id PEDIA_EMERALD_SLIME;
    }

    public class Main : ModEntryPoint
    {
        List<Identifiable.Id> largoIds1 = new List<Identifiable.Id>();
        List<Identifiable.Id> largoIds2 = new List<Identifiable.Id>();
        public override void PreLoad()
        {
            PlortCreation.PlortPreLoad(Ids.EMERALD_PLORT, "Emerald Plort", false);
            SpawnCreation.CreateSingleZoneSpawner(Ids.EMERALD_SLIME, ZoneDirector.Zone.DESERT, 0.02f);
            List<Identifiable.Id> slimesToLargoWith = new List<Identifiable.Id>() { Identifiable.Id.PINK_SLIME, Identifiable.Id.ROCK_SLIME, Identifiable.Id.TABBY_SLIME, Identifiable.Id.PHOSPHOR_SLIME, Identifiable.Id.RAD_SLIME, Identifiable.Id.BOOM_SLIME, Identifiable.Id.HONEY_SLIME, Identifiable.Id.CRYSTAL_SLIME, Identifiable.Id.HUNTER_SLIME, Identifiable.Id.QUANTUM_SLIME, Identifiable.Id.DERVISH_SLIME, Identifiable.Id.MOSAIC_SLIME, Identifiable.Id.TANGLE_SLIME, Identifiable.Id.SABER_SLIME, Identifiable.Id.GOLD_SLIME, Identifiable.Id.LUCKY_SLIME, Identifiable.Id.GLITCH_SLIME, Identifiable.Id.QUICKSILVER_SLIME };
            foreach (Identifiable.Id id in slimesToLargoWith)
            {
                largoIds1.Add(IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "EMERALD_" + id.ToString().Split('_')[0] + "_LARGO"));
                largoIds2.Add(IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), id.ToString().Split('_')[0] + "_EMERALD" + "_LARGO"));
            }
            HarmonyInstance.PatchAll();

        }

        public override void Load() { }

        public override void PostLoad()
        {
            var EmeraldPlort = PlortCreation.CreatePlort("Emerald Plort", Ids.EMERALD_PLORT, Vacuumable.Size.NORMAL, new Color32(18, 95, 45, 255), new Color32(95, 255, 160, 255), new Color32(18, 95, 45, 255));
            PlortCreation.PlortLoad(Ids.EMERALD_PLORT, 600f, 50f, EmeraldPlort, TextureUtils.LoadImage("EmeraldPlort.png").CreateSprite(), new Color32(95, 255, 160, 255), true, true, false);

            var EmeraldSlime = SlimeCreation.SlimeBaseCreate(Ids.EMERALD_SLIME, "Emerald Slime", "Emerald Slime", "Emerald Slime", "Emerald Slime", Identifiable.Id.CRYSTAL_SLIME, Identifiable.Id.CRYSTAL_SLIME, Identifiable.Id.CRYSTAL_SLIME, Identifiable.Id.CRYSTAL_SLIME, SlimeEat.FoodGroup.GINGER, Identifiable.Id.GINGER_VEGGIE, Identifiable.Id.GINGER_VEGGIE, Identifiable.Id.TREASURE_CHEST_TOY, Ids.EMERALD_PLORT, false, TextureUtils.LoadImage("EmeraldSlime.png").CreateSprite(), Vacuumable.Size.NORMAL, false, 0f, 0.1f, new Color32(120, 255, 170, 255), new Color32(45, 200, 120, 255), new Color32(10, 95, 55, 255), new Color32(190, 255, 220, 255), new Color32(8, 70, 40, 255), new Color32(5, 45, 28, 255), new Color32(2, 25, 15, 255), new Color32(210, 255, 230, 255), new Color32(20, 120, 70, 255), new Color32(5, 20, 10, 255), new Color32(170, 255, 210, 255), new Color32(45, 200, 120, 255), new Color32(10, 95, 55, 255), new Color32(90, 255, 170, 255));
            SlimeCreation.LoadSlime(EmeraldSlime);

            SlimePediaCreation.LoadSlimePediaIcon(Ids.PEDIA_EMERALD_SLIME, TextureUtils.LoadImage("EmeraldSlime.png").CreateSprite());
            SlimePediaCreation.PreLoadSlimePediaConnection(Ids.PEDIA_EMERALD_SLIME, Ids.EMERALD_SLIME, PediaRegistry.PediaCategory.SLIMES);
            SlimePediaCreation.CreateSlimePediaForSlime(Ids.PEDIA_EMERALD_SLIME, "Emerald Slimes are crystalline slimes that glow softly as light passes through their gemlike bodies.", "Gilded Ginger", "Gilded Ginger", "Scientists believe Emerald Slimes form when a Quantum Slime remains exposed to ancient mineral deposits for long periods of time. The minerals slowly fuse with its shifting matter, stabilizing parts of its body into a semi-crystalline structure. Despite this stability, their internal energy continues to pulse and shimmer, giving them their characteristic glow. Ranchers report that Emerald Slimes are unusually calm when undisturbed, but will suddenly relocate when stressed, as if slipping through the environment rather than physically moving through it.", "Living near Emerald Slimes can be disorienting. Objects may occasionally appear displaced, and loose items often vanish only to reappear nearby moments later. Prolonged exposure has been known to cause dizziness in ranchers due to their intense light refraction. High walls help, but do not guarantee containment.", "Emerald Plorts contain tightly packed crystalline matrices capable of storing and releasing energy in small bursts. Engineers have begun experimenting with them as stabilizers in delicate devices and advanced ranch tech. However, improper handling may result in sudden energy discharge, leaving tools briefly disabled or scrambled.");
            TranslationPatcher.AddPediaTranslation("t.pedia_emerald_slime", "Emerald Slime");

            var EmeraldGordo = GordoCreation.CreateGordoWithIcon(Ids.EMERALD_GORDO, "Emerald Gordo", Identifiable.Id.CRYSTAL_GORDO, Ids.EMERALD_SLIME, Ids.EMERALD_SLIME, "Emerald", ZoneDirector.Zone.DESERT, "Emerald Gordo", Ids.EMERALD_SLIME, 30, TextureUtils.LoadImage("EmeraldGordo.png").CreateSprite());
            SlimeCreation.LoadSlime(EmeraldGordo);
            List<Identifiable.Id> slimesToLargoWith = new List<Identifiable.Id>() { Identifiable.Id.PINK_SLIME, Identifiable.Id.ROCK_SLIME, Identifiable.Id.TABBY_SLIME, Identifiable.Id.PHOSPHOR_SLIME, Identifiable.Id.RAD_SLIME, Identifiable.Id.BOOM_SLIME, Identifiable.Id.HONEY_SLIME, Identifiable.Id.CRYSTAL_SLIME, Identifiable.Id.HUNTER_SLIME, Identifiable.Id.QUANTUM_SLIME, Identifiable.Id.DERVISH_SLIME, Identifiable.Id.MOSAIC_SLIME, Identifiable.Id.TANGLE_SLIME, Identifiable.Id.SABER_SLIME, Identifiable.Id.GOLD_SLIME, Identifiable.Id.LUCKY_SLIME, Identifiable.Id.GLITCH_SLIME, Identifiable.Id.QUICKSILVER_SLIME };
            int looper = 0;
            foreach (Identifiable.Id id in slimesToLargoWith)
            {
                SlimeRegistry.CraftLargo(largoIds1[looper], Ids.EMERALD_SLIME, id, SlimeRegistry.LargoProps.NONE);
                SlimeRegistry.CraftLargo(largoIds2[looper], id, Ids.EMERALD_SLIME, SlimeRegistry.LargoProps.NONE);
                EatMapCreation.AddLargo(largoIds1[looper], Ids.EMERALD_SLIME, id);
                EatMapCreation.AddLargo(largoIds2[looper], id, Ids.EMERALD_SLIME);
                looper++;
            }
        }
    }
}