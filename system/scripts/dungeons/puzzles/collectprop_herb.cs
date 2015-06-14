//--- Aura Script -----------------------------------------------------------
// Collect Prop Puzzle
//--- Description -----------------------------------------------------------
// Spawns herb patches in a room.
//---------------------------------------------------------------------------

using Aura.Channel.Scripting.Scripts;
using Aura.Channel.World.Dungeons.Props;
using Aura.Channel.World.Dungeons.Puzzles;
using Aura.Channel.World.Entities;

[PuzzleScript("collectprop_herb")]
public class CollectPropHerbScript : PuzzleScript
{
	public override void OnPrepare(Puzzle puzzle)
	{
		var propPlace = puzzle.NewPlace("PropPlace");
		propPlace.ReservePlace();
		propPlace.ReserveDoors();
	}

	public override void OnPuzzleCreate(Puzzle puzzle)
	{
		var propPlace = puzzle.GetPlace("PropPlace");

		int propId;
		uint color;

		for (int i = 1; i <= 3; ++i)
		{
			GetRandom(puzzle, out propId, out color);
			var patch = new HerbPatch(propId, "Herb" + i, color);
			propPlace.AddProp(patch, DungeonPropPositionType.Random);
		}
	}

	private void GetRandom(Puzzle puzzle, out int propId, out uint color)
	{
		propId = 272; // Base
		color = 0x808080;

		var arg = (puzzle.Data.Arg ?? "baseherb").ToLower();

		if (puzzle.Data.Arg == null)
		{
			var num = Random(100);

			if (puzzle.Dungeon.Name.Contains("_low_"))
			{
				// TODO: Others, G3+
				if (num < 13)
					arg = "goldherb";
				else if (num < 23)
					arg = "manaherb";
				else if (num < 35)
					arg = "sunlightherb";
				else if (num < 50)
					arg = "bloodyherb";
			}
			else if (puzzle.Dungeon.Name.Contains("_middle_") || puzzle.Dungeon.Name.Contains("_Hardmode_"))
			{
				if (num < 8)
					arg = "goldherb";
				else if (num < 40)
					arg = "manaherb";
				else if (num < 55)
					arg = "sunlightherb";
				else if (num < 70)
					arg = "bloodyherb";
			}
			else if (puzzle.Dungeon.Name.Contains("_low_Hardmode_") || puzzle.Dungeon.Name.Contains("_high_"))
			{
				if (num < 10)
					arg = "goldherb";
				else if (num < 46)
					arg = "manaherb";
				else if (num < 68)
					arg = "sunlightherb";
				else if (num < 70)
					arg = "bloodyherb";
			}
			else if (puzzle.Dungeon.Name.Contains("_magic_bean_"))
			{
				if (num < 50)
					arg = "magicbean";
			}
			else if (puzzle.Dungeon.Name.Contains("_magic_cacao_bean_"))
			{
				if (num < 50)
					arg = "magicbean2";
			}
			else if (puzzle.Dungeon.Name.Contains("_middle_Hardmode_"))
			{
				if (num < 11)
					arg = "goldherb";
				else if (num < 51)
					arg = "manaherb";
				else if (num < 62)
					arg = "sunlightherb";
				else if (num < 77)
					arg = "bloodyherb";
			}
			else if (puzzle.Dungeon.Name.Contains("_high_Hardmode_"))
			{
				if (num < 12)
					arg = "goldherb";
				else if (num < 56)
					arg = "manaherb";
				else if (num < 68)
					arg = "sunlightherb";
				else if (num < 84)
					arg = "bloodyherb";
			}
			else
			{
				if (num < 10)
					arg = "goldherb";
				else if (num < 20)
					arg = "manaherb";
				else if (num < 22)
					arg = "sunlightherb";
				else if (num < 29)
					arg = "bloodyherb";
			}
		}
		else if (arg == "mandrake" || arg == "poisonherb" || arg == "antidoteherb")
		{
			switch (Random(4))
			{
				case 0: arg = "goldherb"; break;
				case 1: arg = "manaherb"; break;
				case 2: arg = "sunlightherb"; break;
				case 3: arg = "bloodyherb"; break;
			}
		}

		switch (arg)
		{

			case "bloodyherb":
				propId = 269;
				color = 0xaa4261;
				break;

			case "manaherb":
				propId = 270;
				color = 0x0080c0;
				break;

			case "sunlightherb":
				propId = 271;
				color = 0xb7b066;
				break;

			default:
			case "baseherb":
				propId = 272;
				color = 0x808080;
				break;

			case "goldherb":
				propId = 273;
				color = 0xff8000;
				break;

			case "whiteherb":
				propId = 326;
				color = 0xdddddd;
				break;

			case "poisonherb":
				propId = 329;
				color = 0x77588F;
				break;

			case "antidoteherb":
				propId = 330;
				color = 0xECE3DD;
				break;

			case "mandrake":
				propId = 331;
				color = 0xF59200;
				break;

			case "magicbean":
				propId = 24910;
				color = 0x808080;
				break;

			case "magicbean2":
				propId = 41274;
				color = 0x808080;
				break;
		}
	}
}
