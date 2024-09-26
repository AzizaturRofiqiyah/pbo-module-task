using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//base class: hewan
public class Hewan
{
    public string Nama;
    public int Umur;

    public Hewan(string nama, int umur)
    {
        Nama = nama;
        Umur = umur;
    }

    public virtual string Suara()
    {
        return "Hewan ini bersuara"; 
    }

    public virtual string InfoHewan()
    {
        return $"Nama: {Nama}, Umur: {Umur} tahun";
    }

    public virtual string AksiKhusus()
    {
        return ""; //dapat di override
    }
}

//subclass: mamalia
public class Mamalia : Hewan
{
    public int JumlahKaki;

    public Mamalia(string nama, int umur, int jumlahKaki) : base(nama, umur)
    { 
        JumlahKaki = jumlahKaki;
    }

    public override string InfoHewan()
    {
        return base.InfoHewan() + $", Jumlah Kaki: {JumlahKaki}";
    }
}

//subclass : reptil
public class Reptil : Hewan
{
    public double PanjangTubuh;
    public Reptil(string nama, int umur, double panjangTubuh) : base(nama, umur)
    {
        PanjangTubuh = panjangTubuh;
    }

    public override string InfoHewan()
    {
        return base.InfoHewan() + $", Panjang Tubuh: {PanjangTubuh} meter";
    }
}

//subclass: singa
public class Singa : Mamalia
{
    public Singa(string nama, int umur, int jumlahKaki) : base(nama, umur, jumlahKaki) { }
    public override string Suara()
    {
        return "Singa mengaum rawr";
    }

    public override string AksiKhusus()
    {
        return $"{Nama} sedang mengaum dengan keras rawr";
    }

    //method mengaum
    public void Mengaum()
    {
        Console.WriteLine($"{Nama} sedang mengaum dengan sangat keras rawr");
    }
}

//subclass: gajah
public class Gajah : Mamalia
{
    public Gajah(string nama, int umur, int jumlahKaki) : base(nama, umur, jumlahKaki) { }
    public override string Suara()
    {
        return "Gajah menderum";
    }
}

//subclass: ular
public class Ular : Reptil
{
    public Ular(string nama, int umur, double panjangTubuh) : base(nama, umur, panjangTubuh) { }
    public override string Suara()
    {
        return "Ular mendesis";
    }

    public override string AksiKhusus()
    {
        return $"{Nama} sedang merayap meliuk liuk di tanah";
    }

    //method merayap
    public void Merayap()
    {
        Console.WriteLine($"{Nama} sedang merayap meliuk liuk di tanah");
    }
}

// subclass: buaya
public class Buaya : Reptil
{
    public Buaya(string nama, int umur, double panjangTubuh) : base(nama, umur, panjangTubuh) { }
    public override string Suara()
    {
        return "Buaya mengeram";
    }
}

// kelas kebun binatang
public class KebunBinatang
{
    private List<Hewan> koleksiHewan;
    public KebunBinatang()
    { 
        koleksiHewan = new List<Hewan>();
    }

    public void TambahHewan(Hewan hewan)
    {
        koleksiHewan.Add(hewan);
        Console.WriteLine($"{hewan.Nama} telah ditambahkan ke kebun binatang ");
    }

    public void DaftarHewan()
    {
        Console.WriteLine("\nDaftar Hewan di Kebun Binatang:");
        foreach (Hewan hewan in koleksiHewan)
        {
            Console.WriteLine($"\n{hewan.InfoHewan()}, {hewan.Suara()}");
            string aksi = hewan.AksiKhusus();
            if (!string.IsNullOrEmpty(aksi))
            {
                Console.WriteLine(aksi);
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        //buat objek kebun binatang
        KebunBinatang kebunBinatang = new KebunBinatang();

        //buat objek dari berbagai jenis hewan
        Singa singa = new Singa("Lion", 9, 4);
        Gajah gajah = new Gajah("Spongebob", 12, 4);
        Ular ular = new Ular("Mnet", 2, 3);
        Buaya buaya = new Buaya("Niskala", 7, 3.5);

        //tambhkan hewan ke kebun binatang
        kebunBinatang.TambahHewan(singa);
        kebunBinatang.TambahHewan(gajah);
        kebunBinatang.TambahHewan(ular);
        kebunBinatang.TambahHewan(buaya);

        //tampilkan daftar hewan di kebun binatang
        kebunBinatang.DaftarHewan();

        //memanggil method mengaum dan merayap
        Console.WriteLine("\nAksi Khusus: ");
        singa.Mengaum();
        ular.Merayap();
    }

}
