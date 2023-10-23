namespace pertemuan_2;

class Program
{
  static void Intro()
  {
    Console.Write("Halo selamat datang, masukkan nama anda : ");
    string? nama = Console.ReadLine();
    Console.WriteLine("--------------------------");
    // Deklarasi variabel
    string introGame1;
    string introGame2;

    // Inisiasi Variabel
    introGame1 = "Halo " + nama + ", kamu adalah agen rahasia yang ditugaskan untuk meretas sebuah server.";
    introGame2 = "Password server terdiri dari 3 angka yang tidak diketahui";

    // Tampilkan variabel pada layar
    Console.WriteLine(introGame1);
    Console.WriteLine(introGame2);
  }

  static void Main(string[] args)
  {
    int kesempatan = 3;
    // RNG
    Random rng = new Random();

    // Mendeklarasikan variabel bilangan bulat angkaPertama, angkaKedua, angkaKetiga, tebakanPertama, tebakanKedua, tebakanKetiga, hasilTambah, hasilKali
    int angkaPertama = rng.Next(1, 5),
        angkaKedua = rng.Next(1, 5),
        angkaKetiga = rng.Next(1, 5),
        tebakanPertama,
        tebakanKedua,
        tebakanKetiga,
        hasilTambah = angkaPertama + angkaKedua + angkaKetiga,
        hasilKali = angkaPertama * angkaKedua * angkaKetiga;

    // Mendeklarasikan variabel nilai boolean tebakanBerhasil, permainanSelesai;
    bool tebakanBerhasil, permainanSelesai;

    Intro();
    Console.WriteLine("--------------------------");
    Console.WriteLine($"Hasil penjumlahan dari password adalah {hasilTambah}");
    Console.WriteLine("Hasil perkalian dari password adalah " + hasilKali);
    Console.WriteLine("--------------------------");
    while (kesempatan > 0)
    {
      Console.Write("Masukkan password pertama : ");
      tebakanPertama = Convert.ToInt32(Console.ReadLine());
      Console.Write("Masukkan password kedua : ");
      tebakanKedua = Convert.ToInt32(Console.ReadLine());
      Console.Write("Masukkan password ketiga : ");
      tebakanKetiga = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("--------------------------");
      if (tebakanPertama == angkaPertama && tebakanKedua == angkaKedua && tebakanKetiga == angkaKetiga)
      {
        Console.WriteLine("Selamat server berhasil diretas!!!");
        kesempatan = 0;
      }
      else
      {
        kesempatan--;
        // kesempatan masih ada
        if (kesempatan > 0)
        {
          Console.WriteLine("Anda salah, server gagal diretas, !!!Silahkan coba lagi!!!");
          Console.WriteLine($"Sisa kesempatan : {kesempatan}");
          Console.WriteLine("--------------------------");
        }
        // kesempatan habis
        else
        {
          Console.WriteLine($"Kesempatan anda habis, Jawaban yang benar adalah {angkaPertama}, {angkaKedua}, {angkaKetiga}");
        }
      }
    }

  }
}
