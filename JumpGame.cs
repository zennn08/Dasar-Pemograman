namespace tugas11;

class Program
{
  static string[] animasiLari = {
    // 0
    @"       " + "\n" +
    @"       " + "\n" +
    @"  __o  " + "\n" +
    @" / /\_," + "\n" +
    @"__/\   " + "\n" +
    @"    \  " + "\n",
    // 1
    @"       " + "\n" +
    @"       " + "\n" +
    @"   _o  " + "\n" +
    @"  |/|_ " + "\n" +
    @"  /\   " + "\n" +
    @" /  |  " + "\n",
    // 2
    @"       " + "\n" +
    @"       " + "\n" +
    @"    o  " + "\n" +
    @"  </L  " + "\n" +
    @"   \   " + "\n" +
    @"   /|  " + "\n",
    // 3
    @"       " + "\n" +
    @"       " + "\n" +
    @"   o   " + "\n" +
    @"   |_  " + "\n" +
    @"   |>  " + "\n" +
    @"  /|   " + "\n",
    // 4
    @"       " + "\n" +
    @"       " + "\n" +
    @"   o   " + "\n" +
    @"  <|L  " + "\n" +
    @"   |_  " + "\n" +
    @"   |/  " + "\n",
    // 5
    @"       " + "\n" +
    @"       " + "\n" +
    @"   o   " + "\n" +
    @"  L|L  " + "\n" +
    @"   |_  " + "\n" +
    @"  /| | " + "\n",
    // 6
    @"       " + "\n" +
    @"       " + "\n" +
    @"  _o   " + "\n" +
    @" | |L  " + "\n" +
    @"   /-- " + "\n" +
    @"  /   |" + "\n",
  };
  static string[] animasiLompat = {
    // 0
    @"       " + "\n" +
    @"       " + "\n" +
    @"   _o  " + "\n" +
    @"  |/|_ " + "\n" +
    @"  /\   " + "\n" +
    @" /  |  " + "\n",
    // 1
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"    o  " + "\n" +
    @"  </L  " + "\n" +
    @"   /|  " + "\n",
    // 2
    @"       " + "\n" +
    @"    /o/" + "\n" +
    @"    /  " + "\n" +
    @"   //  " + "\n" +
    @"  //   " + "\n" +
    @"       " + "\n",
    // 3
    @"  __o__" + "\n" +
    @" /     " + "\n" +
    @"//     " + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n",
    // 4
    @"  __   " + "\n" +
    @" // \o " + "\n" +
    @"     \\" + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n",
    // 5
    @"  __   " + "\n" +
    @" //_o\ " + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n",
    // 6
    @"  __\  " + "\n" +
    @" _o/   " + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n",
    // 7
    @" \o\__ " + "\n" +
    @"     \\" + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n",
    // 8
    @"       " + "\n" +
    @"       " + "\n" +
    @"   o   " + "\n" +
    @"  L|L  " + "\n" +
    @"   |_  " + "\n" +
    @"  /  | " + "\n",
  };
  static int posisi = 0;
  static int? frameLari = 0;
  static int? frameLompat = null;
  static string rintangan =
    @"  ___  " + "\n" +
    @" |   | " + "\n" +
    @" | . | ";
  static void Main(string[] args)
  {
    Console.CursorVisible = false;
    if (OperatingSystem.IsWindows())
    {
      Console.WindowWidth = 120;
      Console.WindowHeight = 20;
    }
    Console.Clear();

    while (posisi < int.MaxValue)
    {
      if (Console.KeyAvailable)
      {
        switch (Console.ReadKey(true).Key)
        {
          case ConsoleKey.Escape:
            Console.Clear();
            Console.Write("Permainan ditutup.");
            return;
          case ConsoleKey.UpArrow or ConsoleKey.W:
            if (!frameLompat.HasValue)
            {
              frameLompat = 0;
              frameLari = null;
            }
            break;
        }
      }

      if (
        posisi >= 100 &&
        posisi % 50 == 0 &&
        (!frameLompat.HasValue ||
        !(2 <= frameLompat && frameLompat <= 7))
      )
      {
        Console.Clear();
        Console.Write("Permainan Berakhir.\nSkor : " + posisi + ".");
        return;
      }

      string playerFrame =
        frameLompat.HasValue ? animasiLompat[frameLompat.Value] :
        animasiLari[frameLari!.Value];

      Console.SetCursorPosition(4, 10);
      Render(playerFrame, true);
      TampilkanRintangan(true);

      if (posisi % 50 == 5)
      {
        Console.SetCursorPosition(0, 13);
        Render(
            @"       " + "\n" +
            @"       " + "\n" +
            @"       ", true
        );
      }

      if (posisi % 50 < 3)
      {
        Console.SetCursorPosition(4, 10);
        Render(playerFrame, false);
        TampilkanRintangan(false);
      }
      else
      {
        TampilkanRintangan(false);
        Console.SetCursorPosition(4, 10);
        Render(playerFrame, false);
      }

      frameLari = frameLari.HasValue
        ? (frameLari + 1) % animasiLari.Length
        : frameLari;

      frameLompat = frameLompat.HasValue
        ? frameLompat + 1
        : frameLompat;

      if (frameLompat >= animasiLompat.Length)
      {
        frameLompat = null;
        frameLari = 2;
      }
      posisi++;
      Thread.Sleep(TimeSpan.FromMilliseconds(10));
    }

    Console.Clear();
    Console.Write("Kamu menang.");
  }
  static void Render(string @string, bool renderSpace)
  {
    int x = Console.CursorLeft, y = Console.CursorTop;

    foreach (char c in @string)
      if (c is '\n') Console.SetCursorPosition(x, ++y);
      else if (c is not ' ' || renderSpace) Console.Write(c);
      else Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
  }
  static void TampilkanRintangan(bool renderSpace)
  {
    for (int i = 5; i < Console.WindowWidth - 5; i++)
    {
      if (posisi + i >= 100 && (posisi + i - 7) % 50 == 0)
      {
        Console.SetCursorPosition(i - 3, 13);
        Render(rintangan, renderSpace);
      }
    }
  }
}
