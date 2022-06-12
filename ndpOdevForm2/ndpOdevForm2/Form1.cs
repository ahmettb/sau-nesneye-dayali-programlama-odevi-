









namespace ndpOdevForm2
{
    public partial class Form1 : Form
    {

        Label lblYazi = new Label();  //faturanýn yazýlý halini gösterecek labeli oluþturduk.
        Label labelTutarGir = new Label();//"Fatura Tutarý"yazan labeli oluþturduk.
        Label labelTutarYaziHali = new Label();
        TextBox txtSayi = new TextBox();//fatura ücretini gireceðimiz text box oluþturduk.
        Button btnHesapla = new Button();//hesapla butonu oluþturduk.
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblYazi.Location = new System.Drawing.Point(400, 230);//lblYazinin form ekranýndaki konumunu belirledik.
            lblYazi.Width = 900;//lblYazinin geniþliðini ayarladýk.
            this.Controls.Add(lblYazi);//lblYaziyi form ekranýnda görünür hale getirdik.

            labelTutarGir.Location = new System.Drawing.Point(200, 150);//labelTutarGir form ekranýndaki konumunu belirledik.
            labelTutarGir.Text = "FATURA TUTARI";//labelTutarGir ne yazýlmasý gerektiðini ayarladýk.
            labelTutarGir.Width = 200;//labelTutarGir geniþliðini ayarladýk.
            this.Controls.Add(labelTutarGir);//labelTutarGir form ekranýnda görünür hale getirdik.

            //ayný iþlemleri tüm form elemanlarý için yaptýk.

            labelTutarYaziHali.Location = new System.Drawing.Point(150, 230);
            labelTutarYaziHali.Text = "FATURA TUTARI YAZI ÝLE";
            labelTutarYaziHali.Width = 340;
            this.Controls.Add(labelTutarYaziHali);


            txtSayi.Location = new System.Drawing.Point(400, 140);
            txtSayi.Width = 150;
            this.Controls.Add(txtSayi);

            btnHesapla.Location = new System.Drawing.Point(350, 350);
            btnHesapla.Text = "Hesapla";
            this.Controls.Add(btnHesapla);
            btnHesapla.Width = 100;
            btnHesapla.Height = 50;
            btnHesapla.Click += new EventHandler(btnHesapla_Click);//hesapla butonunca basýlýnca programý çalýþtýrýp,istenenleri form ekranýnda gösterecektir.
        }
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            //birler,onlar,yüzler,binler basamaklarýnýn dizilerini tanýmladým
            string[] birlerBasamagi = { "", " BÝR ", " ÝKÝ ", " ÜÇ ", " DÖRT ", " BEÞ ", " ALTI ", " YEDÝ ", " SEKÝZ ", " DOKUZ " };
            string[] onlarBasamagi = { "", " ON ", " YÝRMÝ ", " OTUZ ", " KIRK ", " ELLÝ ", " ALTMIÞ ", " YETMÝÞ ", " SEKSEN ", " DOKSAN " };
            string[] yuzlerBasamagi = { "", " YÜZ ", " ÝKÝ YÜZ ", " ÜÇ YÜZ ", " DÖRT YÜZ ", " BEÞ YÜZ ", " ALTI YÜZ ", " YEDÝ YÜZ ", " SEKÝZ YÜZ ", " DOKUZ YÜZ " };
            string[] binlerBasamagi = { "", " BÝN ", " ÝKÝ BÝN ", " ÜÇ BÝN ", " DÖRT BÝN ", " BEÞ BÝN ", " ALTI BÝN ", " YEDÝ BÝN ", " SEKÝZ BÝN ", " DOKUZ BÝN " };
            //basamaklara ilk deðer atamasý yaptýk
            int sayininBirlerBasamagi = 0;
            int sayininOnlarBasamagi = 0;
            int sayininYuzlerBasamagi = 0;
            int sayininBinlerBasamagi = 0;
            int sayininOnbinlerBasamagi = 0;


