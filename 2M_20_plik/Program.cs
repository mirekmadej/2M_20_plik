﻿using System.Runtime.CompilerServices;

namespace _2M_20_plik
{
    /// <summary>
    /// klasa Pytanie  służy do przechowywania pytania i odpowiedzi
    /// </summary>
    class Pytanie
    {
        public string odp { get; private set; }
        private string pytanie, o1, o2, o3, o4;
 

        /// <summary>
        /// konstruktor klasy Pytanie
        /// </summary>
        /// <param name="pytanie">string reprezentujący pytanie</param>
        /// <param name="o1">string reprezentujący odpowiedź 1</param>
        /// <param name="o2">string reprezentujący odpowiedź 2</param>
        /// <param name="o3">string reprezentujący odpowiedź 3</param>
        /// <param name="o4">string reprezentujący odpowiedź 4</param>
        /// <param name="odp">string reprezentujący poprawną odpowiedź</param>
        public Pytanie(string pytanie, string o1, string o2, string o3, string o4, string odp)
        {
            this.pytanie = pytanie;
            this.o1 = o1;
            this.o2 = o2;
            this.o3 = o3;
            this.o4 = o4;
            this.odp = odp;
        }
        public override string ToString()
        {
            return $"{pytanie}\nA) {o1}\nb) {o2}\nC) {o3}\nD) {o4}\n*{odp}";
        }
    }
    internal class Program
    {
        static List<Pytanie> pytania = new List<Pytanie>();
        static void Main(string[] args)
        {
            Pytanie p1;// = new Pytanie("2+2=", "1", "2", "3", "4","4");
            string pytanie, o1, o2, o3, o4,odp="";
            using(TextReader p = File.OpenText("testy.txt"))
            {
                string czysc(string s)
                {
                    int p = s.IndexOf(" ");
                    int g = s.IndexOf("*");
                    if (g >= 0)
                        odp = s.Substring(0,1);
                    s = s.Substring(p+1, s.Length-p-1);

                    return s;
                }
                while(p.Peek() > -1)
                {
                    pytanie = czysc(p.ReadLine());
                    o1 = czysc(p.ReadLine());
                    o2 = czysc(p.ReadLine());
                    o3 = czysc(p.ReadLine());
                    o4 = czysc(p.ReadLine());
                    p.ReadLine();
                    
                    pytania.Add(new Pytanie(pytanie, o1, o2, o3, o4, odp));
                }
            }

            int zadajPytanie(Pytanie p)
            {
                Console.WriteLine(p);
                Console.Write("odpowiedź: ");
                string o = Console.ReadLine().ToUpper();
                if (o == p.odp)
                {
                    Console.WriteLine("dobrze");
                    return 1;
                }
                else
                {
                    Console.WriteLine("źle");
                    return 0;
                }                    
            }

            var pytania2 = new List<Pytanie>(pytania);
            int ile = 0;
            Random r = new Random();
            for(int i=0; i<5; i++)
            {
                int p = r.Next(pytania2.Count-1);
                ile += zadajPytanie(pytania2[p]);
                pytania2.RemoveAt(p);
            }
            Console.WriteLine($"poprawnych odpowiedzi: {ile}");

            

            
        }
    }
}

