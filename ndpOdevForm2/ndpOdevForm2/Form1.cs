









namespace ndpOdevForm2
{
    public partial class Form1 : Form
    {

        Label lblYazi = new Label();  //faturan�n yaz�l� halini g�sterecek labeli olu�turduk.
        Label labelTutarGir = new Label();//"Fatura Tutar�"yazan labeli olu�turduk.
        Label labelTutarYaziHali = new Label();
        TextBox txtSayi = new TextBox();//fatura �cretini girece�imiz text box olu�turduk.
        Button btnHesapla = new Button();//hesapla butonu olu�turduk.
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblYazi.Location = new System.Drawing.Point(400, 230);//lblYazinin form ekran�ndaki konumunu belirledik.
            lblYazi.Width = 900;//lblYazinin geni�li�ini ayarlad�k.
            this.Controls.Add(lblYazi);//lblYaziyi form ekran�nda g�r�n�r hale getirdik.

            labelTutarGir.Location = new System.Drawing.Point(200, 150);//labelTutarGir form ekran�ndaki konumunu belirledik.
            labelTutarGir.Text = "FATURA TUTARI";//labelTutarGir ne yaz�lmas� gerekti�ini ayarlad�k.
            labelTutarGir.Width = 200;//labelTutarGir geni�li�ini ayarlad�k.
            this.Controls.Add(labelTutarGir);//labelTutarGir form ekran�nda g�r�n�r hale getirdik.

            //ayn� i�lemleri t�m form elemanlar� i�in yapt�k.

            labelTutarYaziHali.Location = new System.Drawing.Point(150, 230);
            labelTutarYaziHali.Text = "FATURA TUTARI YAZI �LE";
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
            btnHesapla.Click += new EventHandler(btnHesapla_Click);//hesapla butonunca bas�l�nca program� �al��t�r�p,istenenleri form ekran�nda g�sterecektir.
        }
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            //birler,onlar,y�zler,binler basamaklar�n�n dizilerini tan�mlad�m
            string[] birlerBasamagi = { "", " B�R ", " �K� ", " �� ", " D�RT ", " BE� ", " ALTI ", " YED� ", " SEK�Z ", " DOKUZ " };
            string[] onlarBasamagi = { "", " ON ", " Y�RM� ", " OTUZ ", " KIRK ", " ELL� ", " ALTMI� ", " YETM�� ", " SEKSEN ", " DOKSAN " };
            string[] yuzlerBasamagi = { "", " Y�Z ", " �K� Y�Z ", " �� Y�Z ", " D�RT Y�Z ", " BE� Y�Z ", " ALTI Y�Z ", " YED� Y�Z ", " SEK�Z Y�Z ", " DOKUZ Y�Z " };
            string[] binlerBasamagi = { "", " B�N ", " �K� B�N ", " �� B�N ", " D�RT B�N ", " BE� B�N ", " ALTI B�N ", " YED� B�N ", " SEK�Z B�N ", " DOKUZ B�N " };
            //basamaklara ilk de�er atamas� yapt�k
            int sayininBirlerBasamagi = 0;
            int sayininOnlarBasamagi = 0;
            int sayininYuzlerBasamagi = 0;
            int sayininBinlerBasamagi = 0;
            int sayininOnbinlerBasamagi = 0;


