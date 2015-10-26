class Game{
	var borders : array<int>;
	var items : array<int>;

	constructor Init(a: array<int>)
	modifies this
	{
		borders := new int[8];
		borders[0] := 0;
		borders[1] := 3;
		borders[2] := 4;
		borders[3] := 7;
		borders[4] := 8;
		borders[5] := 11;
		borders[6] := 12;
		borders[7] := 15;
		items := a;
	}

	predicate Valid()
	reads this;
	{
		items != null && items.Length == 16 && borders != null && borders.Length == 8
	}

	method FindPosById(id: int) returns (pos: int)
	requires Valid();
	ensures old(items) == items;
	ensures Valid();
	{
		var i := 0;
		while(i <= 15)
		invariant 0 <= i <= 16;
		invariant old(items) == items;
		{
			if(items[i] == id)
			{
				pos := i;
			}
			i := i + 1;
		}
	}

	method FindEmpty() returns (pos: int)
	requires Valid();
	ensures old(items) == items;
	ensures Valid();
	{
		var i := 0;
		while(i <= 15)
		invariant 0 <= i <= 16;
		invariant old(items) == items;
		{
			if(items[i] == 15)
			{
				pos := i;
			}
			i := i + 1;
		}
	}

	method GetIdByPos(pos: int) returns (id: int)
	requires Valid();
	requires 0 <= pos < items.Length;
	ensures old(items) == items;
	ensures Valid();
	{
		id := items[pos];
	}

	method BoardSolved() returns (b: bool)
	requires Valid();
	ensures old(items) == items;
	ensures Valid();
	{
		var i := 0;
		b := true;

		while(i <= 15)
		{
			if(items[i] != i)
			{
				b := false;
			}
			i := i + 1;
		}
	}

	method IsSolvable() returns (b: bool)
	requires Valid();
	ensures old(items) == items;
	ensures Valid();
	{
		var i := 1;
		var n := 0;
		b := false;

		while(i <= 15)
		{
			var num1 := GetIdByPos(i);
			var num2 := GetIdByPos(i - 1);

			if(num1 > num2)
			{
				n := n + 1;
			}

			i := i + 1;
		}

		var emptyPos := FindEmpty();
		if(n % 2 == (emptyPos + emptyPos / 4) % 2)
		{
			b := true;
		}
	}

	method IsBorderSwitch(x: int, y: int) returns (b: bool)
	requires Valid();
	ensures old(items) == items;
	ensures Valid();
	{
		b := (BordersContain(x) && BordersContain(y));
	}

	function method BordersContain(v: int) : bool
	requires Valid();
	reads this;
	reads borders;
	{
		exists i :: 0 <= i < borders.Length && borders[i] == v
	}

	method CanMove(id: int) returns(target: int)
	requires Valid();
	ensures Valid();
	{
		
	}
}