/*
 * przykładowy plik z pytaniami, nalezy zapisac go w katalogu 
 * z plikiem wykonywalnym, np: bin\Debug\net6.0
 * ważne: po ostatnim pytaniu nie może być pustych linii
1. System operacyjny nie zajmuje się 
A. dostarczaniem mechanizmów do synchronizacji zadań i komunikacji pomiędzy zadaniami. 
B. planowaniem oraz przydziaáem czasu procesora poszczególnym zadaniom. 
C. kontrolą i przydziaáem pamięci operacyjnej dla uruchomionych zadań. 
D*. tworzeniem źródeł aplikacji systemowych.

2. Podstawową funkcją serwera FTP jest 
A. monitoring sieci. 
B. synchronizacja czasu. 
C*. udostępnianie plików. 
D. zarządzanie kontami poczty. 

3. Do cech pojedynczego konta użytkownika pracującego w systemie Windows Serwer należy 
A*. numer telefonu, pod który ma oddzwonić serwer w przypadku nawiązania połączenia telefonicznego przez tego użytkownika. 
B. maksymalna wielkość pojedynczego pliku jaką użytkownik może zapisać na dysku serwera. 
C. maksymalna wielkość pulpitu użytkownika  
D. maksymalna wielkość profilu użytkownika.

4. Który z protokołów jest protokołem synchronizacji czasu? 
A. FTP 
B*. NTP 
C. HTTP 
D. NNTP

5. Litera S w protokole FTPS oznacza zabezpieczanie przesyłanych danych poprzez 
A. logowanie. 
B. autoryzację. 
C*. szyfrowanie. 
D. uwierzytelnianie. 

6. Który z protokołów jest protokołem wykorzystywanym do zarządzania urządzeniami sieciowymi? 
A. SMTP 
B*. SNMP 
C. SFTP 
D. DNS 

7. Translacją nazw domenowych na adresy sieciowe zajmuje się usługa 
A*. DNS 
B. DHCP 
C. SMTP 
D. SNMP

8. Który z protokołów jest szyfrowanym protokołem terminalowym? 
A*. SSH 
B. TFTP 
C. telnet 
D. POP3

9. Który protokół obsáuguje rozproszone wysyłanie i pobieranie plików? 
A. FTP 
B. Radius 
C. HTTPS 
D*. BitTorrent

10. AES (ang. Advanced Encryption Standard) 
A. jest poprzednikiem DES (ang. Data Encryption Standard). 
B. nie może być wykorzystany przy szyfrowaniu plików. 
C*. wykorzystuje symetryczny algorytm szyfrujący. 
D. nie może być zaimplementowany sprzętowo.

11. Jaki protokół odpowiada za zamianę adresów IP na adresy kontroli dostępu do nośnika (MAC)? 
A*. ARP 
B. RARP 
C. SMTP 
D. SNMP

12. Jaki adres IP odpowiada nazwie mnemonicznej localhost? 
A*. 127.0.0.1 
B. 192.168.1.0 
C. 192.168.1.1 
D. 192.168.1.255

13. W firmowej sieci bezprzewodowej została uruchomiona usługa polegająca na tłumaczeniu nazw mnemonicznych. Jest to usługa 
A. RADIUS 
B. DHCP 
C. RDS 
D*. DNS

14. Którego protokołu należy użyć do odbioru poczty elektronicznej ze swojego serwera? 
A. SMTP  
B. SNMP  
C*. POP3  
D. FTP

15. Który  protokół  komunikacyjny  służy  do  transferu  plików  w  układzie  klient-serwer  oraz  może  działać w dwóch trybach: aktywnym i pasywnym? 
A. IP 
B*. FTP  
C. DNS  
D. EI-SI

16. Zadaniem serwera plików w sieciach komputerowych LAN jest 
A. zarządzanie pracą przełączników i ruterów. 
B. sterowanie danymi na komputerach lokalnymi. 
C*. wspólne użytkowanie tych samych zasobów. 
D. wykonywanie procesów obliczeniowych na komputerach lokalnych. 

17. Z  jakim  parametrem  należy  wywołać  polecenie  netstat,  aby  została  wyświetlona  statystyka  interfejsu  sieciowego (liczba wysłanych oraz odebranych bajtów i pakietów)? 
A. -a  
B*. -e 
C. -n 
D. -o

18. Konwencja  zapisu  ścieżki  do  udziału  sieciowego  zgodna  z  UNC  (Universal  Naming  Convention)  ma  postać 
A. \\nazwa_zasobu\nazwa_komputera. 
B. //nazwa_zasobu/nazwa_komputera. 
C*. \\nazwa_komputera\nazwa_zasobu. 
D. //nazwa_komputera/nazwa_zasobu.

19. Która  usługa  polega  na  scentralizowanym  zarządzaniu  tożsamościami,  uprawnieniami  oraz  obiektami w sieci? 
A*. AD (Active Directory). 
B. NAS (Network File System). 
C. WDS (Windows Deployment Services). 
D. DHCP (Dynamic Host Configuration Protocol).

20. Grupa,  w  której  uprawnienia  członków  można  przypisywać  tylko  w  obrębie  tej  samej  domeny,  co  domena nadrzędnej grupy lokalnej domeny, to grupa 
A. globalna.  
B. uniwersalna.  
C*. lokalna domeny.  
D. lokalna komputera
*/