            try
            {  //try ile kapsanan yerler normal bir �ekilde �al��acak.

                double girilenSayi = Convert.ToDouble(txtSayi.Text);  //txtSayiya girilen say�y� doubleye �evirdik.

                if (txtSayi.Text.ToString().Contains("."))//e�er girilen de�erde "." varsa yap�lacak i�lemler.
                {

                    //say�n�n tam k�sm�n� bulmak i�in txtSayiyi substringle ba�tan ba�lat�p,"." olan yere kadar ald�rd�m.��kan ifade say�m�z�n tam k�sm� oldu(string bi�iminde)
                    string sayininTamKismi = txtSayi.Text.ToString().Substring(0, txtSayi.Text.IndexOf("."));

                    //string bi�imindeki tam say� k�sm�n� yeni bir int de�i�kene aktard�k.
                    int sayiTamKisim = Convert.ToInt32(sayininTamKismi);

                    //say�n�n ondal�k k�sm�n� bulmak i�in txtSayiyi substringle "." karakterinin bulundu�u indexin bir fazlas�ndan ba�lat�p ald�rd�m.��kan ifade say�m�z�n ondal�k k�sm� oldu(string bi�iminde)
                    string sayininOndalikKismi = txtSayi.Text.ToString().Substring(txtSayi.Text.IndexOf(".") + 1);
                    //string bi�imindeki ondal�k k�sm�n� yeni bir int de�i�kene aktard�k.
                    int sayiOndalik = Convert.ToInt32(sayininOndalikKismi);

                    int sayininOndaBirlerBasamagi = 0;
                    int sayininYuzdeBirlerBasamagi = 0;

                    //girilen say�n�n ondal�k k�sm�ndaki de�erleri hesaplad�k
                    sayininOndaBirlerBasamagi = sayiOndalik / 10;
                    sayininYuzdeBirlerBasamagi = sayiOndalik % 10;

                    //girilen say�n�n tam  k�sm�ndaki de�erleri hesaplad�k
                    sayininBirlerBasamagi = sayiTamKisim % 10;
                    sayininOnlarBasamagi = (sayiTamKisim % 100) / 10;
                    sayininYuzlerBasamagi = (sayiTamKisim % 1000) / 100;
                    sayininBinlerBasamagi = (sayiTamKisim % 10000) / 1000;
                    sayininOnbinlerBasamagi = (sayiTamKisim / 10000);


                    if (sayininTamKismi.Length > 5 || sayininOndalikKismi.Length > 2)//e�er say�n�n tam k�sm�n�n uzunlu�u 5'den b�y�k veya ondal�k k�sm�n�n uzunlu�u 2'den k���kse hata verdirdik.
                    {
                        DialogResult uyari = new DialogResult();//hata ��k�nca �n�m�ze ��kacak message box ekran�n� olu�turduk
                        uyari = MessageBox.Show("Ge�ersiz Tutar", "Uyar�", MessageBoxButtons.OKCancel);//uyar� ekran�nda yazacak ifadeleri ve butonlar� ekledik.

                    }
                    else//e�er yukar�daki �artlar d���nda bir ifade olursa yap�lacak i�lemler
                    {
                        if (sayiTamKisim.ToString().Length == 5 && sayiTamKisim.ToString().Substring(1, 1) == "0")//e�er girilen say� 5 basamakl� ve 2.basama�� s�f�rsa (10000,40864 gibi)
                        {

                            lblYazi.Text = onlarBasamagi[sayininOnbinlerBasamagi] + "B�N" + binlerBasamagi[sayininBinlerBasamagi] + yuzlerBasamagi[sayininYuzlerBasamagi] + onlarBasamagi[sayininOnlarBasamagi] + birlerBasamagi[sayininBirlerBasamagi] + " TL " +
                            onlarBasamagi[sayininOndaBirlerBasamagi] + birlerBasamagi[sayininYuzdeBirlerBasamagi] + " KURU� ";
                        }
                        else if (sayiTamKisim.ToString().Length == 5 && sayiTamKisim.ToString().Substring(1, 1) == "1")//e�er girilen say� 5 basamakl� ve 2.basama�� birse (21000,81321 gibi)
                        {

                            lblYazi.Text = onlarBasamagi[sayininOnbinlerBasamagi] + " B�R " + binlerBasamagi[sayininBinlerBasamagi] + yuzlerBasamagi[sayininYuzlerBasamagi] + onlarBasamagi[sayininOnlarBasamagi] + birlerBasamagi[sayininBirlerBasamagi] + " TL " +
                            onlarBasamagi[sayininOndaBirlerBasamagi] + birlerBasamagi[sayininYuzdeBirlerBasamagi] + " KURU� ";
                        }

                        else if (sayiTamKisim.ToString().Substring(0, 1) == "0")//e�er ilk basamak s�f�rsa direkt kuru� olaraka yazd�rd�k.
                        {
                            lblYazi.Text = onlarBasamagi[sayininOnbinlerBasamagi] + binlerBasamagi[sayininBinlerBasamagi] + yuzlerBasamagi[sayininYuzlerBasamagi] + onlarBasamagi[sayininOnlarBasamagi] + birlerBasamagi[sayininBirlerBasamagi] +
                            onlarBasamagi[sayininOndaBirlerBasamagi] + birlerBasamagi[sayininYuzdeBirlerBasamagi] + " KURU� ";
                        }
                        else//yukar�daki �artlar d���nda olursa kuru�lu halini normal yazd�rd�k.
                        {
                            lblYazi.Text = onlarBasamagi[sayininOnbinlerBasamagi] + binlerBasamagi[sayininBinlerBasamagi] + yuzlerBasamagi[sayininYuzlerBasamagi] + onlarBasamagi[sayininOnlarBasamagi] + birlerBasamagi[sayininBirlerBasamagi] + " TL " +
                            onlarBasamagi[sayininOndaBirlerBasamagi] + birlerBasamagi[sayininYuzdeBirlerBasamagi] + " KURU� ";
                        }
                    }
                }
                else//e�er girilen ifadede "." yoksa yani tam say�ysa yap�lacak i�lemler
                {
                    //say�n�n basamaklar�ndaki rakamlar� hesaplad�k.
                    sayininBirlerBasamagi = (int)girilenSayi % 10;
                    sayininOnlarBasamagi = (int)(girilenSayi % 100) / 10;
                    sayininYuzlerBasamagi = (int)(girilenSayi % 1000) / 100;
                    sayininBinlerBasamagi = (int)(girilenSayi % 10000) / 1000;
                    sayininOnbinlerBasamagi = (int)(girilenSayi / 10000);
                    if (txtSayi.Text.ToString().Length > 5)//e�er girilen say� 5 basamaktan fazlaysa  message boxta uyar� verdirdik.
                    {
                        DialogResult uyari = new DialogResult();
                        uyari = MessageBox.Show("Ge�ersiz Tutar", "Uyar�", MessageBoxButtons.OKCancel);
                    }
                    else//e�er girilen say� 5 basamakl� veya azsa  yap�lacak i�lemler.
                    {
                        if (girilenSayi.ToString().Length == 5 && girilenSayi.ToString().Substring(1, 1) == "0")//e�er girilen say� 5 basamakl� ve 2.basama�� s�f�rsa (10000,40864 gibi)
                        {
                            lblYazi.Text = onlarBasamagi[sayininOnbinlerBasamagi] + " B�N " + binlerBasamagi[sayininBinlerBasamagi] + yuzlerBasamagi[sayininYuzlerBasamagi] + onlarBasamagi[sayininOnlarBasamagi] + birlerBasamagi[sayininBirlerBasamagi] + " TL ";
                        }
                        else if (girilenSayi.ToString().Length == 5 && girilenSayi.ToString().Substring(1, 1) == "1")//e�er girilen say� 5 basamakl� ve 2.basama�� birse (21000,81321 gibi)
                        {

                            lblYazi.Text = onlarBasamagi[sayininOnbinlerBasamagi] + " B�R " + binlerBasamagi[sayininBinlerBasamagi] + yuzlerBasamagi[sayininYuzlerBasamagi] + onlarBasamagi[sayininOnlarBasamagi] + birlerBasamagi[sayininBirlerBasamagi] + " TL "
                          ;
                        }
                        else if (girilenSayi.ToString() == "0")//girilen de�er 0 ise 
                        {
                            lblYazi.Text = "SIFIR TL";
                        }
                        else //say�m�z yukar�daki �art�n d���ndaysa normal yazd�rd�k.
                        {
                            lblYazi.Text = onlarBasamagi[sayininOnbinlerBasamagi] + binlerBasamagi[sayininBinlerBasamagi] + yuzlerBasamagi[sayininYuzlerBasamagi] + onlarBasamagi[sayininOnlarBasamagi] + birlerBasamagi[sayininBirlerBasamagi] + " TL ";

                        }
                    }
                }

            }
            catch//catch sayesinde e�er porgram�m�z herhangi bir sebeple hata verirse messageboxta uyar� verecek 
            {
                DialogResult uyari = new DialogResult();
                uyari = MessageBox.Show("Ge�ersiz Bi�im Girildi !", "Uyar�", MessageBoxButtons.OKCancel);
            }
        }
    }
}
