class Game{
	var borders : array<int>;
	var items : array<int>;

	/*
	* Die Init-Methode initialisiert das Vergleichs-Array Borders und übernimmt das übergebene Array a für das Spielfeld-Array "items"
	*/
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

	/*
	* Das Prädikat Valid() validiert die Gültigkeit der Objekte items und Borders.
	* Regeln:
	* - items und borders dürfen nich NULL sein
	* - items muss die Länge 16 haben
	* - borders muss die Länge 8 haben
	* - in items darf jede ID zwischen 0 und 15 (incl.) nur ein mal vorkommen
	*/
	predicate Valid()
	reads this;
	reads items;
	{
		items != null && items.Length == 16 && borders != null && borders.Length == 8
		&& forall j,k :: 0 <= j < k < items.Length ==> items[j] != items[k]
		&& forall l :: 0 <= l < items.Length ==> 0 <= items[l] < 16
	}

	/*
	* FindPosById iteriert über das Array items und gibt die position des Gesuchten Element im Array zurück
	*/
	method FindPosById(id: int) returns (pos: int)
	requires Valid();
	ensures old(items) == items;
	ensures Valid();
	ensures 0 <= pos < 16;
	{
		var i := 0;
		pos := 0;
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

	/*
	* FindEmpty iteriert über das Array und gibt die Positiong der ID 15 zurück, diese Stellt das leere Feld im Puzzle dar.
	*/
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

	/*
	* GetIdByPos gibt die an der gesuchten Position zurück. Diese Methode entspricht einem Getter und
	* dient der leserlichkeit an anderen Stellen des Codes
	*/
	function method GetIdByPos(pos: int) : int
	reads this;
	reads items;
	requires Valid();
	requires 0 <= pos < items.Length;
	
	ensures Valid();
	{
		items[pos]
	}

	/*
	* BoardSolved prüft anhand der gleichheit der ID zur Position ob, das Puzzle gelöst wurde
	*/
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

	/*
	* IsSolvable prüft anhand der Fehlstellungen und der Position des Leerfeldes ob das zufällig generierte Spielfeld lösbar ist.
	*/
	method IsSolvable() returns (b: bool)
	requires Valid();
	ensures old(items) == items;
	ensures Valid();
	{
		var field := 0;
		
		var parities := 0;
		b := false;

		while(field < 15)
		{
			var compare := field + 1;
			
			if(GetIdByPos(field) != 15){
				while(compare <= 15)
				{
					if(GetIdByPos(field) > GetIdByPos(compare))
					{
						parities := parities + 1;
					}
					compare := compare + 1;
				}
			}



			if(GetIdByPos(field) == 15 && (0 <= field <= 3 || 8 <= field <= 11))
			{
				parities := parities + 1;
			}
			field := field + 1;
		}
		if(parities % 2 == 0)
		{
			b := true;
		}
	}

	/*
	* Hilfsfunktion um zu testen, ob es sich bei 2 Felder um Kantenfelder handelt.
	*/
	function method IsBorderSwitch(x: int, y: int) : bool
	requires Valid();
	reads this;
	reads items;
	reads borders;
	{
		(BordersContain(x) && BordersContain(y))
	}

	/*
	* Hilfsfunktion um festzusstellen, ob die Benannte Id derzeit in den Borders positioniert ist.
	*/
	function method BordersContain(v: int) : bool
	requires Valid();
	reads this;
	reads items;
	reads borders;
	{
		exists i :: 0 <= i < borders.Length && borders[i] == v
	}

	/*
	* CanMove prüft, ob das Feld der gegebenen Id das leere Feld als direkten Nachbarn hat und gibt ggf. die Position zurück.
	* Ansonsten gibt sie die Fakeposition 16 zurück, von der wir wissen, dass diese nicht existiert.
	*/
	method CanMove(id: int) returns(target: int)
	requires Valid();
	ensures Valid();
	{
		var indexToMove := FindPosById(id);
		target := 16;
		if(id != 15){
			if(!IsBorderSwitch(indexToMove, (indexToMove + 1)) && id < 15 && (indexToMove + 1 < 16) && GetIdByPos(indexToMove +1) == 15){
				target := indexToMove + 1;
			}
			if(!IsBorderSwitch(indexToMove, (indexToMove - 1)) && id < 15 && (indexToMove - 1 >= 0) && GetIdByPos(indexToMove - 1) == 15){
				target := indexToMove - 1;
			}
			if(id < 15 && (indexToMove + 4 < 16) && GetIdByPos(indexToMove + 4) == 15){
				target := indexToMove + 4;
			}
			if(id < 15 && (indexToMove - 4 >= 0) && GetIdByPos(indexToMove - 4) == 15){
				target := indexToMove - 4;
			}
		}
	}

	/*
	* MoveItem vertauscht die Items an den gegebenen Positionen.
	*/
	method MoveItem (indexToMove: int, targetIndex: int)
	requires Valid();
	requires 0 <= indexToMove < 16;
	requires 0 <= targetIndex < 16;
	modifies items;
	ensures Valid();
	{
		var dummy := items[targetIndex];
		items[targetIndex] := items[indexToMove];
		items[indexToMove] := dummy;
	}
}