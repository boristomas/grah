using System;
using System.Collections;
using System.Timers;
using System.Threading;


namespace grahSaKobasicamaIŠpekom
{
    /// <summary>
    /// grah za 6-7 ljudi
    /// </summary>
    class Program
    {
        public static sastojak grah = new sastojak("grah crveni", "1kg", 20.00F);
        public static sastojak šećer = new sastojak("šečer kristal", "2 žlice", 0.0F);
        public static sastojak sol = new sastojak("sol sitna morska", "2 žlice", 0.0F);
        public static sastojak luk = new sastojak("luk ljubičasti", "0.316kg", 1.42F);
        public static sastojak limun = new sastojak("limun obični", "1 veliki komad", 0.80F);
        public static sastojak voda = new sastojak("voda iz pipe", "2 litre", 0.0F);
		public static sastojak vino = new sastojak("fino francusko vino", "1 litra", 30.0F);
		public static sastojak vinoMalo = new sastojak("malo crno vino", "200 ml", 9.0F);
        public static sastojak kobasica1 = new sastojak("zagrebačka kobasica", "4 para", 60.0F);
        public static sastojak kobasica2 = new sastojak("kranjska kobasica podravka", "2 para", 30.0F);
        public static sastojak kobasica3 = new sastojak("kranjska kobasica pik", "5 para", 70.0F);
        public static sastojak slanina1 = new sastojak("odresci slanine iz konzuma", "0.5kg", 20.0F);
        public static sastojak slanina2 = new sastojak("slanina tzv. hamburger", "0.2kg", 15.0F);
        public static sastojak mrkva = new sastojak("mrkva obična velika", "2 komada", 2.0F);
        public static sastojak kocka = new sastojak("kocka za juhu - goveđa", "2 komada", 9.0F);
        public static sastojak feferon = new sastojak("feferon blagi", "ona najmanja staklenka", 9.0F);
        public static sastojak paprika = new sastojak("mljevena ljuta paprika", "1 čajna žlica", 0.01F);
        public static sastojak rajčica = new sastojak("koncentrat rajčice", "0.2L", 3.0F);
        public static oprema lonac = new oprema();
        public static oprema posuda1 = new oprema();
        public static oprema posuda2 = new oprema();
        public static oprema posuda3 = new oprema();
        public static oprema tava = new oprema();
        
        static void Main(string[] args)
        {

            mrkva.nasjeciNaVelicinu(3, 3, 3);
            lonac.Add(grah);
            lonac.Add(mrkva);
            lonac.Add(šećer);
            lonac.Add(sol);
            lonac.Add(voda);
            BackgroundWorker DokSeGrahKuha = new BackgroundWorker();
            DokSeGrahKuha.DoWork += new DoWorkEventHandler(DokSeGrahKuha_DoWork);
            DokSeGrahKuha.RunWorkerAsync();
            while (!grah.isKuhan)
            {
                lonac.kuhaj(5);
            }
            lonac.Remove(voda);
            lonac.Remove(mrkva);
            posuda1.Add(mrkva);
            ((sastojak)lonac[lonac.IndexOf(grah)]).kol = "0.90kg";
            posuda1.Add(new sastojak("grah kuhani","0.10kg",2.0F));
            posuda1.Add(kocka);
            feferon.nasjeciNaVelicinu(0.3F, 0.3F, 0.2F);
            luk.nasjeciNaVelicinu(0.001F, 0.001F, 0.001F);
            tava.Add(feferon);
            tava.Add(luk);
            tava.ispržiSadržaj("onako malo, ne jako");
            tava.Add(paprika);
            tava.ispržiSadržaj("jos samo jako malo da se paprika izmješa");
            posuda1.sameljiSadržaj();
            tava.isprazniU(posuda1);
            posuda1.Add(rajčica);
            tava.Clear();
            tava.Add(slanina1);
            tava.ispržiSadržaj("malo, dok ne postane zlatko smeđe");
            tava.isprazniU(posuda2);
            tava.Clear();
            limun.iscijedi();
            posuda2.Add(limun);
            posuda2.Add(vinoMalo);
            tava.Add(kobasica1);
            tava.ispržiSadržaj("da bude lagano hrskavo");
            tava.isprazniU(posuda3);
            tava.Clear();
            tava.Add(kobasica2);
            tava.ispržiSadržaj("da bude lagano hrskavo");
            tava.isprazniU(posuda3);
            tava.Clear();
            tava.Add(kobasica3);
            tava.ispržiSadržaj("da bude lagano hrskavo");
            tava.isprazniU(posuda3);
            tava.Clear();
            posuda1.isprazniU(lonac);
            posuda2.isprazniU(lonac);
            posuda3.isprazniU(lonac);
			lonac.Add(vino);
            lonac.kuhaj(20);
        }

        static void DokSeGrahKuha_DoWork(object sender, DoWorkEventArgs e)
        {
            kobasica1.nasjeciNaVelicinu(2, 2, 1);
            kobasica2.nasjeciNaVelicinu(2, 2, 1);
            kobasica3.nasjeciNaVelicinu(2, 2, 1);
            slanina1.nasjeciNaVelicinu(0.5F, 0.5F, 2F);
            slanina2.nasjeciNaVelicinu(0.5F, 0.5F, 2F);
        }
    }
    class oprema : ArrayList
    {
        public sastojak vatra = new sastojak("vatra na plinskom štednjaku", "srednje jaka", 0.0F);
        /// <summary>
        /// kuhaj sve sastojke koji se nalaze u listi(loncu)
        /// i to na vatri koja je određena poljem vatra;
        /// </summary>
        public void kuhaj( int minuta)
        {
            Thread.Sleep(minuta*60000);
            miješaj();
        }
        /// <summary>
        /// tu i tamo promješaj sastojke posude (toliko cesto da barem ne zagori)
        /// </summary>
        private void miješaj()
        {
        }
        public void sameljiSadržaj()
        {
        }
        /// <summary>
        /// prži sastojke na malo ulja
        /// </summary>
        /// <param name="Koliko">koliko jako pržiti?</param>
        public void ispržiSadržaj(String Koliko)
        {
        }
        public void isprazniU(oprema ulaz)
        {
            foreach (sastojak item in this)
            {
                ulaz.Add(item);                
            }
            this.Clear();
        }
    }
    class sastojak
    {
        string naz;
        public string kol;
        float vrij;
        public sastojak(string naziv, string količina, float vrijednost)
        {
		//vrijednost je u kunama
            naz = naziv;
            kol = količina;
            vrij = vrijednost;
        }
        /// <summary>
        /// ukloniti vlagu iz sastojka
        /// </summary>
        public void iscijedi()
        {

        }
        /// <summary>
        /// da li je sastojak kuhan?
        /// </summary>
        public bool isKuhan
        {
            get;
            set;
        }
        /// <summary>
        /// sjecka sastojak na manje entitete.
        /// </summary>
        /// <param name="x">u smjeru x koliko centimetara</param>
        /// <param name="y">u smjeru y koliko centimetara</param>
        /// <param name="z">u smjeru z koliko centimetara</param>
        public void nasjeciNaVelicinu(float x, float y, float z)
        {
        }

    }
}