            try
            {  //try ile kapsanan yerler normal bir þekilde çalýþacak.

                double girilenSayi = Convert.ToDouble(txtSayi.Text);  //txtSayiya girilen sayýyý doubleye çevirdik.

                if (txtSayi.Text.ToString().Contains("."))//eðer girilen deðerde "." varsa yapýlacak iþlemler.
                {

                    //sayýnýn tam kýsmýný bulmak için txtSayiyi substringle baþtan baþlatýp,"." olan yere kadar aldýrdým.Çýkan ifade sayýmýzýn tam kýsmý oldu(string biçiminde)
                    string sayininTamKismi = txtSayi.Text.ToString().Substring(0, txtSayi.Text.IndexOf("."));

                    //string biçimindeki tam sayý kýsmýný yeni bir int deðiþkene aktardýk.
                    int sayiTamKisim = Convert.ToInt32(sayininTamKismi);

                    //sayýnýn ondalýk kýsmýný bulmak için txtSayiyi substringle "." karakterinin bulunduðu indexin bir fazlasýndan baþlatýp aldýrdým.Çýkan ifade sayýmýzýn ondalýk kýsmý oldu(string biçiminde)
                    string sayininOndalikKismi = txtSayi.Text.ToString().Substring(txtSayi.Text.IndexOf(".") + 1);
                    //string biçimindeki ondalýk kýsmýný yeni bir int deðiþkene aktardýk.
                    int sayiOndalik = Convert.ToInt32(sayininOndalikKismi);

                    int sayininOndaBirlerBasamagi = 0;
                    int sayininYuzdeBirlerBasamagi = 0;

                    //girilen sayýnýn ondalýk kýsmýndaki deðerleri hesapladýk
                    sayininOndaBirlerBasamagi = sayiOndalik / 10;
                    sayininYuzdeBirlerBasamagi = sayiOndalik % 10;

                    //girilen sayýnýn tam  kýsmýndaki deðerleri hesapladýk
                    sayininBirlerBasamagi = sayiTamKisim % 10;
                    sayininOnlarBasamagi = (sayiTamKisim % 100) / 10;
                    sayininYuzlerBasamagi = (sayiTamKisim % 1000) / 100;
                    sayininBinlerBasamagi = (sayiTamKisim % 10000) / 1000;
                    sayininOnbinlerBasamagi = (sayiTamKisim / 10000);


                    if (sayininTamKismi.Length > 5 || sayininOndalikKismi.Length > 2)//eðer sayýnýn tam kýsmýnýn uzunluðu 5'den büyük veya ondalýk kýsmýnýn uzunluðu 2'den küçükse hata verdirdik.
                    {
                        DialogResult uyari = new DialogResult();//hata çýkýnca önümüze çýkacak message box ekranýný oluþturduk
                        uyari = MessageBox.Show("Geçersiz Tutar", "Uyarý", MessageBoxButtons.OKCancel);//uyarý ekranýnda yazacak ifadeleri ve butonlarý ekledik.

                    }
                    else//eðer yukarýdaki þartlar dýþýnda bir ifade olursa yapýlacak iþlemler
                    {
                        if (sayiTamKisim.ToString().Length == 5 && sayiTamKisim.ToString().Substring(1, 1) == "0")//eðer girilen sayý 5 basamaklý ve 2.basamaðý sýfýrsa (10000,40864 gibi)
                        {

                            lblYazi.Text = onlarBasamagi[sayininOnbinlerBasamagi] + "BÝN" + binlerBasamagi[sayininBinlerBasamagi] + yuzlerBasamagi[sayininYuzlerBasamagi] + onlarBasamagi[sayininOnlarBasamagi] + birlerBasamagi[sayininBirlerBasamagi] + " TL " +
                            onlarBasamagi[sayininOndaBirlerBasamagi] + birlerBasamagi[sayininYuzdeBirlerBasamagi] + " KURUÞ ";
                        }
                        else if (sayiTamKisim.ToString().Length == 5 && sayiTamKisim.ToString().Substring(1, 1) == "1")//eðer girilen sayý 5 basamaklý ve 2.basamaðý birse (21000,81321 gibi)
                        {

                            lblYazi.Text = onlarBasamagi[sayininOnbinlerBasamagi] + " BÝR " + binlerBasamagi[sayininBinlerBasamagi] + yuzlerBasamagi[sayininYuzlerBasamagi] + onlarBasamagi[sayininOnlarBasamagi] + birlerBasamagi[sayininBirlerBasamagi] + " TL " +
                            onlarBasamagi[sayininOndaBirlerBasamagi] + birlerBasamagi[sayininYuzdeBirlerBasamagi] + " KURUÞ ";
                        }

                        else if (sayiTamKisim.ToString().Substring(0, 1) == "0")//eðer ilk basamak sýfýrsa direkt kuruþ olaraka yazdýrdýk.
                        {
                            lblYazi.Text = onlarBasamagi[sayininOnbinlerBasamagi] + binlerBasamagi[sayininBinlerBasamagi] + yuzlerBasamagi[sayininYuzlerBasamagi] + onlarBasamagi[sayininOnlarBasamagi] + birlerBasamagi[sayininBirlerBasamagi] +
                            onlarBasamagi[sayininOndaBirlerBasamagi] + birlerBasamagi[sayininYuzdeBirlerBasamagi] + " KURUÞ ";
                        }
                        else//yukarýdaki þartlar dýþýnda olursa kuruþlu halini normal yazdýrdýk.
                        {
                            lblYazi.Text = onlarBasamagi[sayininOnbinlerBasamagi] + binlerBasamagi[sayininBinlerBasamagi] + yuzlerBasamagi[sayininYuzlerBasamagi] + onlarBasamagi[sayininOnlarBasamagi] + birlerBasamagi[sayininBirlerBasamagi] + " TL " +
                            onlarBasamagi[sayininOndaBirlerBasamagi] + birlerBasamagi[sayininYuzdeBirlerBasamagi] + " KURUÞ ";
                        }
                    }
                }
                else//eðer girilen ifadede "." yoksa yani tam sayýysa yapýlacak iþlemler
                {
                    //sayýnýn basamaklarýndaki rakamlarý hesapladýk.
                    sayininBirlerBasamagi = (int)girilenSayi % 10;
                    sayininOnlarBasamagi = (int)(girilenSayi % 100) / 10;
                    sayininYuzlerBasamagi = (int)(girilenSayi % 1000) / 100;
                    sayininBinlerBasamagi = (int)(girilenSayi % 10000) / 1000;
                    sayininOnbinlerBasamagi = (int)(girilenSayi / 10000);
                    if (txtSayi.Text.ToString().Length > 5)//eðer girilen sayý 5 basamaktan fazlaysa  message boxta uyarý verdirdik.
                    {
                        DialogResult uyari = new DialogResult();
                        uyari = MessageBox.Show("Geçersiz Tutar", "Uyarý", MessageBoxButtons.OKCancel);
                    }
                    else//eðer girilen sayý 5 basamaklý veya azsa  yapýlacak iþlemler.
                    {
                        if (girilenSayi.ToString().Length == 5 && girilenSayi.ToString().Substring(1, 1) == "0")//eðer girilen sayý 5 basamaklý ve 2.basamaðý sýfýrsa (10000,40864 gibi)
                        {
                            lblYazi.Text = onlarBasamagi[sayininOnbinlerBasamagi] + " BÝN " + binlerBasamagi[sayininBinlerBasamagi] + yuzlerBasamagi[sayininYuzlerBasamagi] + onlarBasamagi[sayininOnlarBasamagi] + birlerBasamagi[sayininBirlerBasamagi] + " TL ";
                        }
                        else if (girilenSayi.ToString().Length == 5 && girilenSayi.ToString().Substring(1, 1) == "1")//eðer girilen sayý 5 basamaklý ve 2.basamaðý birse (21000,81321 gibi)
                        {

                            lblYazi.Text = onlarBasamagi[sayininOnbinlerBasamagi] + " BÝR " + binlerBasamagi[sayininBinlerBasamagi] + yuzlerBasamagi[sayininYuzlerBasamagi] + onlarBasamagi[sayininOnlarBasamagi] + birlerBasamagi[sayininBirlerBasamagi] + " TL "
                          ;
                        }
                        else if (girilenSayi.ToString() == "0")//girilen deðer 0 ise 
                        {
                            lblYazi.Text = "SIFIR TL";
                        }
                        else //sayýmýz yukarýdaki þartýn dýþýndaysa normal yazdýrdýk.
                        {
                            lblYazi.Text = onlarBasamagi[sayininOnbinlerBasamagi] + binlerBasamagi[sayininBinlerBasamagi] + yuzlerBasamagi[sayininYuzlerBasamagi] + onlarBasamagi[sayininOnlarBasamagi] + birlerBasamagi[sayininBirlerBasamagi] + " TL ";

                        }
                    }
                }

            }
            catch//catch sayesinde eðer porgramýmýz herhangi bir sebeple hata verirse messageboxta uyarý verecek 
            {
                DialogResult uyari = new DialogResult();
                uyari = MessageBox.Show("Geçersiz Biçim Girildi !", "Uyarý", MessageBoxButtons.OKCancel);
            }
        }
    }
}
