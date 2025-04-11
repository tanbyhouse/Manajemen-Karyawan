using System;

namespace Manajemen_Karyawan
{
    //parentclass
    public class Karyawan
    {
        private string nama;
        private string id;
        private double gajiPokok;

        public Karyawan(string nama, string id, double gajiPokok)
        {
            this.nama = nama;
            this.id = id;
            this.gajiPokok = gajiPokok;
        }

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public double GajiPokok
        {
            get { return gajiPokok; }
            set { gajiPokok = value; }
        }

        public virtual double hitungGaji()
        {
            return gajiPokok;
        }
    }

    //subclass karyawan tetap
    public class karyawanTetap : Karyawan
    {
        private double bonus = 500000;

        public karyawanTetap(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok)
        {
        }

        public override double hitungGaji()
        {
            return GajiPokok + bonus;
        }
    }
    //subclass karyawan kontrak
    public class karyawanKontrak : Karyawan
    {
        private double potongan = 200000;

        public karyawanKontrak(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok)
        {
        }
        public override double hitungGaji()
        {
            return GajiPokok - potongan;
        }
    }
    //subclass karyawan magang
    public class karyawanMagang : Karyawan
    {
        public karyawanMagang(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok)
        {
        }
        public override double hitungGaji()
        {
            return GajiPokok;
        }
    }

    //main
    class Program
    {
        static void Main(string[] Args)
        {
            Console.WriteLine("Sistem Manajemen Karyawan"); 
            Console.WriteLine("Pilih Jenis Karyawan: \n (1) Tetap \n (2) Kontrak \n (3) Magang");
            string jenis = Console.ReadLine();

            Console.WriteLine("Nama Karyawan: ");
            string nama = Console.ReadLine();
            Console.WriteLine("ID Karyawan: ");
            string id = Console.ReadLine();
            Console.WriteLine("Gaji Pokok Karyawan: ");
            double gajiPokok = double.Parse(Console.ReadLine());

            Karyawan karyawan = null;

            switch (jenis)
            {
                case "1":
                    karyawan = new karyawanTetap(nama, id, gajiPokok);
                    break;
                case "2":
                    karyawan = new karyawanKontrak(nama, id, gajiPokok);
                    break;
                case "3":
                    karyawan = new karyawanMagang(nama, id, gajiPokok);
                    break;
                default:
                    Console.WriteLine("Jenis tidak valid");
                    return;
            }
            //menghitung dan menampilkan
            double gajiAkhir = karyawan.hitungGaji();
            Console.WriteLine($"Gaji akhir karyawan {karyawan.Nama} adalah Rp. {gajiAkhir}");
        }
    }